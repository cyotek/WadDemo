﻿// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System.IO;

namespace Cyotek.Data
{
  internal sealed class TemporaryFileStream : Stream
  {
    #region Private Fields

    private readonly string _fileName;

    private readonly FileStream _stream;

    #endregion Private Fields

    #region Public Constructors

    public TemporaryFileStream()
    {
      _fileName = Path.GetTempFileName();
      _stream = File.Create(_fileName);
    }

    #endregion Public Constructors

    #region Public Properties

    public override bool CanRead => _stream.CanRead;

    public override bool CanSeek => _stream.CanSeek;

    public override bool CanWrite => _stream.CanWrite;

    public override long Length => _stream.Length;

    public override long Position
    {
      get => _stream.Position;
      set => _stream.Position = value;
    }

    #endregion Public Properties

    #region Public Methods

    public override void Flush()
    {
      _stream.Flush();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      return _stream.Read(buffer, offset, count);
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      return _stream.Seek(offset, origin);
    }

    public override void SetLength(long value)
    {
      _stream.SetLength(value);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      _stream.Write(buffer, offset, count);
    }

    #endregion Public Methods

    #region Protected Methods

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _stream.Dispose();
        if (File.Exists(_fileName))
        {
          File.Delete(_fileName);
        }

        base.Dispose(disposing);
      }
    }

    #endregion Protected Methods
  }
}