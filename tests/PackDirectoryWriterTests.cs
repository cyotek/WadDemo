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
  public class PackDirectoryWriterTests : TestBase
  {
    #region Public Methods

    [Test]
    public void FullWriteTest()
    {
      // arrange
      using (MemoryStream output = new MemoryStream())
      {
        using (WadOutputStream target = new WadOutputStream(output, WadType.Pack))
        {
          byte[] expected;
          byte[] actual;

          expected = File.ReadAllBytes(this.GetDataFileName("nfo.pak"));

          // act
          using (BinaryWriter writer = new BinaryWriter(target, Encoding.UTF8, true))
          {
            target.PutNextLump("PHOTO1");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo1.inf")));
            target.PutNextLump("PHOTO2");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo2.inf")));
            target.PutNextLump("PHOTO5");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo5.inf")));
          }

          // assert
          target.Flush();
          output.Position = 0;
          actual = output.ToArray();
          //File.WriteAllBytes(@"D:\Checkout\trunk\cyotek\source\demo\WadDemo\tests\data\nfo.pak", actual);
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

      target = new PackDirectoryWriter();

      actual = new byte[72];
      stream = new MemoryStream(actual, true);

      value = new WadLump
      {
        Name = "beta",
        Size = 09012022,
        UncompressedSize = 09012022,
        Offset = 2016
      };

      expected = new byte[]
      {
        98,
        101,
        116,
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
        224,
        7,
        0,
        0,
        54,
        131,
        137,
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

      target = new PackDirectoryWriter();

      actual = new byte[16];
      stream = new MemoryStream(actual, true);

      value = new DirectoryHeader(WadType.Pack, 2010, 09012022);

      expected = new byte[]
      {
        80,
        65,
        67,
        75,
        218,
        7,
        0,
        0,
        128,
        205,
        96,
        34,
        0,
        0,
        0,
        0
      };

      // act
      target.WriteHeader(stream, value);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    #endregion Public Methods
  }
}