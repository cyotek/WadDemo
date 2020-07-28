using Cyotek.Data.Wad;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.Wad
{
  internal class ExtractResult
  {
    #region Private Fields

    private string _fileName;

    private WadLump _lump;

    #endregion Private Fields

    #region Public Constructors

    public ExtractResult()
    {
    }

    public ExtractResult(WadLump lump, string fileName)
    {
      _lump = lump;
      _fileName = fileName;
    }

    #endregion Public Constructors

    #region Public Properties

    public string FileName
    {
      get { return _fileName; }
      set { _fileName = value; }
    }

    public WadLump Lump
    {
      get { return _lump; }
      set { _lump = value; }
    }

    #endregion Public Properties
  }
}