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
  public class WadOutputStream : Stream
  {
    #region Private Fields

    private readonly List<WadLump> _lumps;

    private readonly Stream _output;

    private readonly long _start;

    private readonly IDirectoryWriter _writer;

    private bool _writtenDirectory;

    #endregion Private Fields

    #region Public Constructors

    public WadOutputStream(Stream output)
      : this(output, WadType.Patch)
    {
    }

    public WadOutputStream(Stream output, WadType type)
      : this(output, WadFormatRegistry.GetWriter(type))
    {
    }

    public WadOutputStream(Stream output, IDirectoryWriter writer)
    {
      Guard.ThrowIfNull(output, nameof(output));
      Guard.ThrowIfUnwriteableStream(output, nameof(output));
      Guard.ThrowIfUnseekableStream(output, nameof(output));
      Guard.ThrowIfNull(writer, nameof(writer));

      _output = output;
      _writer = writer;
      _start = output.Position;
      _lumps = new List<WadLump>();

      writer.WriteHeader(output, new DirectoryHeader(writer.Type, 0, 0));
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
      long position;

      position = _output.Position;

      // first update the header
      _output.Position = _start;
      _writer.WriteHeader(_output, new DirectoryHeader(_writer.Type, (int)position, _lumps.Count));
      _output.Position = position;

      // now the directory entries
      for (int i = 0; i < _lumps.Count; i++)
      {
        _writer.WriteEntry(_output, _lumps[i]);
      }

      _writtenDirectory = true;
    }

    #endregion Private Methods
  }
}