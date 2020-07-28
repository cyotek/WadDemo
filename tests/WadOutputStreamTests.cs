using NUnit.Framework;
using System.IO;
using System.Text;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Data.Wad.Tests
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

    #endregion Public Methods
  }
}