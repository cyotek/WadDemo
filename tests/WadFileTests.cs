using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Cyotek.Data.Wad.Tests
{
  [TestFixture]
  public class WadFileTests : TestBase
  {
    #region Public Methods

    [Test]
    public void LoadTest()
    {
      // arrange
      WadFile actual;
      Stream expected;
      string fileName;

      fileName = this.GetDataFileName("test.wad");

      expected = this.CreateSampleWad();

      // act
      actual = WadFile.LoadFrom(fileName);

      // assert
      WadAssert.AreEqual(expected, actual);
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

    public static IEnumerable<TestCaseData> FindTestCaseSource()
    {
      yield return new TestCaseData("NOTTHERE", 0, null).SetName(nameof(FindTestCaseSource) + "NoMatch");
      yield return new TestCaseData("ALPHA", 0, new WadLump { Name = "ALPHA" }).SetName(nameof(FindTestCaseSource) + "Match");
      yield return new TestCaseData("GAMMA", 0, new WadLump { Name = "GAMMA", Index = 2 }).SetName(nameof(FindTestCaseSource) + "FirstMatch");
      yield return new TestCaseData("GAMMA", 4, new WadLump { Name = "GAMMA", Index = 4 }).SetName(nameof(FindTestCaseSource) + "SkipMatch");
    }


    #endregion Public Methods
  }
}