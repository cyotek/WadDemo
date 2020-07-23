using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Cyotek.Data.Wad
{
  internal static class Guard
  {
    #region Public Methods

    [DebuggerHidden]
    public static void ThrowIfNull(object obj, string name)
    {
      if (obj is null)
      {
        throw new ArgumentNullException(name);
      }
    }

    [DebuggerHidden]
    public static void ThrowIfNullOrEmpty(string obj, string name)
    {
      if (string.IsNullOrEmpty(obj))
      {
        throw new ArgumentNullException(name);
      }
    }

    [DebuggerHidden]
    public static void ThrowIfOutOfBounds(long value, long min, long max, string message, string name)
    {
      if (value < min || value > max)
      {
        throw new ArgumentOutOfRangeException(name, value, message);
      }
    }

    [DebuggerHidden]
    public static void ThrowIfOutOfBounds(int value, int min, int max, string message, string name)
    {
      if (value < min || value > max)
      {
        throw new ArgumentOutOfRangeException(name, value, message);
      }
    }

    [DebuggerHidden]
    public static void ThrowIfOutOfBounds<T>(T value, T min, T max, string message, string name)
      where T : Enum
    {
      if (Comparer<T>.Default.Compare(value, min) < 0 || Comparer<T>.Default.Compare(value, max) > 0)
      {
        throw new ArgumentOutOfRangeException(name, value, message);
      }
    }

    [DebuggerHidden]
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

    [DebuggerHidden]
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