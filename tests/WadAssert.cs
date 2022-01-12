// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using NUnit.Framework;
using System.IO;

namespace Cyotek.Data.Tests
{
  public static class WadAssert
  {
    #region Public Methods

    public static void AreEqual(string expected, Stream actual)
    {
      using (Stream input = File.OpenRead(expected))
      {
        WadReader expectedReader;
        WadReader actualReader;

        expectedReader = new WadReader(input);
        actualReader = new WadReader(actual, true);

        Assert.AreEqual(expectedReader.Type, actualReader.Type, "Types do not match.");
        Assert.AreEqual(expectedReader.Count, actualReader.Count, "Lump count does not match.");

        for (int i = 0; i < expectedReader.Count; i++)
        {
          WadLump expectedLump;
          WadLump actualLump;

          expectedLump = expectedReader.GetNextLump();
          actualLump = actualReader.GetNextLump();

          WadAssert.AreEqual(expectedLump, actualLump);
        }
      }
    }

    public static void AreEqual(Stream expected, WadFile actual)
    {
      WadReader expectedReader;

      expectedReader = new WadReader(expected, true);

      Assert.AreEqual(expectedReader.Type, actual.Type, "Types do not match.");
      Assert.AreEqual(expectedReader.Count, actual.Lumps.Count, "Lump count does not match.");

      for (int i = 0; i < expectedReader.Count; i++)
      {
        WadLump expectedLump;
        WadLump actualLump;

        expectedLump = expectedReader.GetNextLump();
        actualLump = actual.Lumps[i];

        WadAssert.AreEqual(expectedLump, actualLump);
      }
    }

    public static void AreEqual(WadLump expected, WadLump actual)
    {
      if (expected is null && !(actual is null))
      {
        Assert.Fail("Expected null, but received value.");
      }
      else if (!(expected is null) && actual is null)
      {
        Assert.Fail("Expected value, but received null.");
      }
      else if (expected != null)
      {
        byte[] expectedData;
        byte[] actualData;

        Assert.AreEqual(expected.Name, actual.Name, "Lump name does not match.");
        Assert.AreEqual(expected.Size, actual.Size, "Lump size does not match.");
        Assert.AreEqual(expected.Index, actual.Index, "Lump index does not match.");
        Assert.AreEqual(expected.CompressionMode, actual.CompressionMode, nameof(WadLump.CompressionMode));
        Assert.AreEqual(expected.UncompressedSize, actual.UncompressedSize, nameof(WadLump.UncompressedSize));
        Assert.AreEqual(expected.Type, actual.Type, nameof(WadLump.Type));

        expectedData = new byte[expected.Size];
        actualData = new byte[actual.Size];

        using (Stream stream = expected.GetInputStream())
        {
          stream?.Read(expectedData, 0, expected.Size);
        }

        using (Stream stream = actual.GetInputStream())
        {
          stream?.Read(actualData, 0, actual.Size);
        }

        CollectionAssert.AreEqual(expectedData, actualData);
      }
    }

    public static void AreEqual(DirectoryHeader expected, DirectoryHeader actual)
    {
      Assert.AreEqual(expected.Type, actual.Type, nameof(DirectoryHeader.Type));
      Assert.AreEqual(expected.DirectoryOffset, actual.DirectoryOffset, nameof(DirectoryHeader.DirectoryOffset));
      Assert.AreEqual(expected.EntryCount, actual.EntryCount, nameof(DirectoryHeader.EntryCount));
    }

    #endregion Public Methods
  }
}