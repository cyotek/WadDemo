// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System.IO;

namespace Cyotek.Data
{
  public interface IDirectoryReader
  {
    #region Public Properties

    int DirectoryEntrySize { get; }

    #endregion Public Properties

    #region Public Methods

    WadLump ReadEntry(Stream stream);

    DirectoryHeader ReadHeader(Stream stream);

    #endregion Public Methods
  }
}