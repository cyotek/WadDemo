// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using CommandLine;

namespace Cyotek.Tools.WadInfo.Verbs
{
  [Verb("compare", HelpText = "Compare WAD files")]
  internal sealed class CompareVerbOptions
  {
    #region Public Properties

    [Value(0, MetaName = "First file to compare", Required = true)]
    public string FirstFileName { get; set; }

    [Value(1, MetaName = "Second file to compare", Required = true)]
    public string SecondFileName { get; set; }

    #endregion Public Properties
  }
}