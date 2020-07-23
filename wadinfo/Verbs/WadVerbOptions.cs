using CommandLine;

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