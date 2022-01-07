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
  internal class ExtractOptions
  {
    #region Private Fields

    private bool _createIndex;

    private ExtractMode _extractMode;

    private bool _openExplorerWindow;

    private ExtractOverwriteMode _overwriteMode;

    private string _path;

    #endregion Private Fields

    #region Public Properties

    public bool CreateIndex
    {
      get => _createIndex;
      set => _createIndex = value;
    }

    public ExtractMode ExtractMode
    {
      get => _extractMode;
      set => _extractMode = value;
    }

    public bool OpenExplorerWindow
    {
      get => _openExplorerWindow;
      set => _openExplorerWindow = value;
    }

    public ExtractOverwriteMode OverwriteMode
    {
      get => _overwriteMode;
      set => _overwriteMode = value;
    }

    public string Path
    {
      get => _path;
      set => _path = value;
    }

    #endregion Public Properties
  }
}