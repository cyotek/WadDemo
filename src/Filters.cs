﻿// Reading DOOM WAD files
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
  internal static class Filters
  {
    #region Public Fields

    public static readonly string AllFiles = "All Files (*.*)|*.*";

    public static readonly string Text = "Text Files (*.txt)|*.txt|" + AllFiles;

    public static readonly string Wad = "WAD Files (*.wad)|*.wad|" + AllFiles;

    #endregion Public Fields
  }
}