// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using Cyotek.Data.Wad;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cyotek.Data.Tests
{
  [TestFixture]
  public class WadLumpTests
  {
    #region Public Properties

    public static IEnumerable<TestCaseData> GetHashCodeEqualityTestCaseSource
    {
      get
      {
        WadLump instance;

        instance = new WadLump
        {
          Name = "beta",
          Offset = 07012022,
          Size = 0741
        };

        yield return new TestCaseData(new WadLump(), new WadLump()).SetName("{m}Empty");
        yield return new TestCaseData(instance, instance).SetName("{m}Instance");
        yield return new TestCaseData(new WadLump
        {
          Name = "alpha",
          Offset = 07012022,
          Size = 0740
        }, new WadLump
        {
          Name = "alpha",
          Offset = 07012022,
          Size = 0740
        }).SetName("{m}Values");
      }
    }

    public static IEnumerable<TestCaseData> GetHashCodeInequalityTestCaseSource
    {
      get
      {
        yield return new TestCaseData(new WadLump
        {
          Name = "alpha"
        }, new WadLump
        {
          Name = "beta"
        }).SetName("{m}Name");
        yield return new TestCaseData(new WadLump
        {
          Size = 0740
        }, new WadLump
        {
          Size = 0744
        }).SetName("{m}Size");
        yield return new TestCaseData(new WadLump
        {
          Offset = 0740
        }, new WadLump
        {
          Offset = 0744
        }).SetName("{m}Offset");
      }
    }

    #endregion Public Properties

    #region Public Methods

    [Test]
    [TestCaseSource(nameof(GetHashCodeInequalityTestCaseSource))]
    public void EqualsNegativeTestCases(WadLump target, WadLump other)
    {
      Assert.IsFalse(target.Equals(other));
    }

    [Test]
    [TestCaseSource(nameof(GetHashCodeEqualityTestCaseSource))]
    public void EqualsTestCases(WadLump target, WadLump other)
    {
      Assert.IsTrue(target.Equals(other));
    }

    [Test]
    [TestCaseSource(nameof(GetHashCodeEqualityTestCaseSource))]
    public void GetHashCodeEqualityTestCases(WadLump target, WadLump other)
    {
      Assert.AreEqual(target.GetHashCode(), other.GetHashCode());
    }

    [Test]
    [TestCaseSource(nameof(GetHashCodeInequalityTestCaseSource))]
    public void GetHashCodeInequalityTestCases(WadLump target, WadLump other)
    {
      Assert.AreNotEqual(target.GetHashCode(), other.GetHashCode());
    }

    #endregion Public Methods
  }
}