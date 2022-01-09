// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;

namespace Cyotek.Data
{
  public sealed class PackDirectoryWriter : WadDirectoryWriter
  {
    #region Public Fields

    public static readonly PackDirectoryWriter Default = new PackDirectoryWriter();

    #endregion Public Fields

    #region Public Properties

    public override WadType Type => WadType.Pack;

    #endregion Public Properties

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

    protected override void SetDirectoryEntryCompressionMode(byte[] buffer, WadLump directoryEntry)
    {
      // not supported
    }

    protected override void SetDirectoryEntryFileType(byte[] buffer, WadLump directoryEntry)
    {
      // not supported
    }

    protected override void SetDirectoryEntryUncompressedSize(byte[] buffer, WadLump directoryEntry)
    {
      // not supported
    }

    protected override void SetHeaderCount(byte[] buffer, DirectoryHeader directoryHeader)
    {
      WordHelpers.PutInt32Le(directoryHeader.EntryCount * WadConstants.PackDirectoryEntrySize, buffer, this.HeaderCountOffset);
    }

    #endregion Protected Methods
  }
}