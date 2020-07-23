using CommandLine;
using Cyotek.Tools.WadInfo.Commands;
using Cyotek.Tools.WadInfo.Verbs;
using System;
using System.Diagnostics;

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
        typeof(ListGapsVerbOptions)
      };

      Parser.Default.ParseArguments(args, types)
            .WithParsed(Run);

      if (Debugger.IsAttached)
      {
        Console.WriteLine("(Press any key to exit.)");
        Console.ReadKey(true);
      }
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

        case ListGapsVerbOptions listGaps:
          new ListGapsCommand().Run(listGaps);
          break;
      }
    }

    #endregion Private Methods
  }
}