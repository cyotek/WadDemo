﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Cyotek.Demo
{
  internal static class ProcessHelper
  {
    #region Public Methods

    public static void OpenFolderInExplorer(string folderName)
    {
      if (string.IsNullOrEmpty(folderName))
      {
        MessageBox.Show("Folder not specified.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      //else if (!PathEx.IsValidFullPath(folderName))
      //{
      //  MessageBox.Show(string.Format("Folder '{0}' is invalid.", folderName), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      //}
      else if (!Directory.Exists(folderName))
      {
        MessageBox.Show(string.Format("Folder '{0}' does not exist.", folderName), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        ProcessHelper.StartProcess(string.Format("{0}\\explorer.exe", Environment.ExpandEnvironmentVariables("%windir%")), string.Format("/n,\"{0}\"", folderName));
      }
    }

    public static bool StartProcess(string processName, string arguments)
    {
      bool result;

      try
      {
        ProcessStartInfo info;
        Process process;

        info = new ProcessStartInfo
        {
          FileName = processName,
          Arguments = arguments
        };

        process = new Process
        {
          StartInfo = info
        };

        process.Start();

        result = true;
      }
      catch (Exception ex)
      {
        result = false;
        MessageBox.Show(string.Format("Failed to open {0}. {1}", processName, ex.GetBaseException().Message), "Open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      return result;
    }

    #endregion Public Methods
  }
}