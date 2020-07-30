using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

// Writing Adobe Swatch Exchange (ase) files using C#
// http://www.cyotek.com/blog/writing-adobe-swatch-exchange-ase-files-using-csharp

// Decoding DOOM Picture Files
// https://www.cyotek.com/blog/decoding-doom-picture-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.Windows.Forms
{
  [DefaultEvent("TopRowChanged")]
  internal class HexViewer : Control
  {
    #region Private Fields

    private const TextFormatFlags _flags = TextFormatFlags.Left
        | TextFormatFlags.SingleLine
        | TextFormatFlags.NoPrefix
        | TextFormatFlags.NoPadding;

    private static readonly HitTestInfo _emptyHitInfo = new HitTestInfo(false, Point.Empty, -1);

    private static readonly object _eventShowToolTipsChanged = new object();

    private static readonly object _eventTopRowChanged = new object();

    private readonly List<ByteGroup> _groups;

    private readonly VScrollBar _scrollBar;

    private readonly ToolTip _toolTip;

    private int _cellOffset;

    private Size _cellSize;

    private int _columns;

    private int _columnSize;

    private byte[] _data;

    private int _gutterSize;

    private int _highlightedIndex;

    private int _hitIndex;

    private int _rows;

    private bool _showToolTips;

    private int _topRow;

    private int _totalBytes;

    private int _visibleRows;

    #endregion Private Fields

    #region Public Constructors

    public HexViewer()
    {
      this.DoubleBuffered = true;
      this.SetStyle(ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, false);
      this.SetStyle(ControlStyles.ContainerControl, true);

      _groups = new List<ByteGroup>();

      _showToolTips = true;
      _scrollBar = new VScrollBar();
      _scrollBar.Scroll += this.ScrollBarScrollHandler;
      _scrollBar.ValueChanged += this.ScrollBarScrollHandler;
      this.Controls.Add(_scrollBar);

      base.ForeColor = SystemColors.WindowText;
      base.BackColor = SystemColors.Window;
      base.Font = new Font("Courier New", 9.75F);
      base.Padding = this.DefaultPadding;
      this.DefineCellSize();

      _toolTip = new ToolTip();
    }

    #endregion Public Constructors

    #region Public Events

    /// <summary>
    /// Occurs when the ShowToolTips property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowToolTipsChanged
    {
      add
      {
        this.Events.AddHandler(_eventShowToolTipsChanged, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventShowToolTipsChanged, value);
      }
    }

    [Category("Property Changed")]
    public event EventHandler TopRowChanged
    {
      add
      {
        this.Events.AddHandler(_eventTopRowChanged, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventTopRowChanged, value);
      }
    }

    #endregion Public Events

    #region Public Properties

    /// <summary>
    /// Occurs when the TopRow property value changes
    /// <summary>
    /// Gets or sets the background color for the control.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> that represents the background color of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor"/> property.
    /// </returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
    [DefaultValue(typeof(Color), "Window")]
    public override Color BackColor
    {
      get { return base.BackColor; }
      set { base.BackColor = value; }
    }

    [Browsable(false)]
    public int Columns
    {
      get { return _columns; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public byte[] Data
    {
      get { return _data; }
      set
      {
        _groups.Clear();
        _data = value;
        _totalBytes = value?.Length ?? 0;
        _gutterSize = _totalBytes.ToString().Length;

        this.TopRow = 0;
        this.DefineRowsAndColumns();
        this.Invalidate();
      }
    }

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <returns>
    /// The <see cref="T:System.Drawing.Font"/> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"/> property.
    /// </returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
    [DefaultValue(typeof(Font), "Courier New, 9.75pt")]
    public override Font Font
    {
      get { return base.Font; }
      set { base.Font = value; }
    }

    [DefaultValue(typeof(Color), "WindowText")]
    public override Color ForeColor
    {
      get { return base.ForeColor; }
      set { base.ForeColor = value; }
    }

    [Browsable(false)]
    public int Rows
    {
      get { return _rows; }
    }

    [Category("Behavior")]
    [DefaultValue(true)]
    public bool ShowToolTips
    {
      get { return _showToolTips; }
      set
      {
        if (_showToolTips != value)
        {
          _showToolTips = value;

          this.OnShowToolTipsChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int TopRow
    {
      get { return _topRow; }
      set
      {
        if (_topRow != value)
        {
          _topRow = value;

          this.OnTopRowChanged(EventArgs.Empty);
        }
      }
    }

    #endregion Public Properties

    #region Protected Properties

    /// <summary>
    /// Gets the internal spacing, in pixels, of the contents of a control.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Windows.Forms.Padding"/> that represents the internal spacing of the contents of a control.
    /// </returns>
    protected override Padding DefaultPadding
    {
      get { return new Padding(6); }
    }

    #endregion Protected Properties

    #region Public Methods

    public void AddRange(int start, int length, Color backColor, Color foreColor)
    {
      this.AddRange(start, length, backColor, foreColor, null);
    }

    public void AddRange(int start, int length, Color backColor, Color foreColor, string type)
    {
      this.AddRange(new ByteGroup
      {
        Start = start,
        Length = length,
        BackColor = backColor,
        ForeColor = foreColor,
        Type = type
      });
    }

    public void AddRange(ByteGroup group)
    {
      _groups.Add(group);

      this.Invalidate();
    }

    public void Clear()
    {
      _groups.Clear();
      _totalBytes = _data?.Length ?? 0;
    }

    public void SortRanges()
    {
      _groups.Sort((x, y) => x.Start.CompareTo(y.Start));
    }

    #endregion Public Methods

    #region Protected Methods

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control"/> and its child controls and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        this.Controls.Remove(_scrollBar);
        _scrollBar.Scroll -= this.ScrollBarScrollHandler;
        _scrollBar.ValueChanged -= this.ScrollBarScrollHandler;
        _scrollBar.Dispose();
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.FontChanged"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      this.DefineCellSize();
      this.DefineRowsAndColumns();
      this.Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);

      this.RemoveHotEffects();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      HitTestInfo hitTest;

      base.OnMouseMove(e);

      hitTest = this.HitTest(e.X, e.Y);

      if (hitTest.IsHit)
      {
        if (_hitIndex != hitTest.Index)
        {
          ByteGroup range;

          range = this.FindRange(hitTest.Index);

          if (range != null && range.Pointer != -1)
          {
            _highlightedIndex = range.Pointer;
            this.Invalidate();
          }
          else
          {
            this.RemoveHotEffects();
          }

          if (_showToolTips)
          {
            _toolTip.SetToolTip(this, this.GetToolTipText(hitTest.Index));
          }

          _hitIndex = hitTest.Index;
        }
      }
      else
      {
        this.RemoveHotEffects();
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseWheel"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data. </param>
    protected override void OnMouseWheel(MouseEventArgs e)
    {
      int value;

      base.OnMouseWheel(e);

      value = _scrollBar.Value + -e.Delta;

      if (value < 0)
      {
        value = 0;
      }

      if (value > _scrollBar.Maximum)
      {
        value = _scrollBar.Maximum;
      }

      _scrollBar.Value = value;
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.PaddingChanged"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);

      this.DefineRowsAndColumns();
      this.Invalidate();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data. </param>
    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics g;

      base.OnPaint(e);

      g = e.Graphics;
      g.Clear(this.BackColor);

      this.DrawGutter(g);
      this.DrawCells(g);

      //foreach (ByteGroup group in _groups)
      //{
      //  location = this.PaintGroup(e.Graphics, group, location);

      //  if (location.Y > this.ClientSize.Height)
      //  {
      //    // simple control, no scrolling so just abort if painting off-screen
      //    break;
      //  }
      //}

      e.Graphics.DrawRectangle(SystemPens.ControlDark, 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Resize"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      if (_scrollBar != null)
      {
        int w;
        Size size;

        w = SystemInformation.VerticalScrollBarWidth;
        size = this.ClientSize;

        _scrollBar.SetBounds(size.Width - (w + 1), 1, w, size.Height - 2);
      }

      this.DefineRowsAndColumns();
      this.Invalidate();
    }

    /// <summary>
    /// Raises the <see cref="ShowToolTipsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowToolTipsChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventShowToolTipsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="TopRowChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTopRowChanged(EventArgs e)
    {
      EventHandler handler;

      _scrollBar.Value = _topRow;
      this.Invalidate();

      handler = (EventHandler)this.Events[_eventTopRowChanged];

      handler?.Invoke(this, e);
    }

    #endregion Protected Methods

    #region Private Methods

    private void DefineCellSize()
    {
      using (Graphics g = this.CreateGraphics())
      {
        _cellSize = TextRenderer.MeasureText(g, "9", this.Font, Size.Empty, _flags);
        _cellOffset = TextRenderer.MeasureText(g, " ", this.Font, Size.Empty, _flags).Width;
      }

      _columnSize = (_cellSize.Width * 2) + _cellOffset;
    }

    private void DefineRowsAndColumns()
    {
      if (_totalBytes > 0)
      {
        int clientWidth;
        Size size;

        size = this.ClientSize;

        _visibleRows = (size.Height - this.Padding.Vertical) / _cellSize.Height;

        clientWidth = size.Width - (SystemInformation.VerticalScrollBarWidth
          + this.Padding.Horizontal
          + (((_gutterSize * _cellSize.Width) + (_cellOffset * 2)) * 2));

        _columns = clientWidth / _columnSize;
        _rows = _totalBytes / _columns;

        if (_rows > _visibleRows)
        {
          _scrollBar.Maximum = _rows - _visibleRows;
        }
      }
      else
      {
        _visibleRows = 0;
        _columns = 0;
        _rows = 0;
      }

      //_scrollBar.SmallChange = SystemInformation.MouseWheelScrollLines;
      //_scrollBar.LargeChange = _visibleRows / 2;
      _scrollBar.Enabled = _rows > _visibleRows;
    }

    private void DrawCell(Graphics g, int index, int x, int y, ByteGroup activeRange)
    {
      Rectangle bounds;
      Color foreColor;
      Color backColor;
      int offset;

      if (activeRange != null)
      {
        foreColor = activeRange.ForeColor;
        backColor = activeRange.BackColor;
      }
      else
      {
        foreColor = this.ForeColor;
        backColor = this.BackColor;
      }

      offset = _cellSize.Width + _cellOffset;
      bounds = new Rectangle(x, y, offset, _cellSize.Height);

      using (Brush brush = new SolidBrush(backColor))
      {
        g.FillRectangle(brush, bounds);

        if (activeRange != null && index < activeRange.End)
        {
          g.FillRectangle(brush, x + offset, y, _cellOffset, _cellSize.Height);
        }
      }

      TextRenderer.DrawText(g, _data[index].ToString("X2"), this.Font, bounds, foreColor, backColor, _flags);

      if (_highlightedIndex == index)
      {
        using (Brush brush = new SolidBrush(Color.FromArgb(128, Color.Firebrick)))
        {
          g.FillRectangle(brush, bounds);
        }
      }
    }

    private void DrawCells(Graphics g)
    {
      if (_totalBytes > 0)
      {
        int index;
        int x;
        int y;
        int baseY;
        int baseX;
        ByteGroup activeRange;

        index = _topRow * _columns;

        baseX = this.GetBaseX();
        baseY = this.GetBaseY();
        x = baseX;
        y = baseY;

        activeRange = null;

        for (int row = 0; row < _visibleRows; row++)
        {
          for (int col = 0; col < _columns; col++)
          {
            if (activeRange == null || index > activeRange.End)
            {
              activeRange = this.FindRange(index);
            }

            if (index < _totalBytes)
            {
              this.DrawCell(g, index, x, y, activeRange);
            }

            x += _columnSize;
            index++;

            if (index > _totalBytes - 1)
            {
              break;
            }
          }

          if (index > _totalBytes - 1)
          {
            break;
          }

          x = baseX;
          y += _cellSize.Height;
        }
      }
    }

    private void DrawGutter(Graphics g)
    {
      Padding padding;
      Font font;
      int x;
      int y;
      int lx;
      int rx;
      int gutterSize;
      int gutterWidth;
      Size size;
      Color foreColor;
      Color backColor;

      size = this.ClientSize;
      padding = this.Padding;
      backColor = this.BackColor;
      foreColor = SystemColors.GrayText;
      x = padding.Left;
      y = padding.Top;
      font = this.Font;
      gutterWidth = _cellSize.Width * _gutterSize;
      gutterSize = gutterWidth + _cellOffset;
      lx = x + gutterSize;
      rx = size.Width - (gutterSize + padding.Right + SystemInformation.VerticalScrollBarWidth);

      using (Pen pen = new Pen(foreColor))
      {
        g.DrawLine(pen, lx, 0, lx, size.Height);
        g.DrawLine(pen, rx, 0, rx, size.Height);
      }

      if (_visibleRows > 0 && _columns > 0)
      {
        for (int row = 0; row < _visibleRows; row++)
        {
          int index;

          index = (row + _topRow) * _columns;

          TextRenderer.DrawText(g, index.ToString(), font, new Rectangle(x, y, gutterWidth, _cellSize.Height), foreColor, backColor, _flags | TextFormatFlags.Right);
          TextRenderer.DrawText(g, (index + _columns - 1).ToString(), font, new Rectangle(rx + _cellOffset, y, gutterWidth, _cellSize.Height), foreColor, backColor, _flags);

          y += _cellSize.Height;
        }
      }
    }

    private ByteGroup FindRange(int position)
    {
      ByteGroup result;

      result = null;

      for (int i = 0; i < _groups.Count; i++)
      {
        ByteGroup range;

        range = _groups[i];

        if (range.Start > position)
        {
          // the ranges are ordered
          // therefore is this range is
          // ahead of our current position
          // there is nothing to match
          break;
        }
        else if (position >= range.Start && position <= range.End)
        {
          result = range;
          break;
        }
      }

      return result;
    }

    private int GetBaseX()
    {
      return this.Padding.Left + (_cellSize.Width * _gutterSize) + (_cellOffset * 2);
    }

    private int GetBaseY()
    {
      return this.Padding.Top;
    }

    private string GetToolTipText(int index)
    {
      StringBuilder sb;
      ByteGroup range;

      range = this.FindRange(index);

      sb = new StringBuilder();

      if (!string.IsNullOrEmpty(range?.Type))
      {
        sb.AppendLine(range.Type).AppendLine();
      }

      sb.Append("Index: ").Append(index).AppendLine()
        .Append("Value: ").Append(_data[index].ToString("X2")).Append(" (").Append(_data[index]).Append(')').AppendLine();

      if (range != null && (range.Length == 2 || range.Length == 4 || range.Pointer >= 0))
      {
        sb.AppendLine().AppendLine("Range:");

        if (range.Length == 2)
        {
          sb.Append("as Int16: ").Append(BitConverter.ToInt16(_data, range.Start)).AppendLine();
          sb.Append("as UInt16: ").Append(BitConverter.ToUInt16(_data, range.Start)).AppendLine();
        }
        else if (range.Length == 4)
        {
          sb.Append("as Int32: ").Append(BitConverter.ToInt32(_data, range.Start)).AppendLine();
          sb.Append("as UInt32: ").Append(BitConverter.ToUInt32(_data, range.Start)).AppendLine();
        }

        if (range.Pointer >= 0)
        {
          sb.AppendLine().Append("Pointer To: ").Append(range.Pointer).AppendLine();
        }
      }

      return sb.ToString();
    }

    private HitTestInfo HitTest(int x, int y)
    {
      HitTestInfo result;

      x -= this.GetBaseX();
      y -= this.GetBaseY();

      result = HexViewer._emptyHitInfo;

      if (x >= 0 && y >= 0)
      {
        int row;
        int column;

        column = x / _columnSize;
        row = _topRow + (y / _cellSize.Height);

        if (row < _rows && column < _columns)
        {
          int index;

          index = (row * _columns) + column;

          if (index < _totalBytes)
          {
            result = new HitTestInfo(true, new Point(x, y), index);
          }
        }
      }

      return result;
    }

    private void RemoveHotEffects()
    {
      if (_highlightedIndex != -1)
      {
        _highlightedIndex = -1;
        this.Invalidate();
      }

      if (_hitIndex != -1)
      {
        _toolTip.RemoveAll();
        _hitIndex = -1;
      }
    }

    private void ScrollBarScrollHandler(object sender, EventArgs e)
    {
      this.TopRow = _scrollBar.Value;
    }

    #endregion Private Methods

    #region Private Structs

    private struct HitTestInfo
    {
      #region Private Fields

      private readonly int _index;

      private readonly bool _isHit;

      private readonly Point _location;

      #endregion Private Fields

      #region Public Constructors

      public HitTestInfo(bool isHit, Point location, int index)
      {
        _isHit = isHit;
        _location = location;
        _index = index;
      }

      #endregion Public Constructors

      #region Public Properties

      public int Index
      {
        get { return _index; }
      }

      public bool IsHit
      {
        get { return _isHit; }
      }

      public Point Locaiton
      {
        get { return _location; }
      }

      #endregion Public Properties
    }

    #endregion Private Structs

    #region Internal Classes

    internal sealed class ByteGroup
    {
      #region Private Fields

      private Color _backColor;

      private Color _foreColor;

      private int _length;

      private int _pointer;

      private int _start;

      private string _type;

      #endregion Private Fields

      #region Public Constructors

      public ByteGroup()
      {
        _pointer = -1;
      }

      #endregion Public Constructors

      #region Public Properties

      public Color BackColor
      {
        get { return _backColor; }
        set { _backColor = value; }
      }

      public int End
      {
        get { return _start + _length - 1; }
      }

      public Color ForeColor
      {
        get { return _foreColor; }
        set { _foreColor = value; }
      }

      public int Length
      {
        get { return _length; }
        set { _length = value; }
      }

      public int Pointer
      {
        get { return _pointer; }
        set { _pointer = value; }
      }

      public int Start
      {
        get { return _start; }
        set { _start = value; }
      }

      public string Type
      {
        get { return _type; }
        set { _type = value; }
      }

      #endregion Public Properties
    }

    #endregion Internal Classes
  }
}