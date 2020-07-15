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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.patchRadioButton = new System.Windows.Forms.RadioButton();
      this.internalRadioButton = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.fileNameTextBox = new System.Windows.Forms.TextBox();
      this.pathBrowseButton = new System.Windows.Forms.Button();
      this.createButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.indexFileNameTextBox = new System.Windows.Forms.TextBox();
      this.indexBrowseButton = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.patchRadioButton);
      this.groupBox1.Controls.Add(this.internalRadioButton);
      this.groupBox1.Location = new System.Drawing.Point(15, 66);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(123, 70);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Type";
      // 
      // patchRadioButton
      // 
      this.patchRadioButton.AutoSize = true;
      this.patchRadioButton.Location = new System.Drawing.Point(6, 42);
      this.patchRadioButton.Name = "patchRadioButton";
      this.patchRadioButton.Size = new System.Drawing.Size(53, 17);
      this.patchRadioButton.TabIndex = 1;
      this.patchRadioButton.Text = "&Patch";
      this.patchRadioButton.UseVisualStyleBackColor = true;
      // 
      // internalRadioButton
      // 
      this.internalRadioButton.AutoSize = true;
      this.internalRadioButton.Checked = true;
      this.internalRadioButton.Location = new System.Drawing.Point(6, 19);
      this.internalRadioButton.Name = "internalRadioButton";
      this.internalRadioButton.Size = new System.Drawing.Size(60, 17);
      this.internalRadioButton.TabIndex = 0;
      this.internalRadioButton.TabStop = true;
      this.internalRadioButton.Text = "&Internal";
      this.internalRadioButton.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Filename:";
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
      this.createButton.TabIndex = 7;
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
      this.cancelButton.TabIndex = 8;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "I&ndex File:";
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
      // MakeWadDialog
      // 
      this.AcceptButton = this.createButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(518, 147);
      this.Controls.Add(this.indexBrowseButton);
      this.Controls.Add(this.indexFileNameTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.createButton);
      this.Controls.Add(this.pathBrowseButton);
      this.Controls.Add(this.fileNameTextBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.groupBox1);
      this.Name = "MakeWadDialog";
      this.Text = "Create";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton patchRadioButton;
    private System.Windows.Forms.RadioButton internalRadioButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox fileNameTextBox;
    private System.Windows.Forms.Button pathBrowseButton;
    private System.Windows.Forms.Button createButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox indexFileNameTextBox;
    private System.Windows.Forms.Button indexBrowseButton;
  }
}