using Cyotek.Data.Wad;
using System;
using System.IO;

namespace Cyotek.Tools.WadInfo
{
  internal static class Program
  {
    #region Public Methods

    public static void Main(string[] args)
    {
      for (int i = 0; i < args.Length; i++)
      {
        Program.WriteWadInfo(Path.Combine(Environment.CurrentDirectory, args[i]));
      }
    }

    #endregion Public Methods

    #region Private Methods

    private static void WriteWadInfo(string fileName)
    {
      using (Stream stream = File.OpenRead(fileName))
      {
        WadReader reader;
        WadLump lump;

        reader = new WadReader(stream);

        Console.WriteLine("File: {0}", fileName);
        Console.WriteLine("Type: {0}", reader.Type);
        Console.WriteLine("Lump Count: {0}", reader.Count);

        while ((lump = reader.GetNextLump()) != null)
        {
          Console.WriteLine("{0}: Offset {1}, Size {2}", lump.Name, lump.Offset, lump.Size);
        }
      }
    }

    #endregion Private Methods
  }
}