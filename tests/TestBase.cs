using System;
using System.IO;
using System.Text;

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

    protected Stream CreateSampleWad()
    {
      MemoryStream output;

      output = new MemoryStream();

      using (WadOutputStream target = new WadOutputStream(output))
      {
        using (BinaryWriter writer = new BinaryWriter(target, Encoding.UTF8, true))
        {
          target.PutNextEntry("P_START");
          target.PutNextEntry("PHOTO1");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo1.jpg")));
          target.PutNextEntry("PHOTO2");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo2.jpg")));
          target.PutNextEntry("PHOTO5");
          writer.Write(File.ReadAllBytes(this.GetDataFileName("photo5.jpg")));
          target.PutNextEntry("P_END");
        }
      }

      output.Position = 0;

      return output;
    }

    #endregion Protected Methods
  }
}