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
using System.Text;

namespace Cyotek.Data.Tests
{
  [TestFixture]
  public class Wad2DirectoryWriterTests : TestBase
  {
    #region Public Methods

    [Test]
    public void FullWriteTest()
    {
      // arrange
      using (MemoryStream output = new MemoryStream())
      {
        using (WadOutputStream target = new WadOutputStream(output, WadType.Wad2))
        {
          byte[] expected;
          byte[] actual;

          expected = File.ReadAllBytes(this.GetDataFileName("nfo2.wad"));

          // act
          using (BinaryWriter writer = new BinaryWriter(target, Encoding.UTF8, true))
          {
            target.PutNextLump(new WadLump { Name = "PHOTO1", CompressionMode = 1, Type = 2 });
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo1.inf")));
            target.PutNextLump(new WadLump { Name = "PHOTO2", CompressionMode = 3, Type = 4 });
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo2.inf")));
            target.PutNextLump(new WadLump { Name = "PHOTO5", Type = 80 });
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo5.inf")));
          }

          // assert
          target.Flush();
          output.Position = 0;
          actual = output.ToArray();
          //File.WriteAllBytes(@"D:\Checkout\trunk\cyotek\source\demo\WadDemo\tests\data\nfo2.wad", actual);
          output.Dispose();
          CollectionAssert.AreEqual(expected, actual);
        }
      }
    }

    [Test]
    public void WriteEntryTest()
    {
      // arrange
      IDirectoryWriter target;
      MemoryStream stream;
      WadLump value;
      byte[] expected;
      byte[] actual;

      target = new WadDirectoryWriter(WadType.Wad2);

      actual = new byte[40];
      stream = new MemoryStream(actual, true);

      value = new WadLump
      {
        Name = "NUM_0",
        Size = 584,
        Offset = 12,
        UncompressedSize = 584,
        Type = 66
      };

      expected = new byte[]
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

      target = new WadDirectoryWriter(WadType.Wad2);

      actual = new byte[16];
      stream = new MemoryStream(actual, true);

      value = new DirectoryHeader(WadType.Wad2, 1425, 09012022);

      expected = new byte[]
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