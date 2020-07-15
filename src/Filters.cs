namespace Cyotek.Demo.Wad
{
  internal static class Filters
  {
    #region Public Fields

    public static readonly string AllFiles = "All Files (*.*)|*.*";

    public static readonly string Wad = "WAD Files (*.wad)|*.wad|" + AllFiles;
    public static readonly string Text = "Text Files (*.txt)|*.txt|" + AllFiles;

    #endregion Public Fields
  }
}