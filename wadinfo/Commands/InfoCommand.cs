using Cyotek.Data.Wad;
using Cyotek.Tools.WadInfo.Verbs;
using System;
using System.IO;

namespace Cyotek.Tools.WadInfo.Commands
{
  internal sealed class InfoCommand : Command<InfoVerbOptions>
  {
    #region Public Methods

    public override void Run(InfoVerbOptions options)
    {
      string fileName;

      fileName = options.FileName;

      using (Stream stream = File.OpenRead(fileName))
      {
        using (WadReader reader = new WadReader(stream))
        {
          WadLump lump;

          Console.WriteLine("File: {0}", fileName);
          Console.WriteLine("Type: {0}", reader.Type);
          Console.WriteLine("Lump Count: {0}", reader.Count);

          while ((lump = reader.GetNextLump()) != null)
          {
            Console.WriteLine("{0}: Offset {1}, Size {2}", lump.Name, lump.Offset, lump.Size);
          }
        }
      }
    }

    #endregion Public Methods
  }
}