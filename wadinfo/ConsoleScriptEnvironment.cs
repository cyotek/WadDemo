using Cyotek.Data;
using Cyotek.Scripting.JavaScript;
using System;
using System.IO;

// Adding Scripting to .NET Applications
// https://www.cyotek.com/blog/adding-scripting-to-net-applications

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.ScriptingHost
{
  internal class ConsoleScriptEnvironment : ScriptEnvironment
  {
    #region Private Fields

    private WadFile _wadFile;

    private string _wadFileName;

    #endregion Private Fields

    #region Protected Methods

    protected override void ClearScreen()
    {
      Console.Clear();
    }

    protected override void InitializeEnvironment()
    {
      this.AddFunction("createWad", new Action<string, WadType>(this.CreateWad));
      this.AddFunction("addFile", new Func<string, string, char, WadLump>(this.AddFile));
      this.AddFunction("closeWad", new Action(this.CloseWad));
      this.AddType("WadType", typeof(WadType));
      this.AddType("WadLump", typeof(WadLump));
      this.AddType("WadFile", typeof(WadFile));

      base.InitializeEnvironment();
    }

    protected override void ShowAlert(string message)
    {
      Console.WriteLine(message);
      Console.ReadKey(true);
    }

    protected override bool ShowConfirm(string message)
    {
      throw new NotImplementedException();
    }

    protected override string ShowPrompt(string message, string defaultValue)
    {
      throw new NotImplementedException();
    }

    protected override void WriteLine(string value)
    {
      Console.WriteLine(value);
    }

    #endregion Protected Methods

    #region Private Methods

    private WadLump AddFile(string name, string fileName, char fileType = '\0')
    {
      WadLump lump;

      lump = _wadFile.AddFile(name, this.GetFullFileName(fileName));
      lump.Type = (byte)fileType;

      return lump;
    }

    private void CloseWad()
    {
      if (_wadFile != null)
      {
        using (Stream stream = File.Create(_wadFileName))
        {
          _wadFile.Save(stream);
        }

        _wadFile = null;
      }
    }

    private void CreateWad(string fileName, WadType wadType)
    {
      this.CloseWad();

      _wadFileName = this.GetFullFileName(fileName);

      _wadFile = new WadFile(wadType);
    }

    private string GetFullFileName(string fileName)
    {
      return Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, fileName));
    }

    #endregion Private Methods
  }
}