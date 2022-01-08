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
  public abstract class WadDirectoryReader : IDirectoryReader
  {
    #region Protected Properties

    protected abstract byte DirectoryEntryDataOffset { get; }

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

    public WadLump ReadEntry(Stream stream)
    {
      WadLump result;
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));

      buffer = this.ReadBuffer(stream, this.DirectoryEntryLength);

      result = new WadLump
      {
        Offset = this.GetDirectoryEntryDataOffset(buffer),
        Size = this.GetDirectoryEntrySize(buffer),
        Name = this.GetDirectoryEntryName(buffer),
        UncompressedSize = this.GetDirectoryEntryUncompressedSize(buffer),
        Type = this.GetFileType(buffer),
        CompressionMode = this.GetCompressionMode(buffer),
      };

#if NETCOREAPP2_1_OR_GREATER
      System.Buffers.ArrayPool<byte>.Shared.Return(buffer);
#endif

      return result;
    }

    public DirectoryHeader ReadHeader(Stream stream)
    {
      DirectoryHeader result;
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));

      buffer = this.ReadBuffer(stream, this.HeaderLength);

      if (this.IsValidSignature(buffer))
      {
        WadType type;
        int directoryStart;
        int lumpCount;

        type = this.GetType(buffer);
        directoryStart = this.GetDirectoryStart(buffer);
        lumpCount = this.GetDirectoryEntryCount(buffer);

        result = new DirectoryHeader(type, directoryStart, lumpCount);
      }
      else
      {
        result = DirectoryHeader.Empty;
      }

#if NETCOREAPP2_1_OR_GREATER
      System.Buffers.ArrayPool<byte>.Shared.Return(buffer);
#endif

      return result;
    }

    #endregion Public Methods

    #region Protected Methods

    protected virtual byte GetCompressionMode(byte[] buffer) => 0;

    protected virtual int GetDirectoryEntryCount(byte[] buffer) => WordHelpers.GetInt32Le(buffer, this.HeaderCountOffset);

    protected virtual int GetDirectoryEntryDataOffset(byte[] buffer) => WordHelpers.GetInt32Le(buffer, this.DirectoryEntryDataOffset);

    protected virtual string GetDirectoryEntryName(byte[] buffer) => CharHelpers.GetSafeName(buffer, this.DirectoryEntryNameOffset, this.DirectoryEntryNameLength);

    protected virtual int GetDirectoryEntrySize(byte[] buffer) => WordHelpers.GetInt32Le(buffer, this.DirectoryEntrySizeOffset);

    protected virtual int GetDirectoryEntryUncompressedSize(byte[] buffer) => WordHelpers.GetInt32Le(buffer, this.DirectoryEntryUncompressedSizeOffset);

    protected virtual int GetDirectoryStart(byte[] buffer) => WordHelpers.GetInt32Le(buffer, this.HeaderDirectoryOffset);

    protected virtual byte GetFileType(byte[] buffer) => 0;

    protected abstract WadType GetType(byte[] buffer);

    protected virtual bool IsValidSignature(byte[] buffer)
    {
      bool result;
      byte[] signature;

      result = true;
      signature = this.SignatureBytes;

      for (int i = 0; i < signature.Length; i++)
      {
        if (buffer[i] != signature[i])
        {
          result = false;
          break;
        }
      }

      return result;
    }

    #endregion Protected Methods

    #region Private Methods

    private byte[] ReadBuffer(Stream stream, byte length)
    {
      byte[] buffer;

#if NETCOREAPP2_1_OR_GREATER
      buffer = System.Buffers.ArrayPool<byte>.Shared.Rent(length);
#else
      buffer = new byte[length];
#endif

      if (stream.Read(buffer, 0, length) != length)
      {
        throw new InvalidDataException("Failed to fill data buffer.");
      }

      return buffer;
    }

    #endregion Private Methods
  }
}