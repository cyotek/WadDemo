﻿// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Cyotek.Data.Tests
{
  [TestFixture]
  public class PackDirectoryReaderTests : TestBase
  {
    #region Public Properties

    public static IEnumerable<TestCaseData> ReadHeaderTestCaseSource
    {
      get
      {
        yield return new TestCaseData("nfo.wad", DirectoryHeader.Empty).SetName("{m}Invalid");
        yield return new TestCaseData(@"E:\Games\Quake\id1\PAK0.PAK", new DirectoryHeader(WadType.Pack, 0, 0)).SetName("{m}");
      }
    }

    #endregion Public Properties

    #region Public Methods

    [Test]
    [TestCaseSource(nameof(ReadHeaderTestCaseSource))]
    public void ReadHeaderTestCases(string fileName, DirectoryHeader expected)
    {
      // arrange
      IDirectoryReader target;
      DirectoryHeader actual;
      Stream stream;

      target = new PackDirectoryReader();
      stream = File.OpenRead(this.GetDataFileName(fileName));

      // act
      actual = target.ReadHeader(stream);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestNameTest()
    {
      // arrange
      IDirectoryReader target;
      DirectoryHeader actual;
      Stream stream;

      target = new PackDirectoryReader();
      stream = File.OpenRead(this.GetDataFileName(@"E:\Games\Quake\id1\PAK0.PAK"));

actual      =target.ReadHeader(stream);
stream.Position = actual.DirectoryOffset;
      
      // act
var x=      target.ReadEntry(stream);

      // assert
      Assert.Fail();
    }



    #endregion Public Methods
  }
}