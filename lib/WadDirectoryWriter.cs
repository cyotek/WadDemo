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
  public abstract class WadDirectoryWriter : IDirectoryWriter
  {
    #region Public Properties

    public abstract WadType Type { get; }

    #endregion Public Properties

    #region Protected Properties

    protected abstract byte DirectoryEntryCompressionModeOffset { get; }

    protected abstract byte DirectoryEntryDataOffset { get; }

    protected abstract byte DirectoryEntryFileTypeOffset { get; }

    protected abstract byte DirectoryEntryLength { get; }

    protected abstract byte DirectoryEntryNameLength { get; }

    protected abstract byte DirectoryEntryNameOffset { get; }

    protected abstract byte DirectoryEntrySizeOffset { get; }

    protected abstract byte DirectoryEntryUncompressedSizeOffset { get; }

    protected abstract byte HeaderCountOffset { get; }

    protected abstract byte HeaderDirectoryOffset { get; }

    protected abstract byte HeaderLength { get; }

    protected abstract byte[] SignatureBytes { get; }

    #endregion Protected Properties

    #region Public Methods

    public virtual void WriteEntry(Stream stream, WadLump directoryEntry)
    {
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnwriteableStream(stream, nameof(stream));

      buffer = BufferHelpers.GetBuffer(this.DirectoryEntryLength);

      this.SetDirectoryEntryName(buffer, directoryEntry);
      this.SetDirectoryEntryDataOffset(buffer, directoryEntry);
      this.SetDirectoryEntrySize(buffer, directoryEntry);
      this.SetDirectoryEntryUncompressedSize(buffer, directoryEntry);
      this.SetDirectoryEntryCompressionMode(buffer, directoryEntry);
      this.SetDirectoryEntryFileType(buffer, directoryEntry);

      stream.Write(buffer, 0, this.DirectoryEntryLength);
    }

    public virtual void WriteHeader(Stream stream, DirectoryHeader directoryHeader)
    {
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnwriteableStream(stream, nameof(stream));
      Guard.ThrowIfUnexpectedType(this.Type, directoryHeader.Type);

      buffer = BufferHelpers.GetBuffer(this.HeaderLength);

      this.SetSignature(buffer);
      this.SetHeaderDirectoryOffset(buffer, directoryHeader);
      this.SetHeaderCount(buffer, directoryHeader);

      stream.Write(buffer, 0, this.HeaderLength);
    }

    #endregion Public Methods

    #region Protected Methods

    protected virtual void SetDirectoryEntryCompressionMode(byte[] buffer, WadLump directoryEntry)
    {
      buffer[this.DirectoryEntryCompressionModeOffset] = directoryEntry.CompressionMode;
    }

    protected virtual void SetDirectoryEntryDataOffset(byte[] buffer, WadLump directoryEntry)
    {
      WordHelpers.PutInt32Le(directoryEntry.Offset, buffer, this.DirectoryEntryDataOffset);
    }

    protected virtual void SetDirectoryEntryFileType(byte[] buffer, WadLump directoryEntry)
    {
      buffer[this.DirectoryEntryFileTypeOffset] = directoryEntry.Type;
    }

    protected virtual void SetDirectoryEntryName(byte[] buffer, WadLump directoryEntry)
    {
      CharHelpers.WriteName(directoryEntry.Name, buffer, this.DirectoryEntryNameOffset, this.DirectoryEntryNameLength);
    }

    protected virtual void SetDirectoryEntrySize(byte[] buffer, WadLump directoryEntry)
    {
      WordHelpers.PutInt32Le(directoryEntry.Size, buffer, this.DirectoryEntrySizeOffset);
    }

    protected virtual void SetDirectoryEntryUncompressedSize(byte[] buffer, WadLump directoryEntry)
    {
      WordHelpers.PutInt32Le(directoryEntry.UncompressedSize, buffer, this.DirectoryEntryUncompressedSizeOffset);
    }

    protected virtual void SetHeaderCount(byte[] buffer, DirectoryHeader directoryHeader)
    {
      WordHelpers.PutInt32Le(directoryHeader.EntryCount, buffer, this.HeaderCountOffset);
    }

    protected virtual void SetHeaderDirectoryOffset(byte[] buffer, DirectoryHeader directoryHeader)
    {
      WordHelpers.PutInt32Le(directoryHeader.DirectoryOffset, buffer, this.HeaderDirectoryOffset);
    }

    protected virtual void SetSignature(byte[] buffer)
    {
      byte[] signature;

      signature = this.SignatureBytes;

      for (int i = 0; i < signature.Length; i++)
      {
        buffer[i] = signature[i];
      }
    }

    #endregion Protected Methods
  }
}