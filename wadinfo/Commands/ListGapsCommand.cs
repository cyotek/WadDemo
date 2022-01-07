// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using Cyotek.Data;
using Cyotek.Tools.WadInfo.Verbs;
using System;
using System.Collections.Generic;
using System.IO;

namespace Cyotek.Tools.WadInfo.Commands
{
  internal sealed class ListGapsCommand : Command<ListGapsVerbOptions>
  {
    #region Public Methods

    public override void Run(ListGapsVerbOptions options)
    {
      string fileName;
      List<Range> ranges;
      List<Range> gaps;

      fileName = options.FileName;
      ranges = this.BuildRanges(fileName);
      gaps = this.BuildGaps(ranges);

      this.WriteGaps(gaps);
    }

    #endregion Public Methods

    #region Private Methods

    private List<Range> BuildGaps(List<Range> ranges)
    {
      List<Range> gaps;
      int position;

      gaps = new List<Range>();
      position = 0;

      for (int i = 0; i < ranges.Count; i++)
      {
        Range range;

        range = ranges[i];

        if (range.Start > position)
        {
          gaps.Add(new Range(position, range.Start - position));
        }

        position = range.End;
      }

      return gaps;
    }

    private List<Range> BuildRanges(string fileName)
    {
      List<Range> ranges;

      using (Stream stream = File.OpenRead(fileName))
      {
        using (WadReader reader = new WadReader(stream))
        {
          WadLump lump;

          ranges = new List<Range>(reader.Count + 2)
          {
            new Range(0, 12), // wad header
            new Range(reader.DirectoryStart, 16 * reader.Count) // directory index
          };

          while ((lump = reader.GetNextLump()) != null)
          {
            if (lump.Size > 0)
            {
              ranges.Add(new Range(lump.Offset, lump.Size));
            }
          }
        }
      }

      ranges.Sort((x, y) => x.Start.CompareTo(y.Start));

      return ranges;
    }

    private void WriteGaps(List<Range> gaps)
    {
      for (int i = 0; i < gaps.Count; i++)
      {
        Range gap;

        gap = gaps[i];

        Console.WriteLine("Start: {0}, End: {1}, Length: {2}", gap.Start, gap.End, gap.Length);
      }
    }

    #endregion Private Methods

    #region Private Structs

    private struct Range
    {
      #region Public Constructors

      public Range(int start, int length)
      {
        this.Start = start;
        this.Length = length;
      }

      #endregion Public Constructors

      #region Public Properties

      public int End => this.Start + this.Length;

      public int Length { get; set; }

      public int Start { get; set; }

      #endregion Public Properties

      #region Public Methods

      public override string ToString()
      {
        return string.Format("Range: Start={0}, Length={1}", this.Start, this.Length);
      }

      #endregion Public Methods
    }

    #endregion Private Structs
  }
}