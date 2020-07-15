namespace Cyotek.Data.Wad
{
  internal static class WadConstants
  {
    #region Public Fields

    public const byte DirectoryHeaderLength = 16;

    public const byte DirectoryStartOffset = 8;

    public const byte LumpCountOffset = 4;

    public const byte LumpNameLength = 8;

    public const byte LumpNameOffset = 8;

    public const byte LumpSizeOffset = 4;

    public const byte LumpStartOffset = 0;

    public const byte WadHeaderLength = 12;

    #endregion Public Fields
  }
}