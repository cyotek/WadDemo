// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

namespace Cyotek.Data
{
  internal static class WadConstants
  {
    #region Public Fields

    public const byte LumpNameLength = 8;

    public const byte LumpNameOffset = 8;

    public const byte LumpSizeOffset = 4;

    public const byte LumpStartOffset = 0;

    public const byte PackDirectoryEntryNameLength = 56;

    public const byte PackDirectoryEntryNameOffset = 0;

    public const byte PackDirectoryEntrySize = 64;

    public const byte PackDirectoryEntrySizeOffset = PackDirectoryEntryStartOffset + 4;

    public const byte PackDirectoryEntryStartOffset = PackDirectoryEntryNameLength;

    public const byte PackHeaderCountOffset = 8;

    public const byte PackHeaderDirectoryOffset = 4;

    public const byte PackHeaderLength = 12;

    public const byte Wad2EntryCompressionModeOffset = 13;

    public const byte Wad2EntryLength = 32;

    public const byte Wad2EntryNameLength = 16;

    public const byte Wad2EntryNameOffset = 16;

    public const byte Wad2EntrySizeOffset = 4;

    public const byte Wad2EntryStartOffset = 0;

    public const byte Wad2EntryTypeOffset = 12;

    public const byte Wad2EntryUncompressedSizeOffset = 8;

    public const byte Wad3EntryCompressionModeOffset = 13;

    public const byte Wad3EntryLength = 32;

    public const byte Wad3EntryNameLength = 16;

    public const byte Wad3EntryNameOffset = 16;

    public const byte Wad3EntrySizeOffset = 4;

    public const byte Wad3EntryStartOffset = 0;

    public const byte Wad3EntryTypeOffset = 12;

    public const byte Wad3EntryUncompressedSizeOffset = 8;

    public const byte WadDirectoryEntrySize = 16;

    public const byte WadHeaderCountOffset = 4;

    public const byte WadHeaderDirectoryOffset = 8;

    public const byte WadHeaderLength = 12;

    public static readonly byte[] PackSignatureBytes = { (byte)'P', (byte)'A', (byte)'C', (byte)'K' };

    public static readonly byte[] Wad1InternalSignatureBytes = { (byte)'I', (byte)'W', (byte)'A', (byte)'D' };

    public static readonly byte[] Wad1PatchSignatureBytes = { (byte)'P', (byte)'W', (byte)'A', (byte)'D' };

    public static readonly byte[] Wad2SignatureBytes = { (byte)'W', (byte)'A', (byte)'D', (byte)'2' };

    public static readonly byte[] Wad3SignatureBytes = { (byte)'W', (byte)'A', (byte)'D', (byte)'3' };

    #endregion Public Fields
  }
}