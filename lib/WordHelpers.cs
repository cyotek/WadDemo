// Writing Microsoft RIFF Palette (pal) files with C#
// http://cyotek.com/blog/writing-microsoft-riff-palette-pal-files-with-csharp

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2017 - 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

// Found this example useful?
// https://www.paypal.me/cyotek

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