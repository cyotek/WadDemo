// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using Cyotek.Data;
using Cyotek.Demo.Windows.Forms;
using System;
using System.IO;
using System.Windows.Forms;

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
      get => _options;
      set => _options = value;
    }

    #endregion Public Properties

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      typeComboBox.SelectedIndex = 0;
    }

    #endregion Protected Methods

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
      return (WadType)Enum.Parse(typeof(WadType), (string)typeComboBox.SelectedItem);
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