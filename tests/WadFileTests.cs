using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Cyotek.Data.Wad.Tests
{
  [TestFixture]
  public class WadFileTests : TestBase
  {
    #region Public Methods

    public static IEnumerable<TestCaseData> FindTestCaseSource()
    {
      yield return new TestCaseData("NOTTHERE", 0, null).SetName(nameof(FindTestCaseSource) + "NoMatch");
      yield return new TestCaseData("ALPHA", 0, new WadLump { Name = "ALPHA" }).SetName(nameof(FindTestCaseSource) + "Match");
      yield return new TestCaseData("GAMMA", 0, new WadLump { Name = "GAMMA", Index = 2 }).SetName(nameof(FindTestCaseSource) + "FirstMatch");
      yield return new TestCaseData("GAMMA", 4, new WadLump { Name = "GAMMA", Index = 4 }).SetName(nameof(FindTestCaseSource) + "SkipMatch");
    }

    [Test]
    public void FindAllTest()
    {
      // arrange
      WadFile target;
      WadLump[] actual;
      WadLump[] expected;
      WadLump alpha1;
      WadLump alpha2;
      WadLump alpha3;

      alpha1 = new WadLump { Name = "ALPHA" };
      alpha2 = new WadLump { Name = "ALPHA" };
      alpha3 = new WadLump { Name = "ALPHA" };

      target = new WadFile();
      target.Lumps.Add(alpha1);
      target.Lumps.Add(new WadLump { Name = "BETA" });
      target.Lumps.Add(new WadLump { Name = "GAMMA" });
      target.Lumps.Add(new WadLump { Name = "DELTA" });
      target.Lumps.Add(new WadLump { Name = "GAMMA" });
      target.Lumps.Add(alpha2);
      target.Lumps.Add(new WadLump { Name = "EPSILON" });
      target.Lumps.Add(alpha3);

      expected = new[]
      {
        alpha1,
        alpha2,
        alpha3
      };

      // act
      actual = target.FindAll("ALPHA");

      // assert
      Assert.AreEqual(expected.Length, actual.Length);
      for (int i = 0; i < expected.Length; i++)
      {
        Assert.AreSame(expected[i], actual[i]);
      }
    }

    [Test]
    [TestCaseSource(nameof(FindTestCaseSource))]
    public void FindTestCases(string name, int startIndex, WadLump expected)
    {
      // arrange
      WadFile target;
      WadLump actual;

      target = new WadFile();
      target.Lumps.Add(new WadLump { Name = "ALPHA" });
      target.Lumps.Add(new WadLump { Name = "BETA" });
      target.Lumps.Add(new WadLump { Name = "GAMMA" });
      target.Lumps.Add(new WadLump { Name = "DELTA" });
      target.Lumps.Add(new WadLump { Name = "GAMMA" });
      target.Lumps.Add(new WadLump { Name = "EPSILON" });

      // act
      actual = target.Find(name, startIndex);

      // assert
      WadAssert.AreEqual(expected, actual);
    }

    [Test]
    public void LoadTest()
    {
      // arrange
      WadFile actual;
      Stream expected;
      string fileName;

      fileName = this.GetDataFileName("nfo.wad");

      expected = this.CreateSampleWad();

      // act
      actual = WadFile.LoadFrom(fileName);

      // assert
      WadAssert.AreEqual(expected, actual);
    }

    [Test]
    public void OptimiseTest()
    {
      // arrange
      using (Stream stream = this.CreateUnoptomizedSampleWad())
      {
        WadFile target;
        byte[] expected;
        byte[] actual;

        expected = File.ReadAllBytes(this.GetDataFileName("nfo.wad"));

        target = WadFile.LoadFrom(stream);

        // act
        target.Save();

        // assert
        actual = ((MemoryStream)stream).ToArray();
        CollectionAssert.AreEqual(expected, actual);
      }
    }

    [Test]
    public void ReplaceTest()
    {
      // arrange
      using (Stream stream = this.CreateSampleWad())
      {
        WadFile target;
        byte[] expected;
        byte[] actual;

        expected = File.ReadAllBytes(this.GetDataFileName("replace.wad"));

        target = new WadFile(stream);
        target.ReplaceFile("PHOTO2", this.GetDataFileName("photo2.jpg"));

        // act
        target.Save(stream);

        // assert
        actual = ((MemoryStream)stream).ToArray();
        CollectionAssert.AreEqual(expected, actual);
      }
    }

    [Test]
    public void SaveTest()
    {
      // arrange
      using (MemoryStream stream = new MemoryStream())
      {
        WadFile target;
        byte[] expected;
        byte[] actual;

        expected = File.ReadAllBytes(this.GetDataFileName("nfo.wad"));

        target = new WadFile(WadType.Patch);
        target.AddFile("PHOTO1", this.GetDataFileName("photo1.inf"));
        target.AddFile("PHOTO2", this.GetDataFileName("photo2.inf"));
        target.AddFile("PHOTO5", this.GetDataFileName("photo5.inf"));

        // act
        target.Save(stream);

        // assert
        actual = stream.ToArray();
        CollectionAssert.AreEqual(expected, actual);
      }
    }

    #endregion Public Methods
  }
}