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
  public sealed class Wad1DirectoryReader : IDirectoryReader
  {
    #region Public Fields

    public static readonly Wad1DirectoryReader Default = new Wad1DirectoryReader();

    #endregion Public Fields

    #region Public Methods

    public WadLump ReadEntry(Stream stream)
    {
      WadLump result;
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));

#if NETCOREAPP2_1_OR_GREATER
      buffer = System.Buffers.ArrayPool<byte>.Shared.Rent(WadConstants.WadDirectoryEntrySize);
#else
      buffer = new byte[WadConstants.WadDirectoryEntrySize];
#endif

      if (stream.Read(buffer, 0, WadConstants.WadDirectoryEntrySize) != WadConstants.WadDirectoryEntrySize)
      {
        throw new InvalidDataException("Failed to read directory entry.");
      }

      result = new WadLump
      {
        Offset = WordHelpers.GetInt32Le(buffer, 0),
        Size = WordHelpers.GetInt32Le(buffer, 4),
        Name = CharHelpers.GetSafeName(buffer, WadConstants.LumpNameOffset, WadConstants.LumpNameLength)
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

      if (Wad1DirectoryReader.IsWadSignature(buffer))
      {
        WadType type;
        int directoryStart;
        int lumpCount;

        type = buffer[0] == 'I'
          ? WadType.Internal
          : WadType.Patch;
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

    private static bool IsWadSignature(byte[] buffer)
    {
      return (buffer[0] == 'I' || buffer[0] == 'P')
             && buffer[1] == 'W'
             && buffer[2] == 'A'
             && buffer[3] == 'D';
    }

    #endregion Private Methods
  }
}