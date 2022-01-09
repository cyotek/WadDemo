﻿// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;

// Uses information from
// https://www.gamers.org/dEngine/quake/spec/quake-spec34/qkspec_3.htm#CPAKF

namespace Cyotek.Data
{
  public sealed class PackDirectoryReader : WadDirectoryReader
  {
    #region Public Fields

    public static readonly PackDirectoryReader Default = new PackDirectoryReader();

    #endregion Public Fields

    #region Protected Properties

    protected override byte DirectoryEntryCompressionModeOffset => throw new NotSupportedException();

    protected override byte DirectoryEntryDataOffset => WadConstants.PackDirectoryEntryStartOffset;

    protected override byte DirectoryEntryFileTypeOffset => throw new NotSupportedException();

    protected override byte DirectoryEntryLength => WadConstants.PackDirectoryEntrySize;

    protected override byte DirectoryEntryNameLength => WadConstants.PackDirectoryEntryNameLength;

    protected override byte DirectoryEntryNameOffset => WadConstants.PackDirectoryEntryNameOffset;

    protected override byte DirectoryEntrySizeOffset => WadConstants.PackDirectoryEntrySizeOffset;

    protected override byte DirectoryEntryUncompressedSizeOffset => throw new NotSupportedException();

    protected override byte HeaderCountOffset => WadConstants.PackHeaderCountOffset;

    protected override byte HeaderDirectoryOffset => WadConstants.PackHeaderDirectoryOffset;

    protected override byte HeaderLength => WadConstants.PackHeaderLength;

    protected override byte[] SignatureBytes => WadConstants.PackSignatureBytes;

    #endregion Protected Properties

    #region Protected Methods

    protected override byte GetCompressionMode(byte[] buffer) => 0;

    protected override int GetDirectoryEntryCount(byte[] buffer)
    {
      return WordHelpers.GetInt32Le(buffer, this.HeaderCountOffset) / this.DirectoryEntryLength;
    }

    protected override int GetDirectoryEntryUncompressedSize(byte[] buffer) => this.GetDirectoryEntrySize(buffer);

    protected override byte GetFileType(byte[] buffer) => 0;

    protected override WadType GetType(byte[] buffer) => WadType.Pack;

    #endregion Protected Methods
  }
}