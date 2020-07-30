// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Data.Wad
{
  internal static class WadConstants
  {
    #region Public Fields

    public const byte DirectoryHeaderLength = 16;

    public const byte DirectoryStartOffset = 8;

    public const byte LumpCountOffset = 4;

    public const byte LumpNameLength = 8;

    public const byte LumpNameOffset = 8;

    public const byte LumpSizeOffset = 4;

    public const byte LumpStartOffset = 0;

    public const byte WadHeaderLength = 12;

    #endregion Public Fields
  }
}