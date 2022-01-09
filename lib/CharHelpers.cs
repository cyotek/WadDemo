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
    #region Public Methods

    public static string GetSafeName(byte[] entry, int start, int maximumLength)
    {
      int length;

      // Starting from the end doesn't seem to always work - the name for progs.dat
      // in the Quake PAK0.PAK file actually has a mix of zero and non-zero values
      // in the name field, so you get a name like
      // progs.datA?►E?w???w??⌂♥p?↕?↕@►E?w???w??⌂??↕

      length = maximumLength;

      for (int i = start; i < start + maximumLength; i++)
      {
        if (entry[i] == '\0')
        {
          length = i - start;
          break;
        }
      }

      return length > 0
        ? Encoding.ASCII.GetString(entry, start, length)
        : null;
    }

    public static void WriteName(string value, byte[] buffer, byte start, byte maximumLength)
    {
      int valueLength;

      valueLength = string.IsNullOrEmpty(value)
        ? 0
        : value.Length;

      Guard.ThrowIfOutOfBounds(valueLength, 0, maximumLength, "Name is too long.", nameof(value));

      for (int i = 0; i < valueLength; i++)
      {
        buffer[start + i] = (byte)value[i];
      }

      for (int i = valueLength; i < maximumLength; i++)
      {
        buffer[start + i] = 0; // shared buffers, so explicitly clear
      }
    }

    #endregion Public Methods
  }
}