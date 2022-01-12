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
  public class CustomWadDirectoryWriterTests : TestBase
  {
    #region Internal Fields

    internal static readonly WadFormat CustomFormat = new WadFormat
    {
      Type = (WadType)128,
      HeaderLength = 12,
      HeaderDirectoryOffset = 4,
      HeaderCountOffset = 8,
      DirectoryEntryLength = 128,
      DirectoryEntryNameOffset = 0,
      DirectoryEntryNameLength = 120,
      DirectoryEntryDataOffset = 120,
      DirectoryEntrySizeOffset = 124,
      SignatureBytes = new byte[] { (byte)'P', (byte)'A', (byte)'K', (byte)'X' }
    };

    #endregion Internal Fields

    #region Public Methods

    [Test]
    public void FullWriteTest()
    {
      // arrange
      using (MemoryStream output = new MemoryStream())
      {
        using (WadOutputStream target = new WadOutputStream(output, CustomWadDirectoryWriterTests.CustomFormat))
        {
          byte[] expected;
          byte[] actual;

          expected = File.ReadAllBytes(this.GetDataFileName("custom.wad"));

          // act
          using (BinaryWriter writer = new BinaryWriter(target, Encoding.ASCII, true))
          {
            target.PutNextLump(new WadLump { Name = "PHOTO1" });
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo1.inf")));
            target.PutNextLump(new WadLump { Name = "PHOTO2" });
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo2.inf")));
            target.PutNextLump(new WadLump { Name = "I know our mythic history, King Arthur's and Sir Caradoc's; I answer hard acrostics, I've a pretty taste for paradox" });
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo5.inf")));
          }

          // assert
          target.Flush();
          output.Position = 0;
          actual = output.ToArray();
          //File.WriteAllBytes(@"D:\Checkout\trunk\cyotek\source\demo\WadDemo\tests\data\custom.wad", actual);
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

      target = new WadDirectoryWriter(CustomWadDirectoryWriterTests.CustomFormat);

      actual = new byte[132];
      stream = new MemoryStream(actual, true);

      value = new WadLump
      {
        Name = "I am the very model of a modern Major-Gineral, I've information vegetable, animal, and mineral,",
        Size = 20200112,
        Offset = 1730
      };

      expected = new byte[]
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

      target = new WadDirectoryWriter(CustomWadDirectoryWriterTests.CustomFormat);

      actual = new byte[16];
      stream = new MemoryStream(actual, true);

      value = new DirectoryHeader(CustomWadDirectoryWriterTests.CustomFormat.Type, 1628, 20220112);

      expected = new byte[]
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