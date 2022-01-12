// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using Cyotek.Data;
using Cyotek.Demo.ScriptingHost;
using Cyotek.Tools.WadInfo.Verbs;
using System;
using System.IO;

namespace Cyotek.Tools.WadInfo.Commands
{
  internal sealed class CreateCommand : Command<CreateVerbOptions>
  {
    #region Public Methods

    public override void Run(CreateVerbOptions options)
    {
      string workingDirectory;
      string fileName;
      string script;
      ConsoleScriptEnvironment env;

      workingDirectory = Environment.CurrentDirectory;
      fileName = Path.Combine(workingDirectory, options.FileName);
      script = File.ReadAllText(fileName);
      env = new ConsoleScriptEnvironment();
      env.Load(script);
    }

    #endregion Public Methods
  }
}