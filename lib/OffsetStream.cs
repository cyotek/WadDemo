using System;
using System.IO;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Data.Wad
{
  internal sealed class OffsetStream : Stream
  {
    #region Private Fields

    private readonly int _length;

    private readonly int _start;

    private readonly Stream _stream;

    private long _position;

    #endregion Private Fields

    #region Public Constructors

    public OffsetStream(Stream source, int start, int length)
    {
      Guard.ThrowIfNull(source, nameof(source));
      Guard.ThrowIfUnreadableStream(source, nameof(source));
      Guard.ThrowIfUnseekableStream(source, nameof(source));

      _stream = source;
      _start = start;
      _length = length;
    }

    #endregion Public Constructors

    #region Public Properties

    public override bool CanRead
    {
      get { return true; }
    }

    public override bool CanSeek
    {
      get { return true; }
    }

    public override bool CanWrite
    {
      get { return false; }
    }

    public override long Length
    {
      get { return _length; }
    }

    public override long Position
    {
      get { return _position; }
      set
      {
        Guard.ThrowIfOutOfBounds(value, 0, _length, "Value outside of stream range.", nameof(value));

        _position = value;
      }
    }

    #endregion Public Properties

    #region Public Methods

    public override void Flush()
    {
      throw new NotSupportedException();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      if (_position + count > _length)
      {
        count = _length - (int)_position;
      }

      if (count > 0)
      {
        _stream.Position = _start + _position;
        _stream.Read(buffer, offset, count);
        _position += count;
      }

      return count;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      long value;

      if (origin == SeekOrigin.Begin)
      {
        value = offset;
      }
      else if (origin == SeekOrigin.Current)
      {
        value = _position + offset;
      }
      else if (origin == SeekOrigin.End)
      {
        value = _length - offset;
      }
      else
      {
        throw new ArgumentOutOfRangeException(nameof(origin), origin, "Invalid origin value.");
      }

      this.Position = value;

      return value;
    }

    public override void SetLength(long value)
    {
      throw new NotSupportedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      throw new NotSupportedException();
    }

    #endregion Public Methods
  }
}