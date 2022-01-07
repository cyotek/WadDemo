// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using Be.Windows.Forms;
using Cyotek.Data;
using Cyotek.Demo.Wad;
using Cyotek.Demo.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Cyotek.Demo
{
  internal partial class MainForm : BaseForm
  {
    #region Private Fields

    private const short _paletteSize = 768;

    private string _fileName;

    private WadLump _selectedLump;

    private bool _useNameSort;

    private WadFile _wadFile;

    #endregion Private Fields

    #region Public Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      string[] args;

      base.OnLoad(e);

      this.CloseWad();

      args = Environment.GetCommandLineArgs();

      if (args.Length == 2)
      {
        this.OpenWad(args[1]);
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutDialog.ShowAboutDialog();
    }

    private void CloseWad()
    {
      namesListBox.Items.Clear();
      hexBox.ByteProvider = null;
      _wadFile = null;
      _fileName = null;

      this.UpdateStatus();
      this.UpdateWindowTitle();
    }

    private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      hexBox.Copy();
    }

    private void Create(MakeWadOptions options)
    {
      // TODO: Use background worker

      this.SetStatus("Creating...");

      this.ReadIndex(options, out List<string> names, out List<string> files);

      toolStripProgressBar.Maximum = names.Count;

      using (Stream output = File.Create(options.FileName))
      {
        using (WadOutputStream wad = new WadOutputStream(output, options.Type))
        {
          for (int i = 0; i < names.Count; i++)
          {
            toolStripProgressBar.Value++;

            wad.PutNextLump(names[i]);

            using (Stream input = File.OpenRead(files[i]))
            {
              input.CopyTo(wad);
            }
          }
        }
      }

      toolStripProgressBar.Value = 0;
      this.SetStatus(string.Empty);
    }

    private void CyotekLinkToolStripStatusLabel_Click(object sender, EventArgs e)
    {
      AboutDialog.OpenCyotekHomePage();

      cyotekLinkToolStripStatusLabel.LinkVisited = true;
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Extract(ExtractOptions options)
    {
      List<ExtractResult> results;

      // TODO: Use background worker

      this.SetStatus("Extracting...");

      if (options.ExtractMode == ExtractMode.All)
      {
        results = this.ExtractAll(options);
      }
      else
      {
        results = this.ExtractSelection(options);
      }

      if (options.CreateIndex)
      {
        this.WriteIndex(options.Path, results);
      }

      if (options.OpenExplorerWindow)
      {
        ProcessHelper.OpenFolderInExplorer(options.Path);
      }

      toolStripProgressBar.Value = 0;
      this.SetStatus(string.Empty);
    }

    private ExtractResult Extract(WadLump lump, ExtractOptions options)
    {
      string fileName;
      ExtractResult result;

      fileName = Path.Combine(options.Path, this.MakeSafe(lump.Name));

      if (options.OverwriteMode == ExtractOverwriteMode.Preserve && File.Exists(fileName))
      {
        fileName = FileDialogHelper.GetNextFileName(options.Path, lump.Name);
      }

      result = new ExtractResult(lump, fileName);

      if (options.OverwriteMode == ExtractOverwriteMode.Overwrite
         || !File.Exists(fileName)
         || MessageBox.Show(string.Format("Overwrite {0}?", fileName), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        using (Stream output = File.Create(fileName))
        {
          using (Stream input = lump.GetInputStream())
          {
            input.CopyTo(output);
          }
        }
      }
      else
      {
        result.FileName = null;
      }

      return result;
    }

    private List<ExtractResult> ExtractAll(ExtractOptions options)
    {
      List<ExtractResult> results;

      toolStripProgressBar.Maximum = _wadFile.Lumps.Count;

      results = new List<ExtractResult>();

      for (int i = 0; i < _wadFile.Lumps.Count; i++)
      {
        results.Add(this.Extract(_wadFile.Lumps[i], options));
        toolStripProgressBar.Value++;
      }

      return results;
    }

    private void ExtractFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (ExtractDialog dialog = new ExtractDialog())
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          this.Extract(dialog.Options);
        }
      }
    }

    private void ExtractPalettesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      WadLump paletteLump;

      if ((paletteLump = _wadFile.Find("PLAYPAL")) != null)
      {
        if (paletteLump.Size % _paletteSize == 0)
        {
          string folder;

          if (!string.IsNullOrEmpty(folder = FileDialogHelper.GetFolderName("Select location to extract palettes to:")))
          {
            using (Stream input = paletteLump.GetInputStream())
            {
              byte[] buffer;

              buffer = new byte[_paletteSize];

              for (int i = 0; i < paletteLump.Size / _paletteSize; i++)
              {
                string fileName;

                fileName = Path.Combine(folder, Path.GetFileNameWithoutExtension(_fileName) + (i + 1) + ".pal");

                input.Read(buffer, 0, buffer.Length);

                File.WriteAllBytes(fileName, buffer);
              }
            }
          }
        }
        else
        {
          MessageBox.Show("Unexpected PLAYPAL lump size.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      else
      {
        MessageBox.Show("Could not find PLAYPAL lump.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private List<ExtractResult> ExtractSelection(ExtractOptions options)
    {
      List<ExtractResult> results;

      results = new List<ExtractResult>();

      for (int i = 0; i < namesListBox.SelectedItems.Count; i++)
      {
        results.Add(this.Extract((WadLump)namesListBox.SelectedItems[i], options));
      }

      return results;
    }

    private void FillItems()
    {
      namesListBox.BeginUpdate();
      namesListBox.Items.Clear();

      namesListBox.Sorted = false;

      for (int i = 0; i < _wadFile.Lumps.Count; i++)
      {
        namesListBox.Items.Add(_wadFile.Lumps[i]);
      }

      if (_useNameSort)
      {
        namesListBox.Sorted = true;
      }

      namesListBox.EndUpdate();
    }

    private void HexBox_SelectionStartChanged(object sender, EventArgs e)
    {
      this.UpdateHexStatus();
    }

    private void LumpNamesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StringBuilder sb;

      sb = new StringBuilder();

      for (int i = 0; i < _wadFile.Lumps.Count; i++)
      {
        sb.AppendLine(_wadFile.Lumps[i].Name);
      }

      InformationDialog.ShowDialog("Lump Names", "&Names:", sb.ToString());
    }

    private string MakeSafe(string name)
    {
      return name.Replace('\\', '-');
    }

    private void MakeWadToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (MakeWadDialog dialog = new MakeWadDialog())
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          this.Create(dialog.Options);
        }
      }
    }

    private void NamesListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      _selectedLump = namesListBox.SelectedItem as WadLump;

      hexBox.ByteProvider = _selectedLump != null ? new DynamicByteProvider(_selectedLump.ToArray()) : null;

      this.UpdateStatus();
    }

    private void NewToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.CloseWad();
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string fileName;

      fileName = FileDialogHelper.GetOpenFileName("Open File", Filters.Wad, "wad");

      if (!string.IsNullOrEmpty(fileName))
      {
        this.OpenWad(fileName);
      }
    }

    private void OpenWad(string fileName)
    {
      _wadFile = WadFile.LoadFrom(fileName);

      this.FillItems();

      _fileName = fileName;

      this.UpdateStatus();
      this.UpdateWindowTitle();
    }

    private void OriginalOrderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _useNameSort = false;
      this.UpdateSort();
    }

    private void ReadIndex(MakeWadOptions options, out List<string> names, out List<string> files)
    {
      names = new List<string>();
      files = new List<string>();

      using (TextReader reader = new StreamReader(options.IndexFileName))
      {
        string line;

        while ((line = reader.ReadLine()) != null)
        {
          int position;

          line = line.Trim();

          position = line.IndexOf(' ');

          if (position != -1)
          {
            names.Add(line.Substring(0, position));
            files.Add(line.Substring(position).Trim());
          }
        }
      }
    }

    private void SaveSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (hexBox.SelectionLength > 0)
      {
        string fileName;

        fileName = FileDialogHelper.GetSaveFileName("Save Selection As", Filters.AllFiles, string.Empty);

        if (!string.IsNullOrEmpty(fileName))
        {
          DynamicByteProvider provider;
          byte[] buffer;

          buffer = new byte[hexBox.SelectionLength];
          provider = (DynamicByteProvider)hexBox.ByteProvider;
          provider.Bytes.CopyTo((int)hexBox.SelectionStart, buffer, 0, buffer.Length);

          File.WriteAllBytes(fileName, buffer);
        }
      }
      else
      {
        MessageBox.Show("No content selected to save.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (namesListBox.Focused)
      {
        namesListBox.BeginUpdate();

        for (int i = 0; i < namesListBox.Items.Count; i++)
        {
          namesListBox.SetSelected(i, true);
        }

        namesListBox.EndUpdate();
      }
      else
      {
        hexBox.SelectAll();
      }
    }

    private void SetStatus(string message)
    {
      statusToolStripStatusLabel.Text = message;

      Cursor.Current = string.IsNullOrEmpty(message) ? Cursors.Default : Cursors.WaitCursor;
    }

    private void SortByNameToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _useNameSort = true;
      this.UpdateSort();
    }

    private void UpdateHexStatus()
    {
      hexStartToolStripStatusLabel.Text = string.Format("Idx: {0}", hexBox.SelectionStart);
      hexLengthToolStripStatusLabel.Text = string.Format("Sel: {0}", hexBox.SelectionLength);
    }

    private void UpdateSort()
    {
      originalOrderToolStripMenuItem.Checked = !_useNameSort;
      sortByNameToolStripMenuItem.Checked = _useNameSort;

      this.FillItems();
    }

    private void UpdateStatus()
    {
      sizeToolStripStatusLabel.Text = string.Format("Size: {0}", _selectedLump?.Size ?? 0);
      offsetToolStripStatusLabel.Text = string.Format("Offset: {0}", _selectedLump?.Offset ?? 0);
      lumpsToolStripStatusLabel.Text = string.Format("Lumps: {0}", _wadFile?.Lumps.Count ?? 0);
      this.UpdateHexStatus();
    }

    private void UpdateWindowTitle()
    {
      this.Text = string.Format("{1} - {0}", Application.ProductName, string.IsNullOrEmpty(_fileName) ? "Untitled" : Path.GetFileName(_fileName));
    }

    private void WriteIndex(string path, List<ExtractResult> results)
    {
      string fileName;

      fileName = Path.Combine(path, "index.txt");

      using (TextWriter writer = new StreamWriter(fileName))
      {
        for (int i = 0; i < results.Count; i++)
        {
          ExtractResult result;

          result = results[i];

          writer.Write(result.Lump.Name);
          for (int j = result.Lump.Name.Length; j < 10; j++)
          {
            writer.Write(' ');
          }
          writer.Write(result.FileName);
          writer.WriteLine();
        }

        writer.Flush();
      }
    }

    #endregion Private Methods
  }
}