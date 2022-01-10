// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

// PACK format from
// https://www.gamers.org/dEngine/quake/spec/quake-spec34/qkspec_3.htm#CPAKF

// WAD2 format from
// https://www.gamers.org/dEngine/quake/spec/quake-spec34/qkspec_7.htm

// WAD3 format from
// http://wiki.xentax.com/index.php/WAD_WAD3

using System;

namespace Cyotek.Data
{
  public class WadFormat
  {
    #region Private Fields

    private static readonly WadFormat _pack = new WadFormat
    {
      Type = WadType.Pack,
      DirectoryEntryDataOffset = WadConstants.PackDirectoryEntryStartOffset,
      DirectoryEntryLength = WadConstants.PackDirectoryEntrySize,
      DirectoryEntryNameLength = WadConstants.PackDirectoryEntryNameLength,
      DirectoryEntryNameOffset = WadConstants.PackDirectoryEntryNameOffset,
      DirectoryEntrySizeOffset = WadConstants.PackDirectoryEntrySizeOffset,
      HeaderCountOffset = WadConstants.PackHeaderCountOffset,
      HeaderDirectoryOffset = WadConstants.PackHeaderDirectoryOffset,
      HeaderLength = WadConstants.PackHeaderLength,
      SignatureBytes = WadConstants.PackSignatureBytes,
      Flags = WadFormatFlag.DirectorySize
    };

    private static readonly WadFormat _wad1Internal = new WadFormat
    {
      Type = WadType.Internal,
      DirectoryEntryDataOffset = WadConstants.LumpStartOffset,
      DirectoryEntryLength = WadConstants.WadDirectoryEntrySize,
      DirectoryEntryNameLength = WadConstants.LumpNameLength,
      DirectoryEntryNameOffset = WadConstants.LumpNameOffset,
      DirectoryEntrySizeOffset = WadConstants.LumpSizeOffset,
      HeaderCountOffset = WadConstants.WadHeaderCountOffset,
      HeaderDirectoryOffset = WadConstants.WadHeaderDirectoryOffset,
      HeaderLength = WadConstants.WadHeaderLength,
      SignatureBytes = WadConstants.Wad1InternalSignatureBytes
    };

    private static readonly WadFormat _wad1Patch = new WadFormat
    {
      Type = WadType.Patch,
      DirectoryEntryDataOffset = WadConstants.LumpStartOffset,
      DirectoryEntryLength = WadConstants.WadDirectoryEntrySize,
      DirectoryEntryNameLength = WadConstants.LumpNameLength,
      DirectoryEntryNameOffset = WadConstants.LumpNameOffset,
      DirectoryEntrySizeOffset = WadConstants.LumpSizeOffset,
      HeaderCountOffset = WadConstants.WadHeaderCountOffset,
      HeaderDirectoryOffset = WadConstants.WadHeaderDirectoryOffset,
      HeaderLength = WadConstants.WadHeaderLength,
      SignatureBytes = WadConstants.Wad1PatchSignatureBytes
    };

    private static readonly WadFormat _wad2 = new WadFormat
    {
      Type = WadType.Wad2,
      DirectoryEntryCompressionModeOffset = WadConstants.Wad2EntryCompressionModeOffset,
      DirectoryEntryDataOffset = WadConstants.Wad2EntryStartOffset,
      DirectoryEntryFileTypeOffset = WadConstants.Wad2EntryTypeOffset,
      DirectoryEntryLength = WadConstants.Wad2EntryLength,
      DirectoryEntryNameLength = WadConstants.Wad2EntryNameLength,
      DirectoryEntryNameOffset = WadConstants.Wad2EntryNameOffset,
      DirectoryEntrySizeOffset = WadConstants.Wad2EntrySizeOffset,
      DirectoryEntryUncompressedSizeOffset = WadConstants.Wad2EntryUncompressedSizeOffset,
      HeaderCountOffset = WadConstants.WadHeaderCountOffset,
      HeaderDirectoryOffset = WadConstants.WadHeaderDirectoryOffset,
      HeaderLength = WadConstants.WadHeaderLength,
      SignatureBytes = WadConstants.Wad2SignatureBytes,
      Flags = WadFormatFlag.CompressionMode | WadFormatFlag.FileType
    };

    private static readonly WadFormat _wad3 = new WadFormat
    {
      Type = WadType.Wad3,
      DirectoryEntryCompressionModeOffset = WadConstants.Wad3EntryCompressionModeOffset,
      DirectoryEntryDataOffset = WadConstants.Wad3EntryStartOffset,
      DirectoryEntryFileTypeOffset = WadConstants.Wad3EntryTypeOffset,
      DirectoryEntryLength = WadConstants.Wad3EntryLength,
      DirectoryEntryNameLength = WadConstants.Wad3EntryNameLength,
      DirectoryEntryNameOffset = WadConstants.Wad3EntryNameOffset,
      DirectoryEntrySizeOffset = WadConstants.Wad3EntrySizeOffset,
      DirectoryEntryUncompressedSizeOffset = WadConstants.Wad3EntryUncompressedSizeOffset,
      HeaderCountOffset = WadConstants.WadHeaderCountOffset,
      HeaderDirectoryOffset = WadConstants.WadHeaderDirectoryOffset,
      HeaderLength = WadConstants.WadHeaderLength,
      SignatureBytes = WadConstants.Wad3SignatureBytes,
      Flags = WadFormatFlag.CompressionMode | WadFormatFlag.FileType
    };

    #endregion Private Fields

    #region Public Properties

    public byte DirectoryEntryCompressionModeOffset { get; set; }

    public byte DirectoryEntryDataOffset { get; set; }

    public byte DirectoryEntryFileTypeOffset { get; set; }

    public byte DirectoryEntryLength { get; set; }

    public byte DirectoryEntryNameLength { get; set; }

    public byte DirectoryEntryNameOffset { get; set; }

    public byte DirectoryEntrySizeOffset { get; set; }

    public byte DirectoryEntryUncompressedSizeOffset { get; set; }

    public WadFormatFlag Flags { get; set; }

    public byte HeaderCountOffset { get; set; }

    public byte HeaderDirectoryOffset { get; set; }

    public byte HeaderLength { get; set; }

    public byte[] SignatureBytes { get; set; }

    public WadType Type { get; set; }

    #endregion Public Properties

    #region Internal Methods

    internal static WadFormat GetFormat(WadType type)
    {
      WadFormat result;

      switch (type)
      {
        case WadType.Internal:
          result = WadFormat._wad1Internal;
          break;

        case WadType.Patch:
          result = WadFormat._wad1Patch;
          break;

        case WadType.Wad2:
          result = WadFormat._wad2;
          break;

        case WadType.Wad3:
          result = WadFormat._wad3;
          break;

        case WadType.Pack:
          result = WadFormat._pack;
          break;

        default:
          throw new ArgumentOutOfRangeException(nameof(type), type, null);
      }

      return result;
    }

    #endregion Internal Methods
  }
}