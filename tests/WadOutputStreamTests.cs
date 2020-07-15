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

          expected = File.ReadAllBytes(this.GetDataFileName("test.wad"));

          // act
          using (BinaryWriter writer = new BinaryWriter(target, Encoding.UTF8, true))
          {
            target.PutNextEntry("P_START");
            target.PutNextEntry("PHOTO1");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo1.jpg")));
            target.PutNextEntry("PHOTO2");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo2.jpg")));
            target.PutNextEntry("PHOTO5");
            writer.Write(File.ReadAllBytes(this.GetDataFileName("photo5.jpg")));
            target.PutNextEntry("P_END");
          }

          // assert
          target.Flush();
          output.Position = 0;
          actual = output.ToArray();
          CollectionAssert.AreEqual(expected, actual);
          //WadAssert.AreEqual(this.GetDataFileName("test.wad"), output);
          //File.WriteAllBytes(this.GetDataFileName("test.wad"), output.ToArray());
        }
      }
    }

    #endregion Public Methods
  }
}