// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;

namespace Cyotek.Data
{
  public sealed class Wad1InternalDirectoryWriter : WadDirectoryWriter
  {
    #region Public Fields

    public static readonly Wad1InternalDirectoryWriter Default = new Wad1InternalDirectoryWriter();

    #endregion Public Fields

    #region Public Properties

    public override WadType Type => WadType.Internal;

    #endregion Public Properties

    #region Protected Properties

    protected override byte DirectoryEntryCompressionModeOffset => throw new NotSupportedException();

    protected override byte DirectoryEntryDataOffset => WadConstants.LumpStartOffset;

    protected override byte DirectoryEntryFileTypeOffset => throw new NotSupportedException();

    protected override byte DirectoryEntryLength => WadConstants.WadDirectoryEntrySize;

    protected override byte DirectoryEntryNameLength => WadConstants.LumpNameLength;

    protected override byte DirectoryEntryNameOffset => WadConstants.LumpNameOffset;

    protected override byte DirectoryEntrySizeOffset => WadConstants.LumpSizeOffset;

    protected override byte DirectoryEntryUncompressedSizeOffset => throw new NotSupportedException();

    protected override byte HeaderCountOffset => WadConstants.WadHeaderCountOffset;

    protected override byte HeaderDirectoryOffset => WadConstants.WadHeaderDirectoryOffset;

    protected override byte HeaderLength => WadConstants.WadHeaderLength;

    protected override byte[] SignatureBytes => WadConstants.Wad1InternalSignatureBytes;

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

    #endregion Protected Methods
  }
}