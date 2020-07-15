using System;
using System.Collections.Generic;
using System.IO;

namespace Cyotek.Data.Wad
{
  public class WadOutputStream : Stream
  {
    #region Private Fields

    private readonly List<WadLump> _lumps;

    private readonly Stream _output;

    private readonly long _start;

    private bool _writtenDirectory;

    #endregion Private Fields

    #region Public Constructors

    public WadOutputStream(Stream output)
      : this(output, WadType.Patch)
    {
    }

    public WadOutputStream(Stream output, WadType type)
    {
      byte[] buffer;

      if (output == null)
      {
        throw new ArgumentNullException(nameof(output));
      }

      if (!output.CanWrite)
      {
        throw new ArgumentException("Stream is not writable.", nameof(output));
      }

      if (!output.CanSeek)
      {
        throw new ArgumentException("Stream is not seekable.", nameof(output));
      }

      if (type < WadType.Internal || type > WadType.Patch)
      {
        throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid WAD type.");
      }

      _output = output;
      _start = output.Position;
      _lumps = new List<WadLump>();

      buffer = new byte[WadConstants.WadHeaderLength];

      buffer[0] = type == WadType.Internal ? (byte)'I' : (byte)'P';
      buffer[1] = (byte)'W';
      buffer[2] = (byte)'A';
      buffer[3] = (byte)'D';

      output.Write(buffer, 0, WadConstants.WadHeaderLength);
    }

    #endregion Public Constructors

    #region Public Properties

    public override bool CanRead
    {
      get { return false; }
    }

    public override bool CanSeek
    {
      get { return false; }
    }

    public override bool CanWrite
    {
      get { return true; }
    }

    public override long Length
    {
      get { return _output.Length; }
    }

    public override long Position
    {
      get { return _output.Position; }
      set { throw new NotSupportedException(); }
    }

    #endregion Public Properties

    #region Public Methods

    public override void Close()
    {
      if (!_writtenDirectory)
      {
        this.Flush();
      }

      base.Close();
    }

    public override void Flush()
    {
      if (!_writtenDirectory)
      {
        this.FinaliseLump();
        this.WriteDirectory();
      }

      _output.Flush();
    }

    public void PutNextEntry(string name)
    {
      if (string.IsNullOrEmpty(name))
      {
        throw new ArgumentNullException(nameof(name));
      }

      if (name.Length > 8)
      {
        throw new ArgumentOutOfRangeException(nameof(name), name.Length, "Name must be between 1 and 8 characters in length.");
      }

      if (_writtenDirectory)
      {
        throw new InvalidOperationException("Directory has been written.");
      }

      this.FinaliseLump();

      _lumps.Add(new WadLump
      {
        Name = name,
        Offset = (int)_output.Position
      });
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      throw new NotSupportedException();
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      throw new NotSupportedException();
    }

    public override void SetLength(long value)
    {
      throw new NotSupportedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      _output.Write(buffer, offset, count);
    }

    #endregion Public Methods

    #region Private Methods

    private void FinaliseLump()
    {
      if (_lumps.Count > 0)
      {
        WadLump lump;

        lump = _lumps[_lumps.Count - 1];

        lump.Size = (int)_output.Position - lump.Offset;
      }
    }

    private void WriteDirectory()
    {
      byte[] buffer;
      long position;

      buffer = new byte[WadConstants.DirectoryHeaderLength];
      position = _output.Position;

      // first update the header
      WordHelpers.PutInt32Le(_lumps.Count, buffer, 0);
      WordHelpers.PutInt32Le((int)position, buffer, 4);

      _output.Position = _start + 4;
      _output.Write(buffer, 0, 8);

      _output.Position = position;

      // now the directory entries
      for (int i = 0; i < _lumps.Count; i++)
      {
        WadLump lump;

        lump = _lumps[i];

        for (int j = 0; j < lump.Name.Length; j++)
        {
          buffer[WadConstants.LumpNameOffset + j] = (byte)lump.Name[j];
        }

        for (int j = lump.Name.Length; j < WadConstants.LumpNameLength; j++)
        {
          buffer[WadConstants.LumpNameOffset + j] = 0;
        }

        WordHelpers.PutInt32Le(lump.Offset, buffer, WadConstants.LumpStartOffset);
        WordHelpers.PutInt32Le(lump.Size, buffer, WadConstants.LumpSizeOffset);

        _output.Write(buffer, 0, buffer.Length);
      }

      _writtenDirectory = true;
    }

    #endregion Private Methods
  }
}