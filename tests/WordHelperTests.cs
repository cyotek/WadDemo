// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cyotek.Data.Tests
{
  [TestFixture]
  public class WordHelperTests
  {
    #region Public Methods

    public static IEnumerable<TestCaseData> GetInt32LeTestCaseSource()
    {
      yield return new TestCaseData(new byte[] { 0, 0, 0, 0 }, 0, 0).SetName(nameof(GetInt32LeTestCases) + "Zero");
      yield return new TestCaseData(new byte[] { 73, 87, 65, 68 }, 0, 1145132873).SetName(nameof(GetInt32LeTestCases) + "IWAD");
      yield return new TestCaseData(new byte[] { 73, 87, 65, 68, 2, 9, 0, 0 }, 4, 2306).SetName(nameof(GetInt32LeTestCases) + "Offset");
    }

    public static IEnumerable<TestCaseData> PutInt32LeTestCaseSource()
    {
      yield return new TestCaseData(0, new byte[] { 0, 0, 0, 0 }, 0, new byte[] { 0, 0, 0, 0 }).SetName(nameof(PutInt32LeTestCases) + "Zero");
      yield return new TestCaseData(1145132873, new byte[] { 73, 87, 65, 68 }, 0, new byte[] { 73, 87, 65, 68 }).SetName(nameof(PutInt32LeTestCases) + "IWAD");
      yield return new TestCaseData(2306, new byte[] { 73, 87, 65, 68, 0, 0, 0, 0 }, 4, new byte[] { 73, 87, 65, 68, 2, 9, 0, 0 }).SetName(nameof(PutInt32LeTestCases) + "Offset");
    }

    [Test]
    [TestCaseSource(nameof(GetInt32LeTestCaseSource))]
    public void GetInt32LeTestCases(byte[] buffer, int offset, int expected)
    {
      // arrange
      int actual;

      // act
      actual = WordHelpers.GetInt32Le(buffer, offset);

      // assert
      Assert.AreEqual(expected, actual);
      if (BitConverter.IsLittleEndian)
      {
        Assert.AreEqual(BitConverter.ToInt32(buffer, offset), actual);
      }
    }

    [Test]
    [TestCaseSource(nameof(PutInt32LeTestCaseSource))]
    public void PutInt32LeTestCases(int value, byte[] buffer, int offset, byte[] expected)
    {
      // arrange

      // act
      WordHelpers.PutInt32Le(value, buffer, offset);

      // assert
      CollectionAssert.AreEqual(expected, buffer);
      if (BitConverter.IsLittleEndian)
      {
        byte[] sanityCheck;
        sanityCheck = new byte[4];
        WordHelpers.PutInt32Le(value, sanityCheck, 0);
        CollectionAssert.AreEqual(BitConverter.GetBytes(value), sanityCheck);
      }
    }

    #endregion Public Methods
  }
}