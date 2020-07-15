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
      get { return _createIndex; }
      set { _createIndex = value; }
    }

    public ExtractMode ExtractMode
    {
      get { return _extractMode; }
      set { _extractMode = value; }
    }

    public bool OpenExplorerWindow
    {
      get { return _openExplorerWindow; }
      set { _openExplorerWindow = value; }
    }

    public ExtractOverwriteMode OverwriteMode
    {
      get { return _overwriteMode; }
      set { _overwriteMode = value; }
    }

    public string Path
    {
      get { return _path; }
      set { _path = value; }
    }

    #endregion Public Properties
  }
}