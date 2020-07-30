using System;
using System.Collections.Generic;
using System.IO;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Data.Wad
{
  public class WadFile
  {
    #region Private Fields

    private const int _maximumInMemorySize = 1048576 * 100;

    private Stream _inputStream;

    private WadLumpCollection _lumps;

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

    public Stream InputStream
    {
      get { return _inputStream; }
    }

    public WadLumpCollection Lumps
    {
      get { return _lumps; }
    }

    public WadType Type
    {
      get { return _type; }
      set { _type = value; }
    }

    #endregion Public Properties

    #region Public Methods

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

    public void AddFile(string name, string fileName)
    {
      _lumps.Add(new WadLump
      {
        Name = name,
        PendingFileName = fileName
      });
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
            output.PutNextLump(lump.Name);

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
      return this.ShouldUseFileStream() ? new TemporaryFileStream() : (Stream)new MemoryStream();
    }

    private bool ShouldUseFileStream()
    {
      bool result;
      long size;

      size = WadConstants.WadHeaderLength + (_lumps.Count * WadConstants.DirectoryHeaderLength);
      result = false;

      for (int i = 0; i < _lumps.Count; i++)
      {
        WadLump lump;

        lump = _lumps[i];

        if (!string.IsNullOrEmpty(lump.PendingFileName) && File.Exists(lump.PendingFileName))
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