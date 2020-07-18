using NUnit.Framework;
using System.IO;
using System.Text;

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
            target.PutNextEntry("PHOTO1");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo1.inf")));
            target.PutNextEntry("PHOTO2");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo2.inf")));
            target.PutNextEntry("PHOTO5");
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