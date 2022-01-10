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
  [Flags]
  public enum WadFormatFlag
  {
    None = 0,

    DirectorySize = 1,

    CompressionMode = 2,

    FileType = 4
  }
}