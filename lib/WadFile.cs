// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;
using System.Collections.Generic;
using System.IO;

namespace Cyotek.Data
{
  public class WadFile
  {
    #region Private Fields

    private const int _maximumInMemorySize = 1048576 * 100;

    private Stream _inputStream;

    private readonly WadLumpCollection _lumps;

    private WadType _type;

    #endregion Private Fields

    #region Public Constructors

    public WadFile()
      : this(WadType.Internal)
    {
    }

    public WadFile(WadType type)
    {
      _type = type;
      _lumps = new WadLumpCollection();
    }

    public WadFile(Stream stream)
      : this()
    {
      this.Load(stream);
    }

    #endregion Public Constructors

    #region Public Properties

    public Stream InputStream => _inputStream;

    public WadLumpCollection Lumps => _lumps;

    public WadType Type
    {
      get => _type;
      set => _type = value;
    }

    #endregion Public Properties

    #region Public Methods

    public static WadType GetFormat(string fileName)
    {
      Guard.ThrowIfNullOrEmpty(fileName, nameof(fileName));

      using (Stream stream = File.OpenRead(fileName))
      {
        return WadFile.GetFormat(stream);
      }
    }

    public static WadType GetFormat(Stream stream)
    {
      WadType result;
      byte[] buffer;
      long position;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));
      Guard.ThrowIfUnseekableStream(stream, nameof(stream));

      buffer = BufferHelpers.GetBuffer(WadConstants.SignatureLength);

      position = stream.Position;

      if (stream.Read(buffer, 0, WadConstants.SignatureLength) == WadConstants.SignatureLength)
      {
        if (WadDirectoryReader.IsValidSignature(buffer, WadConstants.Wad1InternalSignatureBytes))
        {
          result = WadType.Internal;
        }
        else if (WadDirectoryReader.IsValidSignature(buffer, WadConstants.Wad1PatchSignatureBytes))
        {
          result = WadType.Patch;
        }
        else if (WadDirectoryReader.IsValidSignature(buffer, WadConstants.Wad2SignatureBytes))
        {
          result = WadType.Wad2;
        }
        else if (WadDirectoryReader.IsValidSignature(buffer, WadConstants.Wad3SignatureBytes))
        {
          result = WadType.Wad3;
        }
        else if (WadDirectoryReader.IsValidSignature(buffer, WadConstants.PackSignatureBytes))
        {
          result = WadType.Pack;
        }
        else
        {
          result = WadType.None;
        }
      }
      else
      {
        result = WadType.None;
      }

      stream.Position = position;

      BufferHelpers.Release(buffer);

      return result;
    }

    public static WadFile LoadFrom(string fileName)
    {
      return WadFile.LoadFrom(File.OpenRead(fileName));
    }

    public static WadFile LoadFrom(Stream stream)
    {
      WadFile result;

      result = new WadFile();
      result.Load(stream);

      return result;
    }

    public WadLump AddFile(string name, string fileName)
    {
      WadLump lump;

      lump = new WadLump
      {
        Name = name,
        PendingFileName = fileName
      };

      _lumps.Add(lump);

      return lump;
    }

    public WadLump Find(string name)
    {
      return this.Find(name, 0);
    }

    public WadLump Find(string name, int start)
    {
      WadLump result;

      result = null;

      for (int i = start; i < _lumps.Count; i++)
      {
        WadLump lump;

        lump = _lumps[i];

        if (string.Equals(lump.Name, name))
        {
          result = lump;
          break;
        }
      }

      return result;
    }

    public WadLump[] FindAll(string name)
    {
      List<WadLump> lumps;
      WadLump lump;
      int index;

      lumps = new List<WadLump>();
      index = 0;

      while ((lump = this.Find(name, index)) != null)
      {
        index = lump.Index + 1;
        lumps.Add(lump);
      }

      return lumps.ToArray();
    }

    public void Load(Stream stream)
    {
      using (WadReader reader = new WadReader(stream, true))
      {
        WadLump lump;

        _inputStream = stream;
        _lumps.Clear();
        _lumps.Container = stream;
        _type = reader.Type;

        while ((lump = reader.GetNextLump()) != null)
        {
          _lumps.Add(lump);
        }
      }
    }

    public void Load(string fileName)
    {
      this.Load(File.OpenRead(fileName));
    }

    public void ReplaceFile(string name, string fileName)
    {
      WadLump[] lumps;

      lumps = this.FindAll(name);

      if (lumps.Length == 0)
      {
        throw new KeyNotFoundException(string.Format("Could not find lump '{0}'.", name));
      }

      if (lumps.Length > 1)
      {
        throw new InvalidOperationException(string.Format("More than one lump named '{0}' found.", name));
      }

      lumps[0].PendingFileName = fileName;
    }

    public void Save()
    {
      this.Save(_inputStream);
    }

    public void Save(Stream stream)
    {
      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnwriteableStream(stream, nameof(stream));
      Guard.ThrowIfUnseekableStream(stream, nameof(stream));

      using (Stream temp = this.GetTemporaryStream())
      {
        using (WadOutputStream output = new WadOutputStream(temp, _type))
        {
          for (int i = 0; i < _lumps.Count; i++)
          {
            WadLump lump;

            lump = _lumps[i];
            output.PutNextLump(lump);

            using (Stream input = lump.GetInputStream())
            {
              input.CopyTo(output);
            }
          }

          output.Flush();
        }

        stream.Position = 0;
        stream.SetLength(0);

        temp.Position = 0;
        temp.CopyTo(stream);
      }
    }

    #endregion Public Methods

    #region Private Methods

    private Stream GetTemporaryStream()
    {
      return this.ShouldUseFileStream() 
        ? new TemporaryFileStream() 
        : (Stream)new MemoryStream();
    }

    private bool ShouldUseFileStream()
    {
      bool result;
      long size;

      size = WadConstants.WadHeaderLength + (_lumps.Count * WadConstants.WadDirectoryEntrySize);
      result = false;

      for (int i = 0; i < _lumps.Count; i++)
      {
        WadLump lump;

        lump = _lumps[i];

        if (!string.IsNullOrEmpty(lump.PendingFileName))
        {
          size += new FileInfo(lump.PendingFileName).Length;
        }
        else
        {
          size += lump.Size;
        }

        if (size >= _maximumInMemorySize)
        {
          result = true;
          break;
        }
      }

      return result;
    }

    #endregion Private Methods
  }
}