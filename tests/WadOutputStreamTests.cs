﻿// Reading DOOM WAD files
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
using System.Text;

namespace Cyotek.Data.Tests
{
  [TestFixture]
  public class WadOutputStreamTests : TestBase
  {
    #region Public Methods

    [Test]
    public void FullWriteTest()
    {
      // arrange
      using (MemoryStream output = new MemoryStream())
      {
        using (WadOutputStream target = new WadOutputStream(output))
        {
          byte[] expected;
          byte[] actual;

          expected = File.ReadAllBytes(this.GetDataFileName("nfo.wad"));

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
          //File.WriteAllBytes(@"D:\Checkout\trunk\cyotek\source\demo\WadDemo\tests\data\test.wad", actual);
          CollectionAssert.AreEqual(expected, actual);
          //WadAssert.AreEqual(this.GetDataFileName("nfo.wad"), output);
        }
      }
    }

    [Test]
    public void FullWriteWithEmptyLumpsTest()
    {
      // arrange
      using (MemoryStream output = new MemoryStream())
      {
        using (WadOutputStream target = new WadOutputStream(output, WadType.Internal))
        {
          byte[] expected;
          byte[] actual;

          expected = File.ReadAllBytes(this.GetDataFileName("photos.wad"));

          // act
          using (BinaryWriter writer = new BinaryWriter(target, Encoding.UTF8, true))
          {
            target.PutNextLump("P_START");
            target.PutNextLump("P1_START");
            target.PutNextLump("INFO");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo1.inf")));
            target.PutNextLump("DATA");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo1.jpg")));
            target.PutNextLump("P1_END");
            target.PutNextLump("P2_START");
            target.PutNextLump("INFO");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo2.inf")));
            target.PutNextLump("DATA");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo2.jpg")));
            target.PutNextLump("P2_END");
            target.PutNextLump("P3_START");
            target.PutNextLump("INFO");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo5.inf")));
            target.PutNextLump("DATA");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo5.jpg")));
            target.PutNextLump("P3_END");
            target.PutNextLump("P_END");
          }

          // assert
          target.Flush();
          output.Position = 0;
          actual = output.ToArray();
          //File.WriteAllBytes(@"D:\Checkout\trunk\cyotek\source\demo\WadDemo\tests\data\photos.wad", actual);
          CollectionAssert.AreEqual(expected, actual);
          //WadAssert.AreEqual(this.GetDataFileName("photos.wad"), output);
        }
      }
    }

    #endregion Public Methods
  }
}