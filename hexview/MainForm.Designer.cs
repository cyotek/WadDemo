namespace Cyotek.Windows.Forms.Demo
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.sizeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.cyotekLinkToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolTipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.filePane = new Cyotek.Windows.Forms.Demo.FilePane();
      this.hexViewer = new Cyotek.Windows.Forms.Demo.HexViewer();
      this.toolStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.statusStrip.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
      // 
      // toolStrip
      // 
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton});
      this.toolStrip.Location = new System.Drawing.Point(0, 24);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(784, 25);
      this.toolStrip.TabIndex = 1;
      // 
      // openToolStripButton
      // 
      this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
      this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripButton.Name = "openToolStripButton";
      this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.openToolStripButton.Text = "&Open";
      this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer.Location = new System.Drawing.Point(0, 49);
      this.splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.filePane);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.hexViewer);
      this.splitContainer.Size = new System.Drawing.Size(784, 490);
      this.splitContainer.SplitterDistance = 248;
      this.splitContainer.TabIndex = 2;
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.sizeToolStripStatusLabel,
            this.cyotekLinkToolStripStatusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 539);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(784, 22);
      this.statusStrip.TabIndex = 3;
      // 
      // statusToolStripStatusLabel
      // 
      this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
      this.statusToolStripStatusLabel.Size = new System.Drawing.Size(631, 17);
      this.statusToolStripStatusLabel.Spring = true;
      this.statusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // sizeToolStripStatusLabel
      // 
      this.sizeToolStripStatusLabel.Name = "sizeToolStripStatusLabel";
      this.sizeToolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
      this.sizeToolStripStatusLabel.Text = "Size: 0";
      // 
      // cyotekLinkToolStripStatusLabel
      // 
      this.cyotekLinkToolStripStatusLabel.IsLink = true;
      this.cyotekLinkToolStripStatusLabel.Name = "cyotekLinkToolStripStatusLabel";
      this.cyotekLinkToolStripStatusLabel.Size = new System.Drawing.Size(99, 17);
      this.cyotekLinkToolStripStatusLabel.Text = "www.cyotek.com";
      this.cyotekLinkToolStripStatusLabel.Click += new System.EventHandler(this.CyotekLinkToolStripStatusLabel_Click);
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(784, 24);
      this.menuStrip.TabIndex = 0;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
      this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.openToolStripMenuItem.Text = "&Open";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
      // 
      // toolStripSeparator
      // 
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolTipsToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "&View";
      // 
      // toolTipsToolStripMenuItem
      // 
      this.toolTipsToolStripMenuItem.Checked = true;
      this.toolTipsToolStripMenuItem.CheckOnClick = true;
      this.toolTipsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.toolTipsToolStripMenuItem.Name = "toolTipsToolStripMenuItem";
      this.toolTipsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.toolTipsToolStripMenuItem.Text = "&Tool Tips";
      this.toolTipsToolStripMenuItem.Click += new System.EventHandler(this.ToolTipsToolStripMenuItem_Click);
      // 
      // fontToolStripMenuItem
      // 
      this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
      this.fontToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.fontToolStripMenuItem.Text = "&Font...";
      this.fontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
      // 
      // filePane
      // 
      this.filePane.Dock = System.Windows.Forms.DockStyle.Fill;
      this.filePane.Location = new System.Drawing.Point(0, 0);
      this.filePane.Name = "filePane";
      this.filePane.SearchPattern = "*.wad";
      this.filePane.Size = new System.Drawing.Size(248, 490);
      this.filePane.TabIndex = 0;
      this.filePane.SelectedFileChanged += new System.EventHandler(this.FilePane_SelectedFileChanged);
      // 
      // hexViewer
      // 
      this.hexViewer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hexViewer.Location = new System.Drawing.Point(0, 0);
      this.hexViewer.Name = "hexViewer";
      this.hexViewer.Size = new System.Drawing.Size(532, 490);
      this.hexViewer.TabIndex = 0;
      this.hexViewer.TopRow = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 561);
      this.Controls.Add(this.splitContainer);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.menuStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(640, 480);
      this.Name = "MainForm";
      this.Text = "Doom Wad Hex Viewer";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton openToolStripButton;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private HexViewer hexViewer;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolTipsToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel cyotekLinkToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel sizeToolStripStatusLabel;
    private Cyotek.Windows.Forms.Demo.FilePane filePane;
    private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
  }
}

