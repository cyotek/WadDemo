using NUnit.Framework;
using System.IO;

namespace Cyotek.Data.Wad.Tests
{
  public static class WadAssert
  {
    #region Public Methods

    public static void AreEqual(string expected, Stream actual)
    {
      WadReader expectedReader;
      WadReader actualReader;

      using (Stream input = File.OpenRead(expected))
      {
        expectedReader = new WadReader(input);
        actualReader = new WadReader(actual, true);

        Assert.AreEqual(expectedReader.Type, actualReader.Type, "Types do not match.");
        Assert.AreEqual(expectedReader.Count, actualReader.Count, "Lump count does not match.");

        for (int i = 0; i < expectedReader.Count; i++)
        {
          WadLump expectedLump;
          WadLump actualLump;

          expectedLump = expectedReader.GetNextLump();
          actualLump = actualReader.GetNextLump();

          WadAssert.AreEqual(expectedLump, actualLump);
        }
      }
    }

    public static void AreEqual(Stream expected, WadFile actual)
    {
      WadReader expectedReader;

      expectedReader = new WadReader(expected, true);

      Assert.AreEqual(expectedReader.Type, actual.Type, "Types do not match.");
      Assert.AreEqual(expectedReader.Count, actual.Lumps.Count, "Lump count does not match.");

      for (int i = 0; i < expectedReader.Count; i++)
      {
        WadLump expectedLump;
        WadLump actualLump;

        expectedLump = expectedReader.GetNextLump();
        actualLump = actual.Lumps[i];

        WadAssert.AreEqual(expectedLump, actualLump);
      }
    }

    public static void AreEqual(WadLump expected, WadLump actual)
    {
      if (expected is null && !(actual is null))
      {
        Assert.Fail("Expected null, but received value.");
      }
      else if (!(expected is null) && actual is null)
      {
        Assert.Fail("Expected value, but received null.");
      }
      else if (expected != null && actual != null)
      {
        byte[] expectedData;
        byte[] actualData;

        Assert.AreEqual(expected.Name, actual.Name, "Lump name does not match.");
        Assert.AreEqual(expected.Size, actual.Size, "Lump size does not match.");
        Assert.AreEqual(expected.Index, actual.Index, "Lump index does not match.");

        expectedData = new byte[expected.Size];
        actualData = new byte[actual.Size];

        using (Stream stream = expected.GetInputStream())
        {
          stream?.Read(expectedData, 0, expectedData.Length);
        }

        using (Stream stream = actual.GetInputStream())
        {
          stream?.Read(actualData, 0, actualData.Length);
        }

        CollectionAssert.AreEqual(expectedData, actualData);
      }
    }

    #endregion Public Methods
  }
}