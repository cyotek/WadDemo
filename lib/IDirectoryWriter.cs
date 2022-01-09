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
  public interface IDirectoryWriter
  {
    #region Public Properties

    WadType Type { get; }

    #endregion Public Properties

    #region Public Methods

    void WriteEntry(Stream stream, WadLump directoryEntry);

    void WriteHeader(Stream stream, DirectoryHeader directoryHeader);

    #endregion Public Methods
  }
}