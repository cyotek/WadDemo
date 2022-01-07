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
      Guard.ThrowIfNull(output, nameof(output));
      Guard.ThrowIfUnwriteableStream(output, nameof(output));
      Guard.ThrowIfUnseekableStream(output, nameof(output));
      Guard.ThrowIfOutOfBounds(type, WadType.Internal, WadType.Patch, "Invalid WAD type.", nameof(type));

      _output = output;
      _start = output.Position;
      _lumps = new List<WadLump>();

      this.WriteWadHeader(type);
    }

    #endregion Public Constructors

    #region Public Properties

    public override bool CanRead => false;

    public override bool CanSeek => false;

    public override bool CanWrite => true;

    public override long Length => _output.Length;

    public override long Position
    {
      get => _output.Position;
      set => throw new NotSupportedException();
    }

    #endregion Public Properties

    #region Public Methods

    public override void Flush()
    {
      if (!_writtenDirectory)
      {
        this.FinaliseLump();
        this.WriteDirectory();
      }

      _output.Flush();
    }

    public void PutNextLump(string name)
    {
      Guard.ThrowIfNullOrEmpty(name, nameof(name));
      Guard.ThrowIfOutOfBounds(name.Length, 1, WadConstants.LumpNameLength, "Name must be between 1 and 8 characters in length.", nameof(name));

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

    #region Protected Methods

    protected override void Dispose(bool disposing)
    {
      if (disposing && !_writtenDirectory)
      {
        this.Flush();
      }

      base.Dispose(disposing);
    }

    #endregion Protected Methods

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

    private void WriteWadHeader(WadType type)
    {
      byte[] buffer;

      buffer = new byte[WadConstants.WadHeaderLength];

      buffer[0] = type == WadType.Internal 
        ? (byte)'I' 
        : (byte)'P';
      buffer[1] = (byte)'W';
      buffer[2] = (byte)'A';
      buffer[3] = (byte)'D';

      _output.Write(buffer, 0, WadConstants.WadHeaderLength);
    }

    #endregion Private Methods
  }
}