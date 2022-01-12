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
  public class CustomWadDirectoryReaderTests : TestBase
  {
    #region Public Properties

    public static IEnumerable<TestCaseData> ReadEntryTestCaseSource
    {
      get
      {
        yield return new TestCaseData("custom.wad", 1, new WadLump { Name = "PHOTO1", Size = 122, UncompressedSize = 122 }).SetName("{m}First");
        yield return new TestCaseData("custom.wad", 3, new WadLump { Name = "I know our mythic history, King Arthur's and Sir Caradoc's; I answer hard acrostics, I've a pretty taste for paradox", Size = 135, UncompressedSize = 135 }).SetName("{m}Second");
      }
    }

    public static IEnumerable<TestCaseData> ReadHeaderTestCaseSource
    {
      get
      {
        yield return new TestCaseData("photo1.jpg", DirectoryHeader.Empty).SetName("{m}Invalid");
        yield return new TestCaseData("nfo.wad", DirectoryHeader.Empty).SetName("{m}Patch");
        yield return new TestCaseData("custom.wad", new DirectoryHeader(CustomWadDirectoryWriterTests.CustomFormat.Type, 391, 3)).SetName("{m}Internal");
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

      target = new WadDirectoryReader(CustomWadDirectoryWriterTests.CustomFormat);

      buffer = new byte[]
      {
        73,
        32,
        97,
        109,
        32,
        116,
        104,
        101,
        32,
        118,
        101,
        114,
        121,
        32,
        109,
        111,
        100,
        101,
        108,
        32,
        111,
        102,
        32,
        97,
        32,
        109,
        111,
        100,
        101,
        114,
        110,
        32,
        77,
        97,
        106,
        111,
        114,
        45,
        71,
        105,
        110,
        101,
        114,
        97,
        108,
        44,
        32,
        73,
        39,
        118,
        101,
        32,
        105,
        110,
        102,
        111,
        114,
        109,
        97,
        116,
        105,
        111,
        110,
        32,
        118,
        101,
        103,
        101,
        116,
        97,
        98,
        108,
        101,
        44,
        32,
        97,
        110,
        105,
        109,
        97,
        108,
        44,
        32,
        97,
        110,
        100,
        32,
        109,
        105,
        110,
        101,
        114,
        97,
        108,
        44,
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
        0,
        0,
        0,
        0,
        0,
        194,
        6,
        0,
        0,
        176,
        58,
        52,
        1,
      };
      stream = new MemoryStream(buffer, true);

      expected = new WadLump
      {
        Name = "I am the very model of a modern Major-Gineral, I've information vegetable, animal, and mineral,",
        Size = 20200112,
        Offset = 1730,
        UncompressedSize = 20200112
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

      target = new WadDirectoryReader(CustomWadDirectoryWriterTests.CustomFormat);
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

      target = new WadDirectoryReader(CustomWadDirectoryWriterTests.CustomFormat);

      buffer = new byte[]
      {
        80,
        65,
        75,
        88,
        92,
        6,
        0,
        0,
        208,
        136,
        52,
        1,
      };
      stream = new MemoryStream(buffer, false);

      expected = new DirectoryHeader(CustomWadDirectoryWriterTests.CustomFormat.Type, 1628, 20220112);

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

      target = new WadDirectoryReader(CustomWadDirectoryWriterTests.CustomFormat);
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