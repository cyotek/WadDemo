using CommandLine;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful? 
// https://www.paypal.me/cyotek

namespace Cyotek.Tools.WadInfo.Verbs
{
  internal abstract class WadVerbOptions
  {
    #region Public Properties

    [Value(0, MetaName = "WAD file", Required = true)]
    public string FileName { get; set; }

    #endregion Public Properties
  }
}