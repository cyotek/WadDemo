// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System.Text;

namespace Cyotek.Data
{
  internal static class CharHelpers
  {
    #region Private Methods

    public static string GetSafeName(byte[] entry)
    {
      int length;

      length = 0;

      for (int i = WadConstants.DirectoryHeaderLength; i > WadConstants.LumpNameOffset; i--)
      {
        if (entry[i - 1] != '\0')
        {
          length = i - WadConstants.LumpNameOffset;
          break;
        }
      }

      return length > 0
        ? Encoding.ASCII.GetString(entry, WadConstants.LumpNameOffset, length)
        : null;
    }

    #endregion Private Methods
  }
}