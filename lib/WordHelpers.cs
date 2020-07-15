// Loading Microsoft RIFF Palette (pal) files with C#
// http://cyotek.com/blog/loading-microsoft-riff-palette-pal-files-with-csharp

// Writing Microsoft RIFF Palette (pal) files with C#
// http://cyotek.com/blog/writing-microsoft-riff-palette-pal-files-with-csharp

namespace Cyotek.Data.Wad
{
  internal static class WordHelpers
  {
    #region Public Methods

    public static ushort GetInt16Le(byte[] buffer, int offset)
    {
      return (ushort)(buffer[offset + 1] << 8 | buffer[offset]);
    }

    public static int GetInt32Le(byte[] buffer, int offset)
    {
      return buffer[offset + 3] << 24 | buffer[offset + 2] << 16 | buffer[offset + 1] << 8 | buffer[offset];
    }

    public static void PutInt16Le(ushort value, byte[] buffer, int offset)
    {
      buffer[offset + 1] = (byte)((value & 0x0000FF00) >> 8);
      buffer[offset] = (byte)((value & 0x000000FF) >> 0);
    }

    public static void PutInt32Le(int value, byte[] buffer, int offset)
    {
      buffer[offset + 3] = (byte)((value & 0xFF000000) >> 24);
      buffer[offset + 2] = (byte)((value & 0x00FF0000) >> 16);
      buffer[offset + 1] = (byte)((value & 0x0000FF00) >> 8);
      buffer[offset] = (byte)((value & 0x000000FF) >> 0);
    }

    #endregion Public Methods
  }
}