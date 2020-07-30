using System;
using System.IO;
using System.Text;

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
  public class TestBase
  {
    #region Private Fields

    private string _dataPath;

    #endregion Private Fields

    #region Public Properties

    public string DataPath
    {
      get { return _dataPath ?? (_dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data")); }
    }

    #endregion Public Properties

    #region Public Methods

    public string GetDataFileName(string baseName)
    {
      return Path.Combine(this.DataPath, baseName);
    }

    #endregion Public Methods

    #region Protected Methods

    protected Stream CreateGroupedSampleWad()
    {
      MemoryStream output;

      output = new MemoryStream();

      using (WadOutputStream target = new WadOutputStream(output))
      {
        using (BinaryWriter writer = new BinaryWriter(target, Encoding.UTF8, true))
        {
          target.PutNextLump("P_START");
          target.PutNextLump("P1_START");
          target.PutNextLump("INFO");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo1.inf")));
          target.PutNextLump("DATA");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo1.jpg")));
          target.PutNextLump("P1_END");
          target.PutNextLump("P2_START");
          target.PutNextLump("INFO");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo2.inf")));
          target.PutNextLump("DATA");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo2.jpg")));
          target.PutNextLump("P2_END");
          target.PutNextLump("P3_START");
          target.PutNextLump("INFO");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo5.inf")));
          target.PutNextLump("DATA");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo5.jpg")));
          target.PutNextLump("P3_END");
          target.PutNextLump("P_END");
        }
      }

      output.Position = 0;

      return output;
    }

    protected Stream CreateSampleWad()
    {
      MemoryStream output;

      output = new MemoryStream();

      using (WadOutputStream target = new WadOutputStream(output))
      {
        using (BinaryWriter writer = new BinaryWriter(target, Encoding.UTF8, true))
        {
          target.PutNextLump("PHOTO1");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo1.inf")));
          target.PutNextLump("PHOTO2");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo2.inf")));
          target.PutNextLump("PHOTO5");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo5.inf")));
        }
      }

      output.Position = 0;

      return output;
    }

    protected Stream CreateUnoptomizedSampleWad()
    {
      MemoryStream output;
      byte[] header;
      byte[] dirHeader1;
      byte[] dirHeader2;
      byte[] dirHeader3;

      output = new MemoryStream();

      header = new byte[12];
      header[0] = (byte)'P';
      header[1] = (byte)'W';
      header[2] = (byte)'A';
      header[3] = (byte)'D';
      WordHelpers.PutInt32Le(3, header, 4);

      this.WriteBuffer(output, header);
      dirHeader3 = this.WriteFile(output, "photo5.inf");
      dirHeader1 = this.WriteFile(output, "photo1.inf");
      dirHeader2 = this.WriteFile(output, "photo2.inf");

      WordHelpers.PutInt32Le((int)output.Position, header, 8);

      this.WriteBuffer(output, dirHeader1);
      this.WriteBuffer(output, dirHeader2);
      this.WriteBuffer(output, dirHeader3);

      output.Position = 0;
      this.WriteBuffer(output, header);

      output.Position = 0;

      return output;
    }

    #endregion Protected Methods

    #region Private Methods

    private void WriteBuffer(Stream stream, byte[] buffer)
    {
      stream.Write(buffer, 0, buffer.Length);
    }

    private byte[] WriteFile(Stream stream, string fileName)
    {
      byte[] header;
      byte[] buffer;
      string name;

      buffer = File.ReadAllBytes(this.GetDataFileName(fileName));
      name = Path.GetFileNameWithoutExtension(fileName).ToUpperInvariant();

      header = new byte[16];
      WordHelpers.PutInt32Le((int)stream.Position, header, 0);
      WordHelpers.PutInt32Le(buffer.Length, header, 4);
      for (int i = 0; i < name.Length; i++)
      {
        header[i + 8] = (byte)name[i];
      }

      stream.Write(buffer, 0, buffer.Length);

      return header;
    }

    #endregion Private Methods
  }
}