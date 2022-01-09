﻿// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

// Uses information from
// https://www.gamers.org/dEngine/quake/spec/quake-spec34/qkspec_7.htm

namespace Cyotek.Data
{
  public sealed class Wad2DirectoryReader : WadDirectoryReader
  {
    #region Public Fields

    public static readonly Wad2DirectoryReader Default = new Wad2DirectoryReader();

    #endregion Public Fields

    #region Protected Properties

    protected override byte DirectoryEntryCompressionModeOffset => WadConstants.Wad2EntryCompressionModeOffset;

    protected override byte DirectoryEntryDataOffset => WadConstants.Wad2EntryStartOffset;

    protected override byte DirectoryEntryFileTypeOffset => WadConstants.Wad2EntryTypeOffset;

    protected override byte DirectoryEntryLength => WadConstants.Wad2EntryLength;

    protected override byte DirectoryEntryNameLength => WadConstants.Wad2EntryNameLength;

    protected override byte DirectoryEntryNameOffset => WadConstants.Wad2EntryNameOffset;

    protected override byte DirectoryEntrySizeOffset => WadConstants.Wad2EntrySizeOffset;

    protected override byte DirectoryEntryUncompressedSizeOffset => WadConstants.Wad2EntryUncompressedSizeOffset;

    protected override byte HeaderCountOffset => WadConstants.WadHeaderCountOffset;

    protected override byte HeaderDirectoryOffset => WadConstants.WadHeaderDirectoryOffset;

    protected override byte HeaderLength => WadConstants.WadHeaderLength;

    protected override byte[] SignatureBytes => WadConstants.Wad2SignatureBytes;

    #endregion Protected Properties

    #region Protected Methods

    protected override WadType GetType(byte[] buffer) => WadType.Wad2;

    #endregion Protected Methods
  }
}