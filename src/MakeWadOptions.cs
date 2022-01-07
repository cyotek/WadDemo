using Cyotek.Data.Wad;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.Wad
{
  internal class MakeWadOptions
  {
    #region Private Fields

    private string _fileName;

    private string _indexFileName;

    private WadType _type;

    #endregion Private Fields

    #region Public Properties

    public string FileName
    {
      get => _fileName;
      set => _fileName = value;
    }

    public string IndexFileName
    {
      get => _indexFileName;
      set => _indexFileName = value;
    }

    public WadType Type
    {
      get => _type;
      set => _type = value;
    }

    #endregion Public Properties
  }
}