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
  public sealed class WadDirectoryReader : IDirectoryReader
  {
    #region Private Fields

    private readonly WadFormat _format;

    #endregion Private Fields

    #region Public Constructors

    public WadDirectoryReader(WadFormat format)
    {
      Guard.ThrowIfNull(format, nameof(format));

      _format = format;
    }

    public WadDirectoryReader(WadType type)
      : this(WadFormat.GetFormat(type))
    {
    }

    #endregion Public Constructors

    #region Public Methods

    public WadLump ReadEntry(Stream stream)
    {
      WadLump result;
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));

      buffer = this.ReadBuffer(stream, _format.DirectoryEntryLength);

      result = new WadLump
      {
        Offset = WordHelpers.GetInt32Le(buffer, _format.DirectoryEntryDataOffset),
        Size = WordHelpers.GetInt32Le(buffer, _format.DirectoryEntrySizeOffset),
        Name = CharHelpers.GetSafeName(buffer, _format.DirectoryEntryNameOffset, _format.DirectoryEntryNameLength),
      };

      if ((_format.Flags & WadFormatFlag.CompressionMode) != 0)
      {
        result.CompressionMode = buffer[_format.DirectoryEntryCompressionModeOffset];
        result.UncompressedSize = WordHelpers.GetInt32Le(buffer, _format.DirectoryEntryUncompressedSizeOffset);
      }
      else
      {
        result.UncompressedSize = result.Size;
      }

      if ((_format.Flags & WadFormatFlag.FileType) != 0)
      {
        result.Type = buffer[_format.DirectoryEntryFileTypeOffset];
      }

      BufferHelpers.Release(buffer);

      return result;
    }

    public DirectoryHeader ReadHeader(Stream stream)
    {
      DirectoryHeader result;
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));

      buffer = this.ReadBuffer(stream, _format.HeaderLength);

      if (this.IsValidSignature(buffer))
      {
        WadType type;
        int directoryStart;
        int lumpCount;

        type = _format.Type;
        directoryStart = WordHelpers.GetInt32Le(buffer, _format.HeaderDirectoryOffset);
        lumpCount = (_format.Flags & WadFormatFlag.DirectorySize) == 0
          ? WordHelpers.GetInt32Le(buffer, _format.HeaderCountOffset)
          : WordHelpers.GetInt32Le(buffer, _format.HeaderCountOffset) / _format.DirectoryEntryLength;

        result = new DirectoryHeader(type, directoryStart, lumpCount);
      }
      else
      {
        result = DirectoryHeader.Empty;
      }

      BufferHelpers.Release(buffer);

      return result;
    }

    #endregion Public Methods

    #region Private Methods

    internal static bool IsValidSignature(byte[] buffer, byte[] signature)
    {
      bool result;

      result = true;

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

    public int DirectoryEntrySize => _format.DirectoryEntryLength;

    private bool IsValidSignature(byte[] buffer) => WadDirectoryReader.IsValidSignature(buffer, _format.SignatureBytes);

    private byte[] ReadBuffer(Stream stream, byte length)
    {
      byte[] buffer;

      buffer = BufferHelpers.GetBuffer(length);

      if (stream.Read(buffer, 0, length) != length)
      {
        throw new InvalidDataException("Failed to fill data buffer.");
      }

      return buffer;
    }

    #endregion Private Methods
  }
}