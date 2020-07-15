namespace Cyotek.Demo.Wad
{
  partial class ExtractDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.allFilesRadioButton = new System.Windows.Forms.RadioButton();
      this.selectedFilesRadioButton = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.pathTextBox = new System.Windows.Forms.TextBox();
      this.pathBrowseButton = new System.Windows.Forms.Button();
      this.explorerCheckBox = new System.Windows.Forms.CheckBox();
      this.indexCheckBox = new System.Windows.Forms.CheckBox();
      this.extractButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.preserveRadioButton = new System.Windows.Forms.RadioButton();
      this.overwriteRadioButton = new System.Windows.Forms.RadioButton();
      this.promptRadioButton = new System.Windows.Forms.RadioButton();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.allFilesRadioButton);
      this.groupBox1.Controls.Add(this.selectedFilesRadioButton);
      this.groupBox1.Location = new System.Drawing.Point(15, 40);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(123, 88);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Files";
      // 
      // allFilesRadioButton
      // 
      this.allFilesRadioButton.AutoSize = true;
      this.allFilesRadioButton.Location = new System.Drawing.Point(6, 42);
      this.allFilesRadioButton.Name = "allFilesRadioButton";
      this.allFilesRadioButton.Size = new System.Drawing.Size(57, 17);
      this.allFilesRadioButton.TabIndex = 1;
      this.allFilesRadioButton.Text = "&All files";
      this.allFilesRadioButton.UseVisualStyleBackColor = true;
      // 
      // selectedFilesRadioButton
      // 
      this.selectedFilesRadioButton.AutoSize = true;
      this.selectedFilesRadioButton.Checked = true;
      this.selectedFilesRadioButton.Location = new System.Drawing.Point(6, 19);
      this.selectedFilesRadioButton.Name = "selectedFilesRadioButton";
      this.selectedFilesRadioButton.Size = new System.Drawing.Size(88, 17);
      this.selectedFilesRadioButton.TabIndex = 0;
      this.selectedFilesRadioButton.TabStop = true;
      this.selectedFilesRadioButton.Text = "&Selected files";
      this.selectedFilesRadioButton.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "E&xtract to:";
      // 
      // pathTextBox
      // 
      this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pathTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.pathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
      this.pathTextBox.Location = new System.Drawing.Point(73, 14);
      this.pathTextBox.Name = "pathTextBox";
      this.pathTextBox.Size = new System.Drawing.Size(352, 20);
      this.pathTextBox.TabIndex = 1;
      // 
      // pathBrowseButton
      // 
      this.pathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pathBrowseButton.Location = new System.Drawing.Point(431, 12);
      this.pathBrowseButton.Name = "pathBrowseButton";
      this.pathBrowseButton.Size = new System.Drawing.Size(75, 23);
      this.pathBrowseButton.TabIndex = 2;
      this.pathBrowseButton.Text = "&Browse...";
      this.pathBrowseButton.UseVisualStyleBackColor = true;
      this.pathBrowseButton.Click += new System.EventHandler(this.PathBrowseButton_Click);
      // 
      // explorerCheckBox
      // 
      this.explorerCheckBox.AutoSize = true;
      this.explorerCheckBox.Location = new System.Drawing.Point(273, 40);
      this.explorerCheckBox.Name = "explorerCheckBox";
      this.explorerCheckBox.Size = new System.Drawing.Size(132, 17);
      this.explorerCheckBox.TabIndex = 5;
      this.explorerCheckBox.Text = "Open Explorer &window";
      this.explorerCheckBox.UseVisualStyleBackColor = true;
      // 
      // indexCheckBox
      // 
      this.indexCheckBox.AutoSize = true;
      this.indexCheckBox.Location = new System.Drawing.Point(273, 63);
      this.indexCheckBox.Name = "indexCheckBox";
      this.indexCheckBox.Size = new System.Drawing.Size(86, 17);
      this.indexCheckBox.TabIndex = 6;
      this.indexCheckBox.Text = "Create &Index";
      this.indexCheckBox.UseVisualStyleBackColor = true;
      // 
      // extractButton
      // 
      this.extractButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.extractButton.Location = new System.Drawing.Point(431, 81);
      this.extractButton.Name = "extractButton";
      this.extractButton.Size = new System.Drawing.Size(75, 23);
      this.extractButton.TabIndex = 7;
      this.extractButton.Text = "&Extract";
      this.extractButton.UseVisualStyleBackColor = true;
      this.extractButton.Click += new System.EventHandler(this.ExtractButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(431, 110);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 8;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.promptRadioButton);
      this.groupBox2.Controls.Add(this.preserveRadioButton);
      this.groupBox2.Controls.Add(this.overwriteRadioButton);
      this.groupBox2.Location = new System.Drawing.Point(144, 40);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(123, 88);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Overwrite";
      // 
      // preserveRadioButton
      // 
      this.preserveRadioButton.AutoSize = true;
      this.preserveRadioButton.Location = new System.Drawing.Point(6, 42);
      this.preserveRadioButton.Name = "preserveRadioButton";
      this.preserveRadioButton.Size = new System.Drawing.Size(89, 17);
      this.preserveRadioButton.TabIndex = 1;
      this.preserveRadioButton.Text = "&Keep Existing";
      this.preserveRadioButton.UseVisualStyleBackColor = true;
      // 
      // overwriteRadioButton
      // 
      this.overwriteRadioButton.AutoSize = true;
      this.overwriteRadioButton.Checked = true;
      this.overwriteRadioButton.Location = new System.Drawing.Point(6, 19);
      this.overwriteRadioButton.Name = "overwriteRadioButton";
      this.overwriteRadioButton.Size = new System.Drawing.Size(70, 17);
      this.overwriteRadioButton.TabIndex = 0;
      this.overwriteRadioButton.TabStop = true;
      this.overwriteRadioButton.Text = "&Overwrite";
      this.overwriteRadioButton.UseVisualStyleBackColor = true;
      // 
      // promptRadioButton
      // 
      this.promptRadioButton.AutoSize = true;
      this.promptRadioButton.Location = new System.Drawing.Point(6, 65);
      this.promptRadioButton.Name = "promptRadioButton";
      this.promptRadioButton.Size = new System.Drawing.Size(58, 17);
      this.promptRadioButton.TabIndex = 2;
      this.promptRadioButton.Text = "&Prompt";
      this.promptRadioButton.UseVisualStyleBackColor = true;
      // 
      // ExtractDialog
      // 
      this.AcceptButton = this.extractButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(518, 145);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.extractButton);
      this.Controls.Add(this.indexCheckBox);
      this.Controls.Add(this.explorerCheckBox);
      this.Controls.Add(this.pathBrowseButton);
      this.Controls.Add(this.pathTextBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.groupBox1);
      this.Name = "ExtractDialog";
      this.Text = "Extract";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton allFilesRadioButton;
    private System.Windows.Forms.RadioButton selectedFilesRadioButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox pathTextBox;
    private System.Windows.Forms.Button pathBrowseButton;
    private System.Windows.Forms.CheckBox explorerCheckBox;
    private System.Windows.Forms.CheckBox indexCheckBox;
    private System.Windows.Forms.Button extractButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.RadioButton promptRadioButton;
    private System.Windows.Forms.RadioButton preserveRadioButton;
    private System.Windows.Forms.RadioButton overwriteRadioButton;
  }
}