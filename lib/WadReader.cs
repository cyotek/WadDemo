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
using System.IO;

namespace Cyotek.Data
{
  public class WadReader : IDisposable
  {
    #region Private Fields

    private readonly int _directoryStart;

    private readonly bool _keepOpen;

    private readonly int _lumpCount;

    private readonly IDirectoryReader _reader;

    private readonly Stream _stream;

    private readonly WadType _type;

    private bool _disposedValue;

    private int _lumpIndex;

    #endregion Private Fields

    #region Public Constructors

    public WadReader(Stream stream)
      : this(stream, false)
    {
    }

    public WadReader(Stream stream, bool keepOpen)
    {
      WadType type;
      DirectoryHeader header;

      type = WadFile.GetFormat(stream);

      _reader = new WadDirectoryReader(type);
      header = _reader.ReadHeader(stream);

      _type = header.Type;
      _lumpCount = header.EntryCount;
      _directoryStart = header.DirectoryOffset;

      _keepOpen = keepOpen;
      _stream = stream;
      _lumpIndex = 0;
    }

    #endregion Public Constructors

    #region Public Properties

    public int Count => _lumpCount;

    public int DirectoryStart => _directoryStart;

    public WadType Type => _type;

    #endregion Public Properties

    #region Public Methods

    public void Dispose()
    {
      this.Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    public WadLump GetNextLump()
    {
      WadLump lump;

      if (_lumpIndex < _lumpCount)
      {
        int offset;

        offset = _directoryStart + (_lumpIndex * _reader.DirectoryEntrySize);

        _stream.Position = offset;

        lump = _reader.ReadEntry(_stream);

        if (lump == null)
        {
          throw new InvalidDataException("Failed to read directory entry.");
        }

        lump.Index = _lumpIndex;
        lump.SetContainer(_stream);

        _lumpIndex++;

        _stream.Position = lump.Offset;
      }
      else
      {
        lump = null;
      }

      return lump;
    }

    #endregion Public Methods

    #region Protected Methods

    protected virtual void Dispose(bool disposing)
    {
      if (!_disposedValue)
      {
        if (disposing && !_keepOpen)
        {
          _stream.Dispose();
        }

        _disposedValue = true;
      }
    }

    #endregion Protected Methods
  }
}