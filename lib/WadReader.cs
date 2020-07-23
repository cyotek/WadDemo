using System;
using System.IO;
using System.Text;

namespace Cyotek.Data.Wad
{
  public class WadReader : IDisposable
  {
    #region Private Fields

    private readonly byte[] _buffer;

    private readonly int _directoryStart;

    private readonly bool _keepOpen;

    private readonly int _lumpCount;

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
      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));
      Guard.ThrowIfUnseekableStream(stream, nameof(stream));

      _buffer = new byte[WadConstants.DirectoryHeaderLength];

      if (stream.Read(_buffer, 0, WadConstants.WadHeaderLength) != WadConstants.WadHeaderLength)
      {
        throw new InvalidDataException("Failed to read header.");
      }

      if (!this.IsWadSignature(_buffer))
      {
        throw new InvalidDataException("Stream does not appear to be a WAD file.");
      }

      _type = _buffer[0] == 'I' ? WadType.Internal : WadType.Patch;
      _lumpCount = WordHelpers.GetInt32Le(_buffer, WadConstants.LumpCountOffset);
      _directoryStart = WordHelpers.GetInt32Le(_buffer, WadConstants.DirectoryStartOffset);

      _keepOpen = keepOpen;
      _stream = stream;
      _lumpIndex = 0;
    }

    #endregion Public Constructors

    #region Public Properties

    public int Count
    {
      get { return _lumpCount; }
    }

    public int DirectoryStart
    {
      get { return _directoryStart; }
    }

    public WadType Type
    {
      get { return _type; }
    }

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

        offset = _directoryStart + (_lumpIndex * WadConstants.DirectoryHeaderLength);

        _stream.Position = offset;

        if (_stream.Read(_buffer, 0, WadConstants.DirectoryHeaderLength) != WadConstants.DirectoryHeaderLength)
        {
          throw new InvalidDataException("Failed to read directory entry.");
        }

        lump = new WadLump
        {
          Offset = WordHelpers.GetInt32Le(_buffer, 0),
          Size = WordHelpers.GetInt32Le(_buffer, 4),
          Name = this.GetSafeLumpName(_buffer),
          Index = _lumpIndex
        };

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

    #region Private Methods

    private string GetSafeLumpName(byte[] entry)
    {
      int length;

      length = 0;

      for (int i = WadConstants.DirectoryHeaderLength; i > WadConstants.LumpNameOffset; i--)
      {
        if (entry[i - 1] != '\0')
        {
          length = i - 8;
          break;
        }
      }

      return length > 0
         ? Encoding.ASCII.GetString(entry, WadConstants.LumpNameOffset, length)
         : null;
    }

    private bool IsWadSignature(byte[] buffer)
    {
      return (buffer[0] == 'I' || buffer[0] == 'P')
        && buffer[1] == 'W'
        && buffer[2] == 'A'
        && buffer[3] == 'D';
    }

    #endregion Private Methods
  }
}