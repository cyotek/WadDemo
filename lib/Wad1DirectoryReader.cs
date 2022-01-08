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
  public sealed class Wad1DirectoryReader : WadDirectoryReader
  {
    #region Public Fields

    public static readonly Wad1DirectoryReader Default = new Wad1DirectoryReader();

    #endregion Public Fields

    #region Protected Properties

    protected override byte DirectoryEntryDataOffset => WadConstants.LumpStartOffset;

    protected override byte DirectoryEntryLength => WadConstants.WadDirectoryEntrySize;

    protected override byte DirectoryEntryNameLength => WadConstants.LumpNameLength;

    protected override byte DirectoryEntryNameOffset => WadConstants.LumpNameOffset;

    protected override byte DirectoryEntrySizeOffset => WadConstants.LumpSizeOffset;

    protected override byte DirectoryEntryUncompressedSizeOffset => throw new NotSupportedException();

    protected override byte HeaderCountOffset => WadConstants.WadHeaderCountOffset;

    protected override byte HeaderDirectoryOffset => WadConstants.WadHeaderDirectoryOffset;

    protected override byte HeaderLength => WadConstants.WadHeaderLength;

    protected override byte[] SignatureBytes => throw new NotSupportedException();

    #endregion Protected Properties

    #region Protected Methods

    protected override int GetDirectoryEntryUncompressedSize(byte[] buffer) => this.GetDirectoryEntrySize(buffer);

    protected override WadType GetType(byte[] buffer)
    {
      return buffer[0] == 'I'
          ? WadType.Internal
          : WadType.Patch;
    }

    protected override bool IsValidSignature(byte[] buffer)
    {
      return (buffer[0] == 'I' || buffer[0] == 'P')
                   && buffer[1] == 'W'
                   && buffer[2] == 'A'
                   && buffer[3] == 'D';
    }

    #endregion Protected Methods
  }
}