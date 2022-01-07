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

    public const byte WadDirectoryEntrySize = 16;

    public const byte WadHeaderCountOffset = 4;

    public const byte WadHeaderDirectoryOffset = 8;

    public const byte WadHeaderLength = 12;

    #endregion Public Fields
  }
}