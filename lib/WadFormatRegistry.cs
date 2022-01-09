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

    private static readonly ConcurrentDictionary<WadType, IDirectoryWriter> _writers;

    #endregion Private Fields

    #region Public Constructors

    static WadFormatRegistry()
    {
      _readers = new ConcurrentDictionary<WadType, IDirectoryReader>();
      WadFormatRegistry.RegisterReader(WadType.Internal, Wad1InternalDirectoryReader.Default);
      WadFormatRegistry.RegisterReader(WadType.Patch, Wad1PatchDirectoryReader.Default);
      WadFormatRegistry.RegisterReader(WadType.Pack, PackDirectoryReader.Default);
      WadFormatRegistry.RegisterReader(WadType.Wad2, Wad2DirectoryReader.Default);
      WadFormatRegistry.RegisterReader(WadType.Wad3, Wad3DirectoryReader.Default);

      _writers = new ConcurrentDictionary<WadType, IDirectoryWriter>();
      WadFormatRegistry.RegisterWriter(WadType.Internal, Wad1InternalDirectoryWriter.Default);
      WadFormatRegistry.RegisterWriter(WadType.Patch, Wad1PatchDirectoryWriter.Default);
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

    public static IDirectoryReader GetReader(WadType type)
    {
      _readers.TryGetValue(type, out IDirectoryReader result);

      return result;
    }

    public static IDirectoryWriter GetWriter(WadType type)
    {
      _writers.TryGetValue(type, out IDirectoryWriter result);

      return result;
    }

    public static void RegisterReader(WadType type, IDirectoryReader reader)
    {
      _readers[type] = reader;
    }

    public static void RegisterWriter(WadType type, IDirectoryWriter writer)
    {
      _writers[type] = writer;
    }

    public static void UnregisterReader(WadType type)
    {
      _readers.TryRemove(type, out IDirectoryReader _);
    }

    public static void UnregisterWriter(WadType type)
    {
      _writers.TryRemove(type, out IDirectoryWriter _);
    }

    #endregion Public Methods
  }
}