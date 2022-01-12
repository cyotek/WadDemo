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
  public class Wad1InternalDirectoryReaderTests : TestBase
  {
    #region Public Properties

    public static IEnumerable<TestCaseData> ReadEntryTestCaseSource
    {
      get
      {
        yield return new TestCaseData("photos.wad", 1, new WadLump { Name = "P_START", Size = 0, UncompressedSize = 0 }).SetName("{m}First");
        yield return new TestCaseData("photos.wad", 2, new WadLump { Name = "P1_START", Size = 0, UncompressedSize = 0 }).SetName("{m}Second");
      }
    }

    public static IEnumerable<TestCaseData> ReadHeaderTestCaseSource
    {
      get
      {
        yield return new TestCaseData("photo1.jpg", DirectoryHeader.Empty).SetName("{m}Invalid");
        yield return new TestCaseData("nfo.wad", DirectoryHeader.Empty).SetName("{m}Patch");
        yield return new TestCaseData("photos.wad", new DirectoryHeader(WadType.Internal, 28156, 14)).SetName("{m}Internal");
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

      target = new WadDirectoryReader(WadType.Internal);

      buffer = new byte[]
      {
        183,
        3,
        0,
        0,
        54,
        131,
        137,
        0,
        97,
        108,
        112,
        104,
        97,
        0,
        0,
        0
      };
      stream = new MemoryStream(buffer, true);

      expected = new WadLump
      {
        Name = "alpha",
        Size = 09012022,
        Offset = 0951,
        UncompressedSize = 09012022
      };

      // act
      actual = target.ReadEntry(stream);

      // assert
      stream.Dispose();
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

      target = new WadDirectoryReader(WadType.Internal);
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
      stream.Dispose();
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

      target = new WadDirectoryReader(WadType.Internal);

      buffer = new byte[]
      {
        73,
        87,
        65,
        68,
        54,
        131,
        137,
        0,
        164,
        3,
        0,
        0
      };
      stream = new MemoryStream(buffer, false);

      expected = new DirectoryHeader(WadType.Internal, 0932, 09012022);

      // act
      actual = target.ReadHeader(stream);

      // assert
      stream.Dispose();
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

      target = new WadDirectoryReader(WadType.Internal);
      stream = File.OpenRead(this.GetDataFileName(fileName));

      // act
      actual = target.ReadHeader(stream);

      // assert
      stream.Dispose();
      WadAssert.AreEqual(expected, actual);
    }

    #endregion Public Methods
  }
}