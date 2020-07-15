using Cyotek.Data.Wad;

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
      get { return _fileName; }
      set { _fileName = value; }
    }

    public string IndexFileName
    {
      get { return _indexFileName; }
      set { _indexFileName = value; }
    }

    public WadType Type
    {
      get { return _type; }
      set { _type = value; }
    }

    #endregion Public Properties
  }
}