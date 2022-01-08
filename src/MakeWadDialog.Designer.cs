namespace Cyotek.Demo.Wad
{
  partial class MakeWadDialog
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
      System.Windows.Forms.Label fileNameLabel;
      System.Windows.Forms.Label indexFileNameLabel;
      System.Windows.Forms.Label typeLabel;
      this.fileNameTextBox = new System.Windows.Forms.TextBox();
      this.pathBrowseButton = new System.Windows.Forms.Button();
      this.createButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.indexFileNameTextBox = new System.Windows.Forms.TextBox();
      this.indexBrowseButton = new System.Windows.Forms.Button();
      this.typeComboBox = new System.Windows.Forms.ComboBox();
      fileNameLabel = new System.Windows.Forms.Label();
      indexFileNameLabel = new System.Windows.Forms.Label();
      typeLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // fileNameLabel
      // 
      fileNameLabel.AutoSize = true;
      fileNameLabel.Location = new System.Drawing.Point(12, 17);
      fileNameLabel.Name = "fileNameLabel";
      fileNameLabel.Size = new System.Drawing.Size(52, 13);
      fileNameLabel.TabIndex = 0;
      fileNameLabel.Text = "&Filename:";
      // 
      // fileNameTextBox
      // 
      this.fileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.fileNameTextBox.Location = new System.Drawing.Point(73, 14);
      this.fileNameTextBox.Name = "fileNameTextBox";
      this.fileNameTextBox.Size = new System.Drawing.Size(352, 20);
      this.fileNameTextBox.TabIndex = 1;
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
      // createButton
      // 
      this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.createButton.Location = new System.Drawing.Point(431, 83);
      this.createButton.Name = "createButton";
      this.createButton.Size = new System.Drawing.Size(75, 23);
      this.createButton.TabIndex = 8;
      this.createButton.Text = "&Create";
      this.createButton.UseVisualStyleBackColor = true;
      this.createButton.Click += new System.EventHandler(this.ExtractButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(431, 112);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 9;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // indexFileNameLabel
      // 
      indexFileNameLabel.AutoSize = true;
      indexFileNameLabel.Location = new System.Drawing.Point(12, 43);
      indexFileNameLabel.Name = "indexFileNameLabel";
      indexFileNameLabel.Size = new System.Drawing.Size(55, 13);
      indexFileNameLabel.TabIndex = 3;
      indexFileNameLabel.Text = "I&ndex File:";
      // 
      // indexFileNameTextBox
      // 
      this.indexFileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.indexFileNameTextBox.Location = new System.Drawing.Point(73, 40);
      this.indexFileNameTextBox.Name = "indexFileNameTextBox";
      this.indexFileNameTextBox.Size = new System.Drawing.Size(352, 20);
      this.indexFileNameTextBox.TabIndex = 4;
      // 
      // indexBrowseButton
      // 
      this.indexBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.indexBrowseButton.Location = new System.Drawing.Point(431, 38);
      this.indexBrowseButton.Name = "indexBrowseButton";
      this.indexBrowseButton.Size = new System.Drawing.Size(75, 23);
      this.indexBrowseButton.TabIndex = 5;
      this.indexBrowseButton.Text = "B&rowse...";
      this.indexBrowseButton.UseVisualStyleBackColor = true;
      this.indexBrowseButton.Click += new System.EventHandler(this.IndexBrowseButton_Click);
      // 
      // typeLabel
      // 
      typeLabel.AutoSize = true;
      typeLabel.Location = new System.Drawing.Point(12, 69);
      typeLabel.Name = "typeLabel";
      typeLabel.Size = new System.Drawing.Size(34, 13);
      typeLabel.TabIndex = 6;
      typeLabel.Text = "&Type:";
      // 
      // typeComboBox
      // 
      this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.typeComboBox.FormattingEnabled = true;
      this.typeComboBox.Items.AddRange(new object[] {
            "Patch",
            "Internal",
            "Wad2",
            "Wad3",
            "Pack"});
      this.typeComboBox.Location = new System.Drawing.Point(73, 66);
      this.typeComboBox.Name = "typeComboBox";
      this.typeComboBox.Size = new System.Drawing.Size(168, 21);
      this.typeComboBox.TabIndex = 7;
      // 
      // MakeWadDialog
      // 
      this.AcceptButton = this.createButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(518, 147);
      this.Controls.Add(typeLabel);
      this.Controls.Add(this.typeComboBox);
      this.Controls.Add(this.indexBrowseButton);
      this.Controls.Add(this.indexFileNameTextBox);
      this.Controls.Add(indexFileNameLabel);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.createButton);
      this.Controls.Add(this.pathBrowseButton);
      this.Controls.Add(this.fileNameTextBox);
      this.Controls.Add(fileNameLabel);
      this.Name = "MakeWadDialog";
      this.Text = "Create";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox fileNameTextBox;
    private System.Windows.Forms.Button pathBrowseButton;
    private System.Windows.Forms.Button createButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.TextBox indexFileNameTextBox;
    private System.Windows.Forms.Button indexBrowseButton;
    private System.Windows.Forms.ComboBox typeComboBox;
  }
}