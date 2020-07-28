﻿using Cyotek.Data.Wad;
using Cyotek.Windows.Forms.Demo;
using System;
using System.IO;
using System.Windows.Forms;

// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.Wad
{
  internal partial class MakeWadDialog : BaseForm
  {
    #region Private Fields

    private MakeWadOptions _options;

    #endregion Private Fields

    #region Public Constructors

    public MakeWadDialog()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Properties

    public MakeWadOptions Options
    {
      get { return _options; }
      set { _options = value; }
    }

    #endregion Public Properties

    #region Private Methods

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void ExtractButton_Click(object sender, EventArgs e)
    {
      string fileName;
      string indexFileName;

      fileName = fileNameTextBox.Text;
      indexFileName = indexFileNameTextBox.Text;

      this.DialogResult = DialogResult.None;

      if (string.IsNullOrEmpty(fileName))
      {
        MessageBox.Show("Enter or select the file name of the WAD to create.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (string.IsNullOrEmpty(indexFileName))
      {
        MessageBox.Show("Enter or select the file name of the index.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (!File.Exists(indexFileName))
      {
        MessageBox.Show("The specified index does not exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        _options = new MakeWadOptions
        {
          FileName = fileName,
          IndexFileName = indexFileName,
          Type = this.GetWadType()
        };

        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private WadType GetWadType()
    {
      return internalRadioButton.Checked ? WadType.Internal : WadType.Patch;
    }

    private void IndexBrowseButton_Click(object sender, EventArgs e)
    {
      string fileName;

      fileName = FileDialogHelper.GetOpenFileName("Choose Index File", Filters.Text, "txt", indexFileNameTextBox.Text);

      if (!string.IsNullOrEmpty(fileName))
      {
        indexFileNameTextBox.Text = fileName;
      }
    }

    private void PathBrowseButton_Click(object sender, EventArgs e)
    {
      string fileName;

      fileName = FileDialogHelper.GetSaveFileName("Create WAD File", Filters.Wad, "wad", fileNameTextBox.Text);

      if (!string.IsNullOrEmpty(fileName))
      {
        fileNameTextBox.Text = fileName;
      }
    }

    #endregion Private Methods
  }
}