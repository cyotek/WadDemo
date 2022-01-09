// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Cyotek.Data.Tests
{
  [TestFixture]
  public class Wad2DirectoryReaderTests : TestBase
  {
    #region Public Properties

    public static IEnumerable<TestCaseData> ReadEntryTestCaseSource
    {
      get
      {
        yield return new TestCaseData("nfo2.wad", 1, new WadLump { Name = "PHOTO1", Size = 122, UncompressedSize = 122, CompressionMode = 1, Type = 2 }).SetName("{m}First");
        yield return new TestCaseData("nfo2.wad", 3, new WadLump { Name = "PHOTO5", Size = 135, UncompressedSize = 135, Type = 80 }).SetName("{m}Second");
      }
    }

    public static IEnumerable<TestCaseData> ReadHeaderTestCaseSource
    {
      get
      {
        yield return new TestCaseData("nfo2.wad", new DirectoryHeader(WadType.Wad2, 391, 3)).SetName("{m}");
        yield return new TestCaseData("photo1.jpg", DirectoryHeader.Empty).SetName("{m}Invalid");
      }
    }

    #endregion Public Properties

    #region Public Methods

    [Test]
    public void ReadEntryTest()
    {
      // arrange
      IDirectoryReader target;
      byte[] buffer;
      MemoryStream stream;
      WadLump expected;
      WadLump actual;

      target = new Wad2DirectoryReader();

      buffer = new byte[]
      {
        12,
        0,
        0,
        0,
        72,
        2,
        0,
        0,
        72,
        2,
        0,
        0,
        66,
        0,
        0,
        0,
        78,
        85,
        77,
        95,
        48,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
      };
      stream = new MemoryStream(buffer, true);

      expected = new WadLump
      {
        Name = "NUM_0",
        Size = 584,
        Offset = 12,
        UncompressedSize = 584,
        Type = 66
      };

      // act
      actual = target.ReadEntry(stream);

      // assert
      WadAssert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(ReadEntryTestCaseSource))]
    public void ReadEntryTestCases(string fileName, int iterations, WadLump expected)
    {
      // arrange
      IDirectoryReader target;
      WadLump actual;
      DirectoryHeader header;
      Stream stream;

      target = new Wad2DirectoryReader();
      stream = File.OpenRead(this.GetDataFileName(fileName));

      header = target.ReadHeader(stream);
      stream.Position = header.DirectoryOffset;

      actual = null;

      // act
      for (int i = 0; i < iterations; i++)
      {
        actual = target.ReadEntry(stream);
      }

      // assert
      WadAssert.AreEqual(expected, actual);
    }

    [Test]
    public void ReadHeaderTest()
    {
      // arrange
      IDirectoryReader target;
      byte[] buffer;
      MemoryStream stream;
      DirectoryHeader expected;
      DirectoryHeader actual;

      target = new Wad2DirectoryReader();

      buffer = new byte[]
      {
        87,
        65,
        68,
        50,
        54,
        131,
        137,
        0,
        145,
        5,
        0,
        0
      };
      stream = new MemoryStream(buffer, false);

      expected = new DirectoryHeader(WadType.Wad2, 1425, 09012022);

      // act
      actual = target.ReadHeader(stream);

      // assert
      WadAssert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(ReadHeaderTestCaseSource))]
    public void ReadHeaderTestCases(string fileName, DirectoryHeader expected)
    {
      // arrange
      IDirectoryReader target;
      DirectoryHeader actual;
      Stream stream;

      target = new Wad2DirectoryReader();
      stream = File.OpenRead(this.GetDataFileName(fileName));

      // act
      actual = target.ReadHeader(stream);

      // assert
      WadAssert.AreEqual(expected, actual);
    }

    #endregion Public Methods
  }
}