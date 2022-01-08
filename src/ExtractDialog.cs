// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using Cyotek.Demo.Windows.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace Cyotek.Demo.Wad
{
  internal partial class ExtractDialog : BaseForm
  {
    #region Private Fields

    private bool _allowSelection;

    private ExtractOptions _options;

    #endregion Private Fields

    #region Public Constructors

    public ExtractDialog()
    {
      this.InitializeComponent();

      _allowSelection = true;
    }

    #endregion Public Constructors

    #region Public Properties

    public bool AllowSelection
    {
      get => _allowSelection;
      set => _allowSelection = value;
    }

    public ExtractOptions Options
    {
      get => _options;
      set => _options = value;
    }

    #endregion Public Properties

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (!_allowSelection)
      {
        selectedFilesRadioButton.Enabled = false;
        allFilesRadioButton.Checked = true;
      }
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
      string path;

      path = pathTextBox.Text;

      this.DialogResult = DialogResult.None;

      if (string.IsNullOrEmpty(path))
      {
        MessageBox.Show("Enter or select the path to extract files into.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (!Directory.Exists(path))
      {
        MessageBox.Show("The specified path does not exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        _options = new ExtractOptions
        {
          Path = path,
          ExtractMode = this.GetExtractMode(),
          OverwriteMode = this.GetOverwriteMode(),
          OpenExplorerWindow = explorerCheckBox.Checked,
          CreateIndex = indexCheckBox.Checked
        };

        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private ExtractMode GetExtractMode()
    {
      return allFilesRadioButton.Checked ? ExtractMode.All : ExtractMode.Selection;
    }

    private ExtractOverwriteMode GetOverwriteMode()
    {
      return preserveRadioButton.Checked
         ? ExtractOverwriteMode.Preserve
         : overwriteRadioButton.Checked
            ? ExtractOverwriteMode.Overwrite
            : ExtractOverwriteMode.Prompt;
    }

    private void PathBrowseButton_Click(object sender, EventArgs e)
    {
      string path;

      path = FileDialogHelper.GetFolderName("Select extract path:", pathTextBox.Text);

      if (!string.IsNullOrEmpty(path))
      {
        pathTextBox.Text = path;
      }
    }

    #endregion Private Methods
  }
}