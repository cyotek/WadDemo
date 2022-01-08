// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System.IO;

// Uses information from
// http://wiki.xentax.com/index.php/WAD_WAD3

namespace Cyotek.Data
{
  public sealed class Wad3DirectoryReader : IDirectoryReader
  {
    #region Public Fields

    public static readonly Wad3DirectoryReader Default = new Wad3DirectoryReader();

    #endregion Public Fields

    #region Public Methods

    public WadLump ReadEntry(Stream stream)
    {
      WadLump result;
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));

#if NETCOREAPP2_1_OR_GREATER
      buffer = System.Buffers.ArrayPool<byte>.Shared.Rent(WadConstants.Wad3EntryLength);
#else
      buffer = new byte[WadConstants.Wad3EntryLength];
#endif

      if (stream.Read(buffer, 0, WadConstants.Wad3EntryLength) != WadConstants.Wad3EntryLength)
      {
        throw new InvalidDataException("Failed to read directory entry.");
      }

      result = new WadLump
      {
        Offset = WordHelpers.GetInt32Le(buffer, WadConstants.Wad3EntryStartOffset),
        Size = WordHelpers.GetInt32Le(buffer, WadConstants.Wad3EntrySizeOffset),
        UncompressedSize = WordHelpers.GetInt32Le(buffer, WadConstants.Wad3EntryUncompressedSizeOffset),
        Type = buffer[WadConstants.Wad3EntryTypeOffset],
        CompressionMode = buffer[WadConstants.Wad3EntryCompressionModeOffset],
        Name = CharHelpers.GetSafeName(buffer, WadConstants.Wad3EntryNameOffset, WadConstants.Wad3EntryNameLength)
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

#if NETCOREAPP2_1_OR_GREATER
      buffer = System.Buffers.ArrayPool<byte>.Shared.Rent(WadConstants.WadHeaderLength);
#else
      buffer = new byte[WadConstants.WadHeaderLength];
#endif

      if (stream.Read(buffer, 0, WadConstants.WadHeaderLength) != WadConstants.WadHeaderLength)
      {
        throw new InvalidDataException("Failed to read header.");
      }

      if (Wad3DirectoryReader.IsWad3Signature(buffer))
      {
        WadType type;
        int directoryStart;
        int lumpCount;

        type = WadType.Wad3;
        directoryStart = WordHelpers.GetInt32Le(buffer, WadConstants.WadHeaderDirectoryOffset);
        lumpCount = WordHelpers.GetInt32Le(buffer, WadConstants.WadHeaderCountOffset);

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

    #region Private Methods

    private static bool IsWad3Signature(byte[] buffer)
    {
      return buffer[0] == 'W'
             && buffer[1] == 'A'
             && buffer[2] == 'D'
             && buffer[3] == '3';
    }

    #endregion Private Methods
  }
}