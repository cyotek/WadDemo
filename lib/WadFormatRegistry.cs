// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace Cyotek.Data
{
  internal static class WadFormatRegistry
  {
    #region Private Fields

    private static readonly ConcurrentDictionary<WadType, IDirectoryReader> _readers;

    #endregion Private Fields

    #region Public Constructors

    static WadFormatRegistry()
    {
      _readers = new ConcurrentDictionary<WadType, IDirectoryReader>();
      WadFormatRegistry.RegisterReader(WadType.Internal, Wad1DirectoryReader.Default);
      WadFormatRegistry.RegisterReader(WadType.Patch, Wad1DirectoryReader.Default);
      WadFormatRegistry.RegisterReader(WadType.Pack, PackDirectoryReader.Default);
      WadFormatRegistry.RegisterReader(WadType.Wad2, Wad2DirectoryReader.Default);
    }

    #endregion Public Constructors

    #region Public Methods

    public static WadType GetFormat(Stream stream)
    {
      return WadFormatRegistry.GetFormat(stream, out DirectoryHeader _);
    }

    public static WadType GetFormat(Stream stream, out DirectoryHeader header)
    {
      long position;

      Guard.ThrowIfNull(stream, nameof(stream));
      Guard.ThrowIfUnreadableStream(stream, nameof(stream));
      Guard.ThrowIfUnseekableStream(stream, nameof(stream));

      header = DirectoryHeader.Empty;
      position = stream.Position;

      foreach (KeyValuePair<WadType, IDirectoryReader> pair in _readers)
      {
        header = pair.Value.ReadHeader(stream);

        stream.Position = position;

        if (header.Type != WadType.None)
        {
          break;
        }
      }

      return header.Type;
    }

    public static void RegisterReader(WadType type, IDirectoryReader reader)
    {
      _readers[type] = reader;
    }

    public static void UnregisterReader(WadType type)
    {
      _readers.TryRemove(type, out IDirectoryReader _);
    }

    #endregion Public Methods
  }
}