namespace Cyotek.Demo
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
      this.namesListBox = new System.Windows.Forms.ListBox();
      this.hexBox = new Be.Windows.Forms.HexBox();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.saveSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.extractFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.makeWADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sortByNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.originalOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.lumpNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.extractPalettesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.saveSelectionAsToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.lumpsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.sizeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.offsetToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.hexStartToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.hexLengthToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
      this.cyotekLinkToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.woooToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip.SuspendLayout();
      this.toolStrip.SuspendLayout();
      this.statusStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // namesListBox
      // 
      this.namesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.namesListBox.FormattingEnabled = true;
      this.namesListBox.IntegralHeight = false;
      this.namesListBox.Location = new System.Drawing.Point(0, 0);
      this.namesListBox.Name = "namesListBox";
      this.namesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      this.namesListBox.Size = new System.Drawing.Size(248, 490);
      this.namesListBox.TabIndex = 0;
      this.namesListBox.SelectedIndexChanged += new System.EventHandler(this.NamesListBox_SelectedIndexChanged);
      // 
      // hexBox
      // 
      this.hexBox.ColumnInfoVisible = true;
      this.hexBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hexBox.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.hexBox.HexCasing = Be.Windows.Forms.HexCasing.Lower;
      this.hexBox.InfoForeColor = System.Drawing.SystemColors.ControlDark;
      this.hexBox.Location = new System.Drawing.Point(0, 0);
      this.hexBox.Name = "hexBox";
      this.hexBox.ReadOnly = true;
      this.hexBox.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      this.hexBox.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      this.hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
      this.hexBox.Size = new System.Drawing.Size(532, 490);
      this.hexBox.StringViewVisible = true;
      this.hexBox.TabIndex = 0;
      this.hexBox.VScrollBarVisible = true;
      this.hexBox.SelectionStartChanged += new System.EventHandler(this.HexBox_SelectionStartChanged);
      this.hexBox.SelectionLengthChanged += new System.EventHandler(this.HexBox_SelectionStartChanged);
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.actionToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(784, 24);
      this.menuStrip.TabIndex = 0;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveSelectionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
      this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.newToolStripMenuItem.Text = "&New";
      this.newToolStripMenuItem.Visible = false;
      this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
      this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.openToolStripMenuItem.Text = "&Open";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
      // 
      // toolStripSeparator
      // 
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new System.Drawing.Size(243, 6);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
      this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.saveToolStripMenuItem.Text = "&Save";
      this.saveToolStripMenuItem.Visible = false;
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.saveAsToolStripMenuItem.Text = "Save &As";
      this.saveAsToolStripMenuItem.Visible = false;
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
      this.toolStripSeparator1.Visible = false;
      // 
      // saveSelectionToolStripMenuItem
      // 
      this.saveSelectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveSelectionToolStripMenuItem.Image")));
      this.saveSelectionToolStripMenuItem.Name = "saveSelectionToolStripMenuItem";
      this.saveSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
      this.saveSelectionToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.saveSelectionToolStripMenuItem.Text = "Save Se&lection As...";
      this.saveSelectionToolStripMenuItem.Click += new System.EventHandler(this.SaveSelectionToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(243, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
      this.editToolStripMenuItem.Text = "&Edit";
      // 
      // copyToolStripMenuItem
      // 
      this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
      this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.copyToolStripMenuItem.Text = "&Copy";
      this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
      // 
      // selectAllToolStripMenuItem
      // 
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
      this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.selectAllToolStripMenuItem.Text = "Select &All";
      this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
      // 
      // actionToolStripMenuItem
      // 
      this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractFileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.makeWADToolStripMenuItem});
      this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
      this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
      this.actionToolStripMenuItem.Text = "&Action";
      // 
      // extractFileToolStripMenuItem
      // 
      this.extractFileToolStripMenuItem.Name = "extractFileToolStripMenuItem";
      this.extractFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
      this.extractFileToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
      this.extractFileToolStripMenuItem.Text = "&Extract...";
      this.extractFileToolStripMenuItem.Click += new System.EventHandler(this.ExtractFileToolStripMenuItem_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(156, 6);
      // 
      // makeWADToolStripMenuItem
      // 
      this.makeWADToolStripMenuItem.Name = "makeWADToolStripMenuItem";
      this.makeWADToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
      this.makeWADToolStripMenuItem.Text = "&Make WAD...";
      this.makeWADToolStripMenuItem.Click += new System.EventHandler(this.MakeWadToolStripMenuItem_Click);
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "&View";
      // 
      // sortToolStripMenuItem
      // 
      this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByNameToolStripMenuItem,
            this.originalOrderToolStripMenuItem});
      this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
      this.sortToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
      this.sortToolStripMenuItem.Text = "&Sort";
      // 
      // sortByNameToolStripMenuItem
      // 
      this.sortByNameToolStripMenuItem.Name = "sortByNameToolStripMenuItem";
      this.sortByNameToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
      this.sortByNameToolStripMenuItem.Text = "by &Name";
      this.sortByNameToolStripMenuItem.Click += new System.EventHandler(this.SortByNameToolStripMenuItem_Click);
      // 
      // originalOrderToolStripMenuItem
      // 
      this.originalOrderToolStripMenuItem.Checked = true;
      this.originalOrderToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.originalOrderToolStripMenuItem.Name = "originalOrderToolStripMenuItem";
      this.originalOrderToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
      this.originalOrderToolStripMenuItem.Text = "by &Original Order";
      this.originalOrderToolStripMenuItem.Click += new System.EventHandler(this.OriginalOrderToolStripMenuItem_Click);
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lumpNamesToolStripMenuItem,
            this.extractPalettesToolStripMenuItem});
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
      this.toolsToolStripMenuItem.Text = "&Tools";
      // 
      // lumpNamesToolStripMenuItem
      // 
      this.lumpNamesToolStripMenuItem.Name = "lumpNamesToolStripMenuItem";
      this.lumpNamesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
      this.lumpNamesToolStripMenuItem.Text = "Lump &Names...";
      this.lumpNamesToolStripMenuItem.Click += new System.EventHandler(this.LumpNamesToolStripMenuItem_Click);
      // 
      // extractPalettesToolStripMenuItem
      // 
      this.extractPalettesToolStripMenuItem.Name = "extractPalettesToolStripMenuItem";
      this.extractPalettesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
      this.extractPalettesToolStripMenuItem.Text = "Extract &Palettes...";
      this.extractPalettesToolStripMenuItem.Click += new System.EventHandler(this.ExtractPalettesToolStripMenuItem_Click);
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
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator6,
            this.saveSelectionAsToolStripButton,
            this.toolStripSeparator2,
            this.copyToolStripButton});
      this.toolStrip.Location = new System.Drawing.Point(0, 24);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(784, 25);
      this.toolStrip.TabIndex = 1;
      // 
      // newToolStripButton
      // 
      this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
      this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.newToolStripButton.Name = "newToolStripButton";
      this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.newToolStripButton.Text = "&New";
      this.newToolStripButton.Visible = false;
      this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
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
      // saveToolStripButton
      // 
      this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
      this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveToolStripButton.Name = "saveToolStripButton";
      this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.saveToolStripButton.Text = "&Save";
      this.saveToolStripButton.Visible = false;
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
      // 
      // saveSelectionAsToolStripButton
      // 
      this.saveSelectionAsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.saveSelectionAsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveSelectionAsToolStripButton.Image")));
      this.saveSelectionAsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveSelectionAsToolStripButton.Name = "saveSelectionAsToolStripButton";
      this.saveSelectionAsToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.saveSelectionAsToolStripButton.Text = "Save Selection As";
      this.saveSelectionAsToolStripButton.Click += new System.EventHandler(this.SaveSelectionToolStripMenuItem_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // copyToolStripButton
      // 
      this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
      this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyToolStripButton.Name = "copyToolStripButton";
      this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.copyToolStripButton.Text = "&Copy";
      this.copyToolStripButton.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.lumpsToolStripStatusLabel,
            this.sizeToolStripStatusLabel,
            this.offsetToolStripStatusLabel,
            this.hexStartToolStripStatusLabel,
            this.hexLengthToolStripStatusLabel,
            this.toolStripProgressBar,
            this.cyotekLinkToolStripStatusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 539);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(784, 22);
      this.statusStrip.TabIndex = 3;
      // 
      // statusToolStripStatusLabel
      // 
      this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
      this.statusToolStripStatusLabel.Size = new System.Drawing.Size(354, 17);
      this.statusToolStripStatusLabel.Spring = true;
      this.statusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lumpsToolStripStatusLabel
      // 
      this.lumpsToolStripStatusLabel.Name = "lumpsToolStripStatusLabel";
      this.lumpsToolStripStatusLabel.Size = new System.Drawing.Size(55, 17);
      this.lumpsToolStripStatusLabel.Text = "Lumps: 0";
      // 
      // sizeToolStripStatusLabel
      // 
      this.sizeToolStripStatusLabel.Name = "sizeToolStripStatusLabel";
      this.sizeToolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
      this.sizeToolStripStatusLabel.Text = "Size: 0";
      // 
      // offsetToolStripStatusLabel
      // 
      this.offsetToolStripStatusLabel.Name = "offsetToolStripStatusLabel";
      this.offsetToolStripStatusLabel.Size = new System.Drawing.Size(51, 17);
      this.offsetToolStripStatusLabel.Text = "Offset: 0";
      // 
      // hexStartToolStripStatusLabel
      // 
      this.hexStartToolStripStatusLabel.Name = "hexStartToolStripStatusLabel";
      this.hexStartToolStripStatusLabel.Size = new System.Drawing.Size(35, 17);
      this.hexStartToolStripStatusLabel.Text = "Idx: 0";
      // 
      // hexLengthToolStripStatusLabel
      // 
      this.hexLengthToolStripStatusLabel.Name = "hexLengthToolStripStatusLabel";
      this.hexLengthToolStripStatusLabel.Size = new System.Drawing.Size(34, 17);
      this.hexLengthToolStripStatusLabel.Text = "Sel: 0";
      // 
      // toolStripProgressBar
      // 
      this.toolStripProgressBar.Name = "toolStripProgressBar";
      this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
      // 
      // cyotekLinkToolStripStatusLabel
      // 
      this.cyotekLinkToolStripStatusLabel.IsLink = true;
      this.cyotekLinkToolStripStatusLabel.Name = "cyotekLinkToolStripStatusLabel";
      this.cyotekLinkToolStripStatusLabel.Size = new System.Drawing.Size(99, 17);
      this.cyotekLinkToolStripStatusLabel.Text = "www.cyotek.com";
      this.cyotekLinkToolStripStatusLabel.Click += new System.EventHandler(this.CyotekLinkToolStripStatusLabel_Click);
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
      this.splitContainer.Panel1.Controls.Add(this.namesListBox);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.hexBox);
      this.splitContainer.Size = new System.Drawing.Size(784, 490);
      this.splitContainer.SplitterDistance = 248;
      this.splitContainer.TabIndex = 2;
      // 
      // woooToolStripMenuItem
      // 
      this.woooToolStripMenuItem.Name = "woooToolStripMenuItem";
      this.woooToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.woooToolStripMenuItem.Text = "Wooo";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 561);
      this.Controls.Add(this.splitContainer);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.menuStrip);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip;
      this.MaximizeBox = true;
      this.MinimizeBox = true;
      this.MinimumSize = new System.Drawing.Size(640, 480);
      this.Name = "MainForm";
      this.ShowIcon = true;
      this.ShowInTaskbar = true;
      this.Text = "Cyotek WadTools";
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox namesListBox;
    private Be.Windows.Forms.HexBox hexBox;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton newToolStripButton;
    private System.Windows.Forms.ToolStripButton openToolStripButton;
    private System.Windows.Forms.ToolStripButton saveToolStripButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripButton copyToolStripButton;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel hexStartToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel hexLengthToolStripStatusLabel;
    private System.Windows.Forms.ToolStripMenuItem extractFileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveSelectionToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem originalOrderToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sortByNameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem lumpNamesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
    private System.Windows.Forms.ToolStripButton saveSelectionAsToolStripButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem woooToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel cyotekLinkToolStripStatusLabel;
    private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
    private System.Windows.Forms.ToolStripMenuItem extractPalettesToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel sizeToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel offsetToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel lumpsToolStripStatusLabel;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem makeWADToolStripMenuItem;
  }
}

