using System;
using System.IO;

namespace Cyotek.Data.Wad
{
  internal static class Guard
  {
    #region Public Methods

    public static void ThrowIfNull(object obj, string name)
    {
      if (obj is null)
      {
        throw new ArgumentNullException(name);
      }
    }

    public static void ThrowIfNullOrEmpty(string obj, string name)
    {
      if (string.IsNullOrEmpty(obj))
      {
        throw new ArgumentNullException(name);
      }
    }

    public static void ThrowIfUnreadableStream(Stream obj, string name)
    {
      if (!obj.CanRead)
      {
        throw new ArgumentException("Stream is not readable.", name);
      }

      if (!obj.CanSeek)
      {
        throw new ArgumentException("Stream is not seekable.", name);
      }
    }

    public static void ThrowIfUnwriteableStream(Stream obj, string name)
    {
      if (!obj.CanWrite)
      {
        throw new ArgumentException("Stream is not writable.", name);
      }

      if (!obj.CanSeek)
      {
        throw new ArgumentException("Stream is not seekable.", name);
      }
    }

    #endregion Public Methods
  }
}