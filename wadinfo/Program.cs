using CommandLine;
using Cyotek.Tools.WadInfo.Commands;
using Cyotek.Tools.WadInfo.Verbs;
using System;
using System.Diagnostics;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Tools.WadInfo
{
  internal static class Program
  {
    #region Public Methods

    public static void Main(string[] args)
    {
      Type[] types;

      types = new[]
      {
        typeof(InfoVerbOptions),
        typeof(CreateVerbOptions),
        typeof(CompareVerbOptions),
        typeof(ListGapsVerbOptions)
      };

      Parser.Default.ParseArguments(args, types)
            .WithParsed(Run);
    }

    #endregion Public Methods

    #region Private Methods

    private static void Run(object obj)
    {
      switch (obj)
      {
        case InfoVerbOptions info:
          new InfoCommand().Run(info);
          break;

        case CreateVerbOptions create:
          new CreateCommand().Run(create);
          break;

        case CompareVerbOptions compare:
          new CompareCommand().Run(compare);
          break;

        case ListGapsVerbOptions listGaps:
          new ListGapsCommand().Run(listGaps);
          break;
      }
    }

    #endregion Private Methods
  }
}