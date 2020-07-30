using NUnit.Framework;
using System.IO;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Data.Wad.Tests
{
  [TestFixture]
  public class OffsetStreamTests
  {
    #region Public Methods

    [Test]
    public void LengthTest()
    {
      // arrange
      OffsetStream target;
      MemoryStream owner;
      int expected;
      long actual;

      expected = 4;

      owner = new MemoryStream(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
      target = new OffsetStream(owner, 2, expected);

      // act
      actual = target.Length;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ReadTest()
    {
      // arrange
      OffsetStream target;
      MemoryStream owner;
      byte[] expected;
      byte[] actual;

      owner = new MemoryStream(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
      target = new OffsetStream(owner, 2, 4);

      expected = new byte[] { 3 };
      actual = new byte[1];

      // act
      target.Read(actual, 0, 1);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void ReadTooMuchDataTest()
    {
      // arrange
      OffsetStream target;
      MemoryStream owner;
      byte[] expected;
      byte[] actual;
      int expectedRead;
      int actualRead;

      owner = new MemoryStream(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
      target = new OffsetStream(owner, 2, 4);

      expected = new byte[] { 5, 6, 0, 0, 0, 0, 0, 0, 3, 4 };
      expectedRead = 2;

      actual = new byte[10];

      target.Read(actual, 8, 2);

      // act
      actualRead = target.Read(actual, 0, 100);

      // assert
      CollectionAssert.AreEqual(expected, actual);
      Assert.AreEqual(expectedRead, actualRead);
    }

    #endregion Public Methods
  }
}