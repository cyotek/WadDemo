using Cyotek.Data.Wad;
using Cyotek.Demo.Windows.Forms;
using System;
using System.Drawing;
using System.IO;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.Wad
{
  internal class DoomWadRangeParser
  {
    #region Public Methods

    public void AddRanges(HexViewer control, byte[] buffer)
    {
      control.Clear();

      using (Stream stream = new MemoryStream(buffer))
      {
        using (WadReader reader = new WadReader(stream))
        {
          WadLump lump;
          int pointer;
          int counter;

          pointer = reader.DirectoryStart;
          counter = 1;

          control.AddRange(0, 4, Color.MediumSeaGreen, Color.White, "Signature");
          control.AddRange(4, 4, Color.SeaGreen, Color.White, "Lump Count");
          control.AddRange(new HexViewer.ByteGroup
          {
            Start = 8,
            Length = 4,
            BackColor = Color.DeepPink,
            ForeColor = Color.White,
            Type = "Directory Start",
            Pointer = BitConverter.ToInt32(buffer, 8)
          });

          while ((lump = reader.GetNextLump()) != null)
          {
            control.AddRange(new HexViewer.ByteGroup
            {
              Start = pointer,
              Length = 16,
              BackColor = Color.HotPink,
              ForeColor = Color.White,
              Type = "Directory Entry #" + counter + " [" + lump.Name + "]",
              Pointer = lump.Offset
            });

            if (lump.Offset != 0 && lump.Size > 0)
            {
              control.AddRange(new HexViewer.ByteGroup
              {
                Start = lump.Offset,
                Length = 1,
                BackColor = Color.DarkBlue,
                ForeColor = Color.White,
                Type = lump.Name + " (Start)",
                Pointer = pointer
              });

              control.AddRange(new HexViewer.ByteGroup
              {
                Start = lump.Offset + 1,
                Length = lump.Size - 2,
                BackColor = Color.LightSkyBlue,
                ForeColor = Color.Black,
                Type = lump.Name,
                Pointer = pointer
              });

              control.AddRange(new HexViewer.ByteGroup
              {
                Start = lump.Offset + lump.Size - 1,
                Length = 1,
                BackColor = Color.OrangeRed,
                ForeColor = Color.White,
                Type = lump.Name + " (End)",
                Pointer = pointer
              });
            }

            pointer += 16;
            counter++;
          }
        }
      }

      control.SortRanges();

      control.Invalidate();
    }

    #endregion Public Methods
  }
}