// Reading DOOM WAD files
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
  public sealed class WadDirectoryWriter : IDirectoryWriter
  {
    #region Private Fields

    private readonly WadFormat _format;

    #endregion Private Fields

    #region Public Constructors

    public WadDirectoryWriter(WadFormat format)
    {
      Guard.ThrowIfNull(format, nameof(format));

      _format = format;
    }

    public WadDirectoryWriter(WadType type)
      : this(WadFormat.GetFormat(type))
    {
    }

    #endregion Public Constructors

    #region Public Properties

    public WadType Type => _format.Type;

    #endregion Public Properties

    #region Public Methods

    public void WriteEntry(Stream stream, WadLump directoryEntry)
    {
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnwriteableStream(stream, nameof(stream));

      buffer = BufferHelpers.GetBuffer(_format.DirectoryEntryLength);

      CharHelpers.WriteName(directoryEntry.Name, buffer, _format.DirectoryEntryNameOffset, _format.DirectoryEntryNameLength);
      WordHelpers.PutInt32Le(directoryEntry.Offset, buffer, _format.DirectoryEntryDataOffset);
      WordHelpers.PutInt32Le(directoryEntry.Size, buffer, _format.DirectoryEntrySizeOffset);

      if ((_format.Flags & WadFormatFlag.CompressionMode) != 0)
      {
        buffer[_format.DirectoryEntryCompressionModeOffset] = directoryEntry.CompressionMode;
        WordHelpers.PutInt32Le(directoryEntry.UncompressedSize, buffer, _format.DirectoryEntryUncompressedSizeOffset);
      }

      if ((_format.Flags & WadFormatFlag.FileType) != 0)
      {
        buffer[_format.DirectoryEntryFileTypeOffset] = directoryEntry.Type;
      }

      stream.Write(buffer, 0, _format.DirectoryEntryLength);
    }

    public void WriteHeader(Stream stream, DirectoryHeader directoryHeader)
    {
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnwriteableStream(stream, nameof(stream));
      Guard.ThrowIfUnexpectedType(_format.Type, directoryHeader.Type);

      buffer = BufferHelpers.GetBuffer(_format.HeaderLength);

      this.SetSignature(buffer);
      WordHelpers.PutInt32Le(directoryHeader.DirectoryOffset, buffer, _format.HeaderDirectoryOffset);
      if ((_format.Flags & WadFormatFlag.DirectorySize) == 0)
      {
        WordHelpers.PutInt32Le(directoryHeader.EntryCount, buffer, _format.HeaderCountOffset);
      }
      else
      {
        WordHelpers.PutInt32Le(directoryHeader.EntryCount * _format.DirectoryEntryLength, buffer, _format.HeaderCountOffset);
      }

      stream.Write(buffer, 0, _format.HeaderLength);
    }

    #endregion Public Methods

    #region Private Methods

    private void SetSignature(byte[] buffer)
    {
      byte[] signature;

      signature = _format.SignatureBytes;

      for (int i = 0; i < signature.Length; i++)
      {
        buffer[i] = signature[i];
      }
    }

    #endregion Private Methods
  }
}