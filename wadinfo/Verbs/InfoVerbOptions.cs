using CommandLine;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files
// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Tools.WadInfo.Verbs
{
  [Verb("info", isDefault: true, HelpText = "Display WAD information")]
  internal class InfoVerbOptions : WadVerbOptions
  {
  }
}