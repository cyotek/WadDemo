using CommandLine;

namespace Cyotek.Tools.WadInfo.Verbs
{
  [Verb("info", isDefault: true, HelpText = "Display WAD information")]
  internal class InfoVerbOptions : WadVerbOptions
  {
  }
}