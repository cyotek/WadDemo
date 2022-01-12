// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

namespace Cyotek.Data
{
  public readonly struct DirectoryHeader
  {
    #region Public Fields

    public static readonly DirectoryHeader Empty = new DirectoryHeader();

    #endregion Public Fields

    #region Private Fields

    private readonly int _directoryOffset;

    private readonly int _entryCount;

    private readonly WadType _type;

    #endregion Private Fields

    #region Public Constructors

    public DirectoryHeader(WadType type, int directoryOffset, int entryCount)
    {
      _type = type;
      _directoryOffset = directoryOffset;
      _entryCount = entryCount;
    }

    #endregion Public Constructors

    #region Public Properties

    public int DirectoryOffset => _directoryOffset;

    public int EntryCount => _entryCount;

    public WadType Type => _type;

    #endregion Public Properties
  }
}