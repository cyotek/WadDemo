using System;
using System.IO;

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
        if (value < 0 || value > _length)
        {
          throw new ArgumentOutOfRangeException(nameof(value), value, "Value outside of stream range.");
        }

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

      switch (origin)
      {
        case SeekOrigin.Begin:
          value = offset;
          break;

        case SeekOrigin.Current:
          value = _position + offset;
          break;

        case SeekOrigin.End:
          value = _length - offset;
          break;

        default:
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