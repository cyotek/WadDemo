﻿// Reading DOOM WAD files
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
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));

      buffer = new byte[WadConstants.DirectoryHeaderLength];

      if (stream.Read(buffer, 0, WadConstants.DirectoryHeaderLength) != WadConstants.DirectoryHeaderLength)
      {
        throw new InvalidDataException("Failed to read directory entry.");
      }

      return new WadLump
      {
        Offset = WordHelpers.GetInt32Le(buffer, 0),
        Size = WordHelpers.GetInt32Le(buffer, 4),
        Name = CharHelpers.GetSafeName(buffer)
      };
    }

    public DirectoryHeader ReadHeader(Stream stream)
    {
      DirectoryHeader result;
      byte[] buffer;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));

      buffer = new byte[WadConstants.DirectoryHeaderLength];

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
        directoryStart = WordHelpers.GetInt32Le(buffer, WadConstants.DirectoryStartOffset);
        lumpCount = WordHelpers.GetInt32Le(buffer, WadConstants.LumpCountOffset);

        result = new DirectoryHeader(type, directoryStart, lumpCount);
      }
      else
      {
        result = DirectoryHeader.Empty;
      }

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