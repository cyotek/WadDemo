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
// https://www.gamers.org/dEngine/quake/spec/quake-spec34/qkspec_3.htm#CPAKF

namespace Cyotek.Data
{
  public sealed class PackDirectoryReader : IDirectoryReader
  {
    #region Public Fields

    public static readonly PackDirectoryReader Default = new PackDirectoryReader();

    #endregion Public Fields

    #region Public Methods

    public WadLump ReadEntry(Stream stream)
    {
      WadLump result;
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));

#if NETCOREAPP2_1_OR_GREATER
      buffer = System.Buffers.ArrayPool<byte>.Shared.Rent(WadConstants.PackDirectoryEntrySize);
#else
      buffer = new byte[WadConstants.PackDirectoryEntrySize];
#endif

      if (stream.Read(buffer, 0, WadConstants.PackDirectoryEntrySize) != WadConstants.PackDirectoryEntrySize)
      {
        throw new InvalidDataException("Failed to read directory entry.");
      }

      result = new WadLump
      {
        Name = CharHelpers.GetSafeName(buffer, WadConstants.PackDirectoryEntryNameOffset, WadConstants.PackDirectoryEntryNameLength),
        Offset = WordHelpers.GetInt32Le(buffer, WadConstants.PackDirectoryEntryStartOffset),
        Size = WordHelpers.GetInt32Le(buffer, WadConstants.PackDirectoryEntrySizeOffset),
        UncompressedSize = WordHelpers.GetInt32Le(buffer, WadConstants.PackDirectoryEntrySizeOffset)
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
      buffer = System.Buffers.ArrayPool<byte>.Shared.Rent(WadConstants.PackHeaderLength);
#else
      buffer = new byte[WadConstants.PackHeaderLength];
#endif

      if (stream.Read(buffer, 0, WadConstants.PackHeaderLength) != WadConstants.PackHeaderLength)
      {
        throw new InvalidDataException("Failed to read header.");
      }

      if (PackDirectoryReader.IsPackSignature(buffer))
      {
        int directoryStart;
        int lumpCount;

        directoryStart = WordHelpers.GetInt32Le(buffer, WadConstants.PackHeaderDirectoryOffset);
        lumpCount = WordHelpers.GetInt32Le(buffer, WadConstants.PackHeaderCountOffset) / WadConstants.PackDirectoryEntrySize;

        result = new DirectoryHeader(WadType.Pack, directoryStart, lumpCount);
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

    private static bool IsPackSignature(byte[] buffer)
    {
      return buffer[0] == 'P'
             && buffer[1] == 'A'
             && buffer[2] == 'C'
             && buffer[3] == 'K';
    }

    #endregion Private Methods
  }
}