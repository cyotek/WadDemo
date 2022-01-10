// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using Cyotek.Data;
using Cyotek.Tools.WadInfo.Verbs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cyotek.Tools.WadInfo.Commands
{
  internal sealed class CompareCommand : Command<CompareVerbOptions>
  {
    #region Public Methods

    public override void Run(CompareVerbOptions options)
    {
      string workingDirectory;
      string fileName1;
      string fileName2;
      WadFile wad1;
      WadFile wad2;

      workingDirectory = Environment.CurrentDirectory;
      fileName1 = Path.Combine(workingDirectory, options.FirstFileName);
      fileName2 = Path.Combine(workingDirectory, options.SecondFileName);
      wad1 = WadFile.LoadFrom(fileName1);
      wad2 = WadFile.LoadFrom(fileName2);

      this.Compare(wad1.Type, wad2.Type, "WAD types do not match.");
      this.Compare(wad1.Lumps.Count, wad2.Lumps.Count, "Lump counts do not match.");

      for (int i = 0; i < wad1.Lumps.Count; i++)
      {
        WadLump x;
        WadLump y;

        x = wad1.Lumps[i];
        y = wad2.Lumps[i];

        this.Compare(x.Name, y.Name, "Name of lump {0} does not match.", i);
        this.Compare(x.Offset, y.Offset, "Data offset of lump {0} does not match.", i);
        this.Compare(x.Size, y.Size, "Size of lump {0} does not match.", i);
        this.Compare(x.UncompressedSize, y.UncompressedSize, "Uncompressed size of lump {0} does not match.", i);
        this.Compare(x.Type, y.Type, "File type of lump {0} does not match.", i);
        this.Compare(x.CompressionMode, y.CompressionMode, "Compression mode of lump {0} does not match.", i);
        this.Compare(this.ReadData(x), this.ReadData(y), "Data of lump {0} does not match.", i);
      }
    }

    #endregion Public Methods

    #region Private Methods

    private void Compare<T>(T value1, T value2, string format)
    {
      this.Compare(value1, value2, format, string.Empty);
    }

    private void Compare<T>(T value1, T value2, string format, object arg0)
    {
      if (!EqualityComparer<T>.Default.Equals(value1, value2))
      {
        Console.Write(format, arg0);
        Console.WriteLine();
        Console.Write("\tFirst: {0}\n", value1);
        Console.Write("\tSecond: {0}\n", value2);
      }
    }

    private void Compare(byte[] value1, byte[] value2, string format, object arg0)
    {
      if (!value1.SequenceEqual(value2))
      {
        Console.Write(format, arg0);
        Console.WriteLine();
        Console.Write("\tFirst: {0}\n", value1);
        Console.Write("\tSecond: {0}\n", value2);
      }
    }

    private byte[] ReadData(WadLump lump)
    {
      using (MemoryStream output = new MemoryStream())
      {
        using (Stream input = lump.GetInputStream())
        {
          input.CopyTo(output);
        }

        return output.ToArray();
      }
    }

    #endregion Private Methods
  }
}