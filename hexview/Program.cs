using Cyotek.Windows.Forms.Demo;
using System;
using System.Windows.Forms;

namespace Cyotek.Demo.Wad
{
  internal static class Program
  {
    #region Public Methods

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }

    #endregion Public Methods
  }
}