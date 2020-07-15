using Cyotek.Data.Wad;

namespace Cyotek.Demo.Wad
{
  internal class ExtractResult
  {
    #region Private Fields

    private string _fileName;

    private WadLump _lump;

    #endregion Private Fields

    #region Public Constructors

    public ExtractResult()
    {
    }

    public ExtractResult(WadLump lump, string fileName)
    {
      _lump = lump;
      _fileName = fileName;
    }

    #endregion Public Constructors

    #region Public Properties

    public string FileName
    {
      get { return _fileName; }
      set { _fileName = value; }
    }

    public WadLump Lump
    {
      get { return _lump; }
      set { _lump = value; }
    }

    #endregion Public Properties
  }
}