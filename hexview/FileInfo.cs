using System.IO;

namespace Cyotek.Demo
{
  internal class FileInfo
  {
    #region Private Fields

    private readonly string _fullPath;

    #endregion Private Fields

    #region Public Constructors

    public FileInfo(string fullPath)
    {
      _fullPath = fullPath;
    }

    #endregion Public Constructors

    #region Public Properties

    public string FullPath
    {
      get { return _fullPath; }
    }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>
    /// A string that represents the current object.
    /// </returns>
    public override string ToString()
    {
      return Path.GetFileName(_fullPath);
    }

    #endregion Public Methods
  }
}