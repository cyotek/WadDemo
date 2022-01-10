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
using System.IO;

namespace Cyotek.Data.Tests
{
  [TestFixture]
  public class Wad1InternalDirectoryWriterTests
  {
    #region Public Methods

    [Test]
    public void WriteEntryTest()
    {
      // arrange
      IDirectoryWriter target;
      MemoryStream stream;
      WadLump value;
      byte[] expected;
      byte[] actual;

      target = new WadDirectoryWriter(WadType.Internal);

      actual = new byte[24];
      stream = new MemoryStream(actual, true);

      value = new WadLump
      {
        Name = "alpha",
        Size = 09012022,
        Offset = 0951
      };

      expected = new byte[]
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

      // act
      target.WriteEntry(stream, value);

      // assert
      stream.Dispose();
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void WriteHeaderTest()
    {
      // arrange
      IDirectoryWriter target;
      MemoryStream stream;
      DirectoryHeader value;
      byte[] expected;
      byte[] actual;

      target = new WadDirectoryWriter(WadType.Internal);

      actual = new byte[16];
      stream = new MemoryStream(actual, true);

      value = new DirectoryHeader(WadType.Internal, 0932, 09012022);

      expected = new byte[]
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
        0,
        0,
        0,
        0,
        0
      };

      // act
      target.WriteHeader(stream, value);

      // assert
      stream.Dispose();
      CollectionAssert.AreEqual(expected, actual);
    }

    #endregion Public Methods
  }
}