// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using CommandLine;

namespace Cyotek.Tools.WadInfo.Verbs
{
  [Verb("create", HelpText = "Create WAD files")]
  internal sealed class CreateVerbOptions
  {
    #region Public Properties

    [Value(0, MetaName = "Command file", Required = true)]
    public string FileName { get; set; }

    #endregion Public Properties
  }
}