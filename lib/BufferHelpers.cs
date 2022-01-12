// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

namespace Cyotek.Data
{
  internal static class BufferHelpers
  {
    #region Internal Methods

    internal static byte[] GetBuffer(int length)
    {
#if NETCOREAPP
      return System.Buffers.ArrayPool<byte>.Shared.Rent(length);
#else
      return new byte[length];
#endif
    }

    internal static void Release(byte[] buffer)
    {
#if NETCOREAPP
      System.Buffers.ArrayPool<byte>.Shared.Return(buffer);
#endif
    }

    #endregion Internal Methods
  }
}