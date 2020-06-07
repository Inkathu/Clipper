using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.DrawingTool.Editors;
using RembyClipper2.DrawingTool.FigureCreator;
using RembyClipper2.DrawingTool.Figures;
using RembyClipper2.DrawingTool.FiguresCommands;
using RembyClipper2.DrawingTool.Markers;
using RembyClipper2.DrawingTool.SurfaceCommands;
using RembyClipper2.DrawingTool.UndoRedo;
using RembyClipper2.Utils;

namespace RembyClipper2.DrawingTool
{
    /// <summary>
    /// Surface modes
    /// </summary>
    public enum SurfaceMode
    {
        Default,
        Adding,
        Selected,
        MouseDown,
        Move,
        MarkerSelected,
    }

    /// <summary>
    /// Delegate for figure selectin changed
    /// </summary>
    /// <param name="figure">selected figure</param>
    public delegate void FigureSelectionChanged(IFigure figure);

    /// <summary>
    /// Drawing surface class
    /// </summary>
    public partial class DrawingSurface : UserControl, IDrawingSurface
    {
        public string ImageName { get; set; }
        public static UndoRedoManager UndoManager = new UndoRedoManager();

        /// <summary>
        /// Annotate buble creator
        /// </summary>
        private readonly AnnotateBubleCreator _annotateCreator = new AnnotateBubleCreator();

        /// <summary>
        /// Arrow creator
        /// </summary>
        private readonly ArrowCreator _arrowCreator = new ArrowCreator();

        /// <summary>
        /// Circle creator
        /// </summary>
        private readonly CircleCreator _circleCreator = new CircleCreator();

        /// <summary>
        /// Custom arrow creator
        /// </summary>
        private readonly CustomArrowCreator _custArrowCreator = new CustomArrowCreator();

        /// <summary>
        /// Surface figures
        /// </summary>
        private readonly List<IFigure> _figures;

        /// <summary>
        /// Rectangle creator
        /// </summary>
        private readonly RectangleCreator _rectCreator = new RectangleCreator();

        /// <summary>
        /// Annotate bubble creator
        /// </summary>
        private readonly ReverseAnnotateBubleCreator _reverseAnnotateCreator = new ReverseAnnotateBubleCreator();

        /// <summary>
        /// Text creator
        /// </summary>
        private readonly TextCreator _textCreator = new TextCreator();

        /// <summary>
        /// PEn for drawing selection rectangle
        /// </summary>
        private readonly Pen selectRectPen;


        /// <summary>
        /// Current surface mode
        /// </summary>
        private SurfaceMode _currentMode = SurfaceMode.Default;

        /// <summary>
        /// Dragged figure
        /// </summary>
        private IFigure _draggedFigure;

        private bool _figureLocationChanging;
        private bool _figureSizeChanging;

        private ToolStripStatusLabel _label;

        /// <summary>
        /// Surface markers
        /// </summary>
        private List<IFigure> _markers;

        private ICommand _redoCommand;

        /// <summary>
        /// Selected figure
        /// </summary>
        private IFigure _selectedFigure;

        private ICommand _undoCommand;

        /// <summary>
        /// start dragging point
        /// </summary>
        private Point startDragPoint;

        private Bitmap _drawingCanvas;

        /// <summary>
        /// Constructor
        /// </summary>
        public DrawingSurface()
        {
            InitializeComponent();
            DefaultCreator = null;
            _figures = new List<IFigure>();
            _markers = new List<IFigure>();
            selectRectPen = new Pen(Color.Red, 1);
            selectRectPen.DashStyle = DashStyle.Dash;


            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            CurrentBorderColor = Color.Black;
            CurrentFillColor = Color.Yellow;
            PropertyEditor.SelectionChanged += PropertyEditor_SelectionChanged;
            GotFocus += DrawingSurface_GotFocus;
            UndoManager.ActionCalled += UndoManager_ActionCalled;
            Disposed += new EventHandler(DrawingSurfaceDisposed);
            this.AllowDrop = true;

        }

        void DrawingSurfaceDisposed(object sender, EventArgs e)
        {
            Disposed -= DrawingSurfaceDisposed;
            UndoManager.ActionCalled -= UndoManager_ActionCalled;
            PropertyEditor.SelectionChanged -= PropertyEditor_SelectionChanged;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

//        protected override void OnPaintBackground(PaintEventArgs e)
//        {
            //Do not paint background
//            e.Graphics.FillRectangle(Brushes.Transparent, e.ClipRectangle);
//        }
        /// <summary>
        /// Default figure creator
        /// </summary>
        public FigureCreator.FigureCreator DefaultCreator { get; set; }

        /// <summary>
        /// Toolstrip label
        /// </summary>
        public ToolStripStatusLabel Label
        {
            get { return _label; }
            set
            {
                _label = value;
                if (_label != null)
                {
                    _label.Text = "";
                }
            }
        }

        #region IDrawingSurface Members

        /// <summary>
        /// Current border color
        /// </summary>
        public Color CurrentBorderColor { get; set; }

        /// <summary>
        /// Current fill color
        /// </summary>
        public Color CurrentFillColor { get; set; }

        public void SetFocus()
        {
            Focus();
        }

        /// <summary>
        /// This method performs to show debug info
        /// </summary>
        /// <param name="str"></param>
        public virtual void ShowDebugInfo(string str)
        {
            if (_label != null)
            {
                _label.Text = str;
            }
        }

        /// <summary>
        /// This method performs to set image of the surface
        /// </summary>
        /// <param name="img">image</param>
        public virtual void SetImage(Image img)
        {
            //BackColor = Color.Transparent;
            BackgroundImage = img;
            _drawingCanvas = new Bitmap(img);
            (this).Size = new Size(img.Width, img.Height);
            this.Parent.Size = new Size(this.Size.Width + 2, this.Size.Height + 2);
        }

        /// <summary>
        /// Size of the surface
        /// </summary>
        public Size SurfaceSize
        {
            get { return Size; }
        }

        /// <summary>
        /// This method performs to change order of the figure
        /// </summary>
        /// <param name="figure">affected figure</param>
        /// <param name="changeType">change type</param>
        public void ChangeFigureOrder(IFigure figure, ChangeOrderType changeType)
        {
            switch (changeType)
            {
                case ChangeOrderType.SendToBack:
                    SendFigureToback(figure);
                    break;
                case ChangeOrderType.BringToFront:
                    SendFigureToFront(figure);
                    break;
                case ChangeOrderType.SendBackward:
                    SendFigureBackward(figure);
                    break;
                case ChangeOrderType.BringForward:
                    BringFigureForward(figure);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("changeType");
            }
        }

        #endregion

        /// <summary>
        /// Figure selection event
        /// </summary>
        public event FigureSelectionChanged figureSelectionChanged;

        private void UndoManager_ActionCalled(object sender, EventArgs e)
        {
            UpdateUndoRedo();
        }

        /// <summary>
        /// Surface got focus event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawingSurface_GotFocus(object sender, EventArgs e)
        {
            if (_selectedFigure == null && _figures.Count > 0)
            {
                int mIndex = _figures.Min(f => f.ZIndex);
                IFigure figure = _figures.FirstOrDefault(f => f.ZIndex == mIndex);
                if (figure != null)
                {
                    SelectFigure(figure, null);
                }
            }
        }

        /// <summary>
        /// Propery editor selection changed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyEditor_SelectionChanged(object sender, EventArgs e)
        {
            var figure = sender as IFigure;
            if (figure != null)
            {
                _selectedFigure = figure;
                _markers = _selectedFigure.CreateMarkers();
                UpdateMarkers();
                Invalidate();
            }
            else
            {
                _selectedFigure = null;
                _markers.Clear();
                UpdateMarkers();
                Invalidate();
            }
        }

        /// <summary>
        /// This method performs to fire figure selection changed event
        /// </summary>
        private void CallFigureSelectionChanged()
        {
            if (figureSelectionChanged != null && (_selectedFigure == null || !(_selectedFigure is Marker)))
            {
                figureSelectionChanged(_selectedFigure);
            }
        }


        /// <summary>
        /// This method performs to paint all on the surface
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Draw(e.Graphics);
        }

        /// <summary>
        /// This method performs to comapre figure by ZIndex
        /// </summary>
        /// <param name="f1">figure 1</param>
        /// <param name="f2">figure 2</param>
        /// <returns>0 - index the same, 1 - f1 index is higher than f2 index, otherwise -1</returns>
        private static int CompareByZIndex(IFigure f1, IFigure f2)
        {
            if (f1.ZIndex == f2.ZIndex)
            {
                return 0;
            }
            else if (f1.ZIndex < f2.ZIndex)
            {
                return -1;
            }
            else if (f1.ZIndex > f2.ZIndex)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// This method performs to draw all stuff on the surface
        /// </summary>
        /// <param name="controlGraphics">graphics to draw with</param>
        private void Draw(Graphics gr)
        {
            gr.SmoothingMode = SmoothingMode.HighQuality;

            if (_selectedFigure != null && _selectedFigure.IsDeleted)
            {
                _selectedFigure = null;
                _markers.Clear();
                if (PropertyEditor.Instance.Visible)
                {
                    PropertyEditor.Instance.Show(this, null);
                }
            }
            _figures.Sort(CompareByZIndex);
            if (_figures.Count > 0)
            {
                foreach (IFigure f in _figures)
                {
                    if (f is FigureBase)
                    {
                        f.Draw(gr);
                    }
                }
            }

            //drawing figures
            if (_selectedFigure is FigureBase)
            {
                IFigure figure = _selectedFigure;
                var bounds = new RectangleF(_selectedFigure.GetLocation().X, _selectedFigure.GetLocation().Y,
                                            figure.Bounds.Width, figure.Bounds.Height);
                if (_selectedFigure.AllowSelectRectangle())
                {
                    gr.DrawRectangle(selectRectPen, bounds.Left - 2, bounds.Top - 2, bounds.Width + 4, bounds.Height + 4);
                }
                if (!_figures.Contains(_selectedFigure))
                {
                    _selectedFigure.Draw(gr);
                }
            }
            //drawing markers
            foreach (IFigure m in _markers)
                m.Draw(gr);
        }


        private void addRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMode = SurfaceMode.Adding;
            DefaultCreator = _rectCreator;
            Invalidate();
        }

        /// <summary>
        /// This method performs to find figure by point
        /// </summary>
        /// <param name="p">point</param>
        /// <returns>figure if found, otherwise null</returns>
        private IFigure FindFigureByPoint(Point p)
        {
            //ищем среди маркеров
            foreach (IFigure m in _markers)
                if (m.IsPointVisible(p))
                    return m;

            for (int i = _figures.Count - 1; i >= 0; i--)
                if (_figures[i] is FigureBase && _figures[i].IsPointVisible(p))
                    return _figures[i];
            return null;
        }

        /// <summary>
        /// Mouse down event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            UpdateUndoRedo();
            IFigure oldFigure = _selectedFigure;
            base.OnMouseDown(e);
            Focus();

            if (_currentMode == SurfaceMode.Adding)
            {
                _selectedFigure = DefaultCreator.CreateFigure(e.Location, CurrentBorderColor, CurrentFillColor, this,
                                                              AppConfig.Instance.FigureOpacity);
                _selectedFigure.Size = new SizeF(1, 1);
            }
            else
            {
                _draggedFigure = FindFigureByPoint(e.Location);
                IFigure figure = _draggedFigure;
                SelectFigure(figure, oldFigure);
            }
            startDragPoint = e.Location;
            Invalidate();
        }

        /// <summary>
        /// This method performs to select passed figure
        /// </summary>
        /// <param name="figure">new figure for selection</param>
        /// <param name="oldFigure">old selected figure</param>
        private void SelectFigure(IFigure figure, IFigure oldFigure)
        {
            UpdateUndoRedo();
            if (!(figure is IMarker))
            {
                _selectedFigure = figure;
                CreateMarkers();
                if (_selectedFigure != null && PropertyEditor.Instance.Visible)
                {
                    PropertyEditor.Instance.Show(this, _selectedFigure);
                }
                else if (PropertyEditor.Instance.Visible)
                {
                    PropertyEditor.Instance.Show(this, null);
                }
            }
            if (oldFigure != _selectedFigure)
            {
                CallFigureSelectionChanged();
            }
            InvalidateSurface();
        }

        /// <summary>
        /// Mouse double click event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (_selectedFigure != null)
                EditText();
        }

        /// <summary>
        /// This method performs to edit figure text
        /// </summary>
        private void EditText()
        {
            if (_selectedFigure != null && (_selectedFigure is FigureBase) && _selectedFigure.AllowText())
            {
                IFigure figure = _selectedFigure;
                var textBox = new AlphaBlendTextBox();
                textBox.Parent = this;
                textBox.Font = _selectedFigure.Font;
                textBox.ForeColor = _selectedFigure.FontColor;
                textBox.SetBounds((int) figure.TextBounds.Left, (int) figure.TextBounds.Top,
                                  (int) figure.TextBounds.Width, (int) figure.TextBounds.Height);
                textBox.Text = figure.Text;
                textBox.Multiline = true;
                textBox.AutoSize = true;
                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.TextChanged += textBox_TextChanged;
                if (_selectedFigure.TextBoxSize != Size.Empty)
                {
                    textBox.Size = _selectedFigure.TextBoxSize;
                }
                textBox.Focus();
                textBox_TextChanged(textBox, EventArgs.Empty);
                textBox.LostFocus += textBox_LostFocus;
                textBox.KeyUp += textBox_KeyUp;
                if (!textBox.Text.HasValue() || textBox.Text.Equals(LanguageMgr.LM.GetText(Labels.TextFigureText)))
                {
                    textBox.Text = LanguageMgr.LM.GetText(Labels.TypeYourTextHere);
                    textBox.SelectAll();
                }
                _selectedFigure.Text = "";
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
//            var tb = (TextBox) sender;
//            Size size = TextRenderer.MeasureText(tb.Text, tb.Font, new Size((int)tb.Width, int.MaxValue), TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);
//                if (size.Height > tb.Size.Height)
//            {
//                size = new Size(size.Width, size.Height + 50);
//                tb.Size = size;
//                _selectedFigure.Size = size;
//                tb.Invalidate();
//            }
    }

        /// <summary>
        /// textbox keyup event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                var tb = (TextBox) sender;
                tb.Tag = Keys.Escape;
                textBox_LostFocus(sender, EventArgs.Empty);
            }
            else if (e.KeyData == (Keys.Return | Keys.Shift) || e.KeyData == (Keys.Enter | Keys.Shift))
            {
                var tb = (TextBox) sender;
                textBox_LostFocus(sender, EventArgs.Empty);
            } 
            
            var tb1 = (TextBox)sender;
            int fHeight = (int)tb1.Font.GetHeight()/2;
            Size size = TextRenderer.MeasureText(tb1.Text, tb1.Font, new Size((int)tb1.Width - fHeight, int.MaxValue), TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);
            if (size.Height > tb1.Size.Height)
            {

                size = new Size(size.Width + fHeight, size.Height + fHeight);
                tb1.Size = size;
                _selectedFigure.Size = size;
                tb1.Invalidate();
            }
        }

        /// <summary>
        /// Textbox focus loosing event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_LostFocus(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null)
            {
                return;
            }
            if (_selectedFigure != null && (_selectedFigure is FigureBase) && _selectedFigure.AllowText())
            {
                if (tb.Tag == null)
                {
                    if (tb.Size.Width > _selectedFigure.TextBoxSize.Width && tb.Size.Height > _selectedFigure.TextBoxSize.Height)
                    {
                        _selectedFigure.TextBoxSize = tb.Size;    
                    }
                    
                    _selectedFigure.Text = tb.Text;
                }

                if (!_selectedFigure.Text.HasValue() ||
                    _selectedFigure.Text.Equals(LanguageMgr.LM.GetText(Labels.TypeYourTextHere)))
                {
                    _selectedFigure.Text = LanguageMgr.LM.GetText(Labels.TextFigureText);
                }
                Focus();
            }
            Controls.Remove(tb);
            tb.LostFocus -= textBox_LostFocus;
            tb.KeyUp -= textBox_KeyUp;
            tb.TextChanged -= textBox_TextChanged;
            _selectedFigure.CalcSizeForInnerText();
        }

        /// <summary>
        /// This method performs to process keyboard for figures controlling
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Focused)
            {
                switch (keyData)
                {
                    case Keys.Tab:
                        {
                            if (_figures.Count == 0)
                            {
                                ParentForm.SelectNextControl(this, true, false, false, false);
                                break;
                            }
                            IFigure nextFigure = null;
                            int max = 0;
                            max = _figures.Min(f => f.ZIndex);
                            int index = _selectedFigure == null ? max : _selectedFigure.ZIndex;
                            _figures.Sort(CompareByZIndex);
                            max = _figures.Max(f => f.ZIndex);

                            nextFigure = (from f in _figures
                                          where f.ZIndex > index
                                          select f).FirstOrDefault();
                            if (nextFigure != null)
                            {
                                SelectFigure(nextFigure, _selectedFigure);
                            }
                            else if (nextFigure == null && _selectedFigure != null && _selectedFigure.ZIndex == max)
                            {
                                ParentForm.SelectNextControl(this, true, false, false, false);
                                SelectFigure(null, _selectedFigure);
                            }
                            return true;
                        }
                    case Keys.Tab | Keys.Shift:
                        {
                            if (_figures.Count == 0)
                            {
                                ParentForm.SelectNextControl(this, false, false, false, true);
                                break;
                            }

                            IFigure nextFigure = null;
                            int min = 0;

                            min = _figures.Max(f => f.ZIndex);
                            int index = _selectedFigure == null ? min : _selectedFigure.ZIndex;
                            _figures.Sort(CompareByZIndex);
                            min = _figures.Min(f => f.ZIndex);
                            nextFigure = (from f in _figures
                                          where f.ZIndex < index
                                          select f).FirstOrDefault();

                            if (nextFigure != null)
                            {
                                SelectFigure(nextFigure, _selectedFigure);
                            }
                            else if (nextFigure == null && _selectedFigure != null && _selectedFigure.ZIndex == min)
                            {
                                ParentForm.SelectNextControl(this, false, false, false, true);
                                SelectFigure(null, _selectedFigure);
                                //                                Control ctrl = GetNextControl(this, true);
                                //                                if (ctrl != null)
                                //                                {
                                //                                    ctrl.Focus();
                                //                                }
                            }
                            return true;
                        }
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.Up:
                    case Keys.Down:
                        {
                            if (_selectedFigure != null)
                            {
                                int dx = keyData == Keys.Right
                                             ? 1
                                             : keyData == Keys.Left
                                                   ? -1
                                                   : 0;
                                int dy = keyData == Keys.Down
                                             ? 1
                                             : keyData == Keys.Up
                                                   ? -1
                                                   : 0;

                                _selectedFigure.Offset(dx, dy);
                                InvalidateSurface();
                                UpdateMarkers();
                                return true;
                            }

                            break;
                        }

                    case Keys.Left | Keys.Shift:
                    case Keys.Right | Keys.Shift:
                    case Keys.Up | Keys.Shift:
                    case Keys.Down | Keys.Shift:
                        {
                            if (_selectedFigure != null)
                            {
                                int dw = keyData == (Keys.Right | Keys.Shift)
                                             ? 1
                                             : keyData == (Keys.Left | Keys.Shift)
                                                   ? -1
                                                   : 0;
                                int dh = keyData == (Keys.Down | Keys.Shift)
                                             ? 1
                                             : keyData == (Keys.Up | Keys.Shift)
                                                   ? -1
                                                   : 0;

                                _selectedFigure.Size = new SizeF(_selectedFigure.Size.Width + dw,
                                                                 _selectedFigure.Size.Height + dh);
                                InvalidateSurface();
                                UpdateMarkers();
                                return true;
                            }

                            break;
                        }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// on key down event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _selectedFigure.CallCommand(typeof (RemoveFigureCommand));
            }
            else if (e.KeyCode == Keys.F2 && _selectedFigure != null)
            {
                EditText();
            }
            else if (e.KeyCode == Keys.Tab)
            {
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// This method performs to delete selected figure
        /// </summary>
        private void DeleteSelectedFigure()
        {
            _figures.Remove(_selectedFigure);
            _selectedFigure = null;
        }


        /// <summary>
        /// This method performs to create markers
        /// </summary>
        private void CreateMarkers()
        {
            if (_selectedFigure == null)
                _markers = new List<IFigure>();
            else
            {
                _markers = _selectedFigure.CreateMarkers();
                UpdateMarkers();
            }
        }

        /// <summary>
        /// This method performs to update all markers
        /// </summary>
        private void UpdateMarkers()
        {
            foreach (IMarker m in _markers)
                if (_draggedFigure != m)
                {
                    m.UpdateLocation();
                }
        }

        //private SizeF _sizeBeforeChange = Size.Empty;
        //private Point _locationBeforeChanging = Point.Empty;

        /// <summary>
        /// Mouse move event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                int dX = e.Location.X - startDragPoint.X;
                int dY = e.Location.Y - startDragPoint.Y;
                if (_draggedFigure != null && (_draggedFigure is FigureBase))
                {
                    if (_draggedFigure is IMarker && !_figureSizeChanging)
                    {
                        _figureSizeChanging = true;
                        if (_draggedFigure != null)
                        {
                            if (((IMarker) _draggedFigure).GetControlledFigure() is ArrowFigure)
                            {
                                var m = (ArrowMarker) _draggedFigure;

                                UndoManager.StoreState(
                                    new FigureState(
                                        m.IsStartMarker ? StateAction.ArrowStartMove : StateAction.ArrowEndMove,
                                        ((IMarker) _draggedFigure).GetControlledFigure(),
                                        this));
                            }
                            else
                            {
                                UndoManager.StoreState(new FigureState(StateAction.SizeChange,
                                                                       ((IMarker) _draggedFigure).GetControlledFigure(),
                                                                       this));
                            }
                        }
                    }
                    else if (!(_draggedFigure is IMarker) && !_figureLocationChanging)
                    {
                        _figureLocationChanging = true;
                        if (_draggedFigure != null)
                        {
                            UndoManager.StoreState(new FigureState(StateAction.Move, _draggedFigure, this));
                        }
                    }
                    _draggedFigure.Offset(e.Location, startDragPoint);
                    //_markers.ForEach(m => m.Offset(dX, dY));
                    UpdateMarkers();
                    Invalidate();
                }
                else 
                if(_currentMode != SurfaceMode.Adding && _selectedFigure == null)
                {
                    DateTime t = DateTime.Now;
                    //string.Format("Image{0}_{1}_{2}_{3}{4}.png", t.Year, t.Month, t.Day, t.Hour, t.Minute)
                    string path = Path.Combine(Path.GetTempPath(), ImageName);
                    if(ImageName.HasValue() && !ImageName.Contains("."))
                    {
                        path += ".png";
                    }
                    path = path.Replace(" ", "_");
                    if(path.Count(c => c == ':') > 1)
                    {
                        int first = path.IndexOf(':');
                        path = path.Replace(":", "_");
                        path = path.Remove(first, 1);
                        path = path.Insert(first, ":");

                    }
                    Bitmap bitmap = GetImage();
                    bitmap.Save(path, ImageFormat.Png);
                    string[] files = new string[1];
                    files[0] = path;
                    DataObject obj = new DataObject(DataFormats.FileDrop, files);
                    obj.SetData(DataFormats.StringFormat, path);
                    DoDragDrop(obj, DragDropEffects.Copy);
                }

                if (_currentMode == SurfaceMode.Adding && _selectedFigure != null)
                {
                    _selectedFigure.Size = SizeF.Add(_selectedFigure.Size, new SizeF(dX, dY));
                    Invalidate();
                }
            }
            else
            {
                IFigure figure = FindFigureByPoint(e.Location);
                if (figure is IMarker)
                    Cursor = Cursors.SizeAll;
                else if (figure != null)
                    Cursor = Cursors.Hand;
                else
                    Cursor = Cursors.Default;
            }

            startDragPoint = e.Location;
        }

        /// <summary>
        /// Mouse up event hadler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_draggedFigure is IMarker)
            {
                IFigure figure = ((IMarker) _draggedFigure).GetControlledFigure();
                if (figure != null)
                {
                    figure.TellThatSizeChanged();
                    if (_figureSizeChanging)
                    {
                        _figureSizeChanging = false;
                    }
                }
            }
            else
            {
                if (_figureLocationChanging)
                {
                    _figureLocationChanging = false;
                }
                if (_draggedFigure != null)
                {
                    _draggedFigure.TellThatDragFinished();
                }
            }

            _draggedFigure = null;
            if (_currentMode == SurfaceMode.Adding && _selectedFigure != null)
            {
                IFigure figure = _selectedFigure;
                AddFigure(figure);
                figure.IsNewFigure = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                surfaceCMenu.Items.Clear();
                if (_selectedFigure != null)
                {
                    //show figure menu
                    surfaceCMenu.Items.Add(LanguageMgr.LM.GetText(Labels.Properties), null,
                                           (sender, args) => PropertyEditor.Instance.Show(this, _selectedFigure));
                }

                if (surfaceCMenu.Items.Count > 0)
                {
                    surfaceCMenu.Show(Cursor.Position);
                }
            }
            UpdateMarkers();
            Invalidate();
        }

        /// <summary>
        /// This method performs to get image from the surface
        /// </summary>
        /// <returns>surface image</returns>
        public Bitmap GetImage()
        {
            _selectedFigure = null;
            _draggedFigure = null;
            CreateMarkers();

            Bitmap cloneImg = (Bitmap)_drawingCanvas.Clone();
            using(Graphics gr = Graphics.FromImage(cloneImg))
            {
                Draw(gr);
            }

//            var bmp = new Bitmap(Bounds.Width, Bounds.Height, PixelFormat.Format32bppArgb);
//            
//            Invoke((MethodInvoker) (() => DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height))));)
            return cloneImg;
        }

        /// <summary>
        /// This method performs to bring figure forward
        /// </summary>
        /// <param name="figure">figure</param>
        private void BringFigureForward(IFigure figure)
        {
            int curZInd = figure.ZIndex;
            _figures.Sort(CompareByZIndex);
            IFigure bigger = (from f in _figures
                              where f.ZIndex > figure.ZIndex
                              select f).FirstOrDefault();
            if (bigger != null)
            {
                figure.ZIndex = bigger.ZIndex;
                bigger.ZIndex = curZInd;
            }
            Invalidate();
        }


        /// <summary>
        /// This method performs to send figure backward
        /// </summary>
        /// <param name="figure">figure</param>
        private void SendFigureBackward(IFigure figure)
        {
            if (figure.ZIndex <= 0)
            {
                return;
            }
            int curZInd = figure.ZIndex;
            _figures.Sort(CompareByZIndex);
            IFigure smaller = (from f in _figures
                               where f.ZIndex < figure.ZIndex
                               select f).LastOrDefault();
            if (smaller != null)
            {
                figure.ZIndex = smaller.ZIndex;
                smaller.ZIndex = curZInd;
            }
            Invalidate();
        }

        /// <summary>
        /// This method performs to send figure to front
        /// </summary>
        /// <param name="figure">figure</param>
        private void SendFigureToFront(IFigure figure)
        {
            int curZInd = figure.ZIndex;
            _figures.Sort(CompareByZIndex);
            IFigure biggest = (from f in _figures
                               where f.ZIndex > figure.ZIndex
                               select f).LastOrDefault();
            if (biggest != null)
            {
                figure.ZIndex = biggest.ZIndex + 1;
            }
            Invalidate();
        }

        /// <summary>
        /// This method performs to send figure to back
        /// </summary>
        /// <param name="figure">figure</param>
        private void SendFigureToback(IFigure figure)
        {
            if (figure.ZIndex <= 0)
            {
                return;
            }
            int curZInd = figure.ZIndex;
            _figures.Sort(CompareByZIndex);
            IFigure smallest = (from f in _figures
                                where f.ZIndex < figure.ZIndex
                                select f).FirstOrDefault();
            if (smallest != null)
            {
                figure.ZIndex = smallest.ZIndex - 1;
            }
            Invalidate();
        }


        /// <summary>
        /// This method performs to invalidate surface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _selectedFigure_RedrawFigure(object sender, EventArgs e)
        {
            var figure = sender as IFigure;
            if (figure != null)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// This method performs to find figure in point
        /// </summary>
        /// <param name="figures">list of possible figures</param>
        /// <param name="p">point</param>
        /// <returns>founded figure or null</returns>
        private IFigure FindClickedFigure(List<IFigure> figures, Point p)
        {
            IFigure result = null;
            result = figures.Select(figure => figure).Where(figure => figure.IsPointVisible(p)).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// add circle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMode = SurfaceMode.Adding;
            DefaultCreator = _circleCreator;
            Invalidate();
        }

        /// <summary>
        /// add text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMode = SurfaceMode.Adding;
            DefaultCreator = _textCreator;
            Invalidate();
        }

        /// <summary>
        /// add arrow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void arrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMode = SurfaceMode.Adding;
            DefaultCreator = _arrowCreator;
            Invalidate();
        }

        /// <summary>
        /// add custom arrow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMode = SurfaceMode.Adding;
            DefaultCreator = _custArrowCreator;
            Invalidate();
        }

        public void ClearUndoRedo()
        {
            UndoManager.ClearStates();
        }

        #region Implementation of IDrawingSurface

        /// <summary>
        /// This method performs to get surface commands
        /// </summary>
        /// <returns>commands</returns>
        public List<ICommand> GetCommands()
        {
            var commands = new List<ICommand>();
            _undoCommand = new UndoCommand(this, UndoManager.IsUndoAvailable());
            commands.Add(_undoCommand);
            _redoCommand = new RedoCommand(this, UndoManager.IsRedoAvailable());
            commands.Add(_redoCommand);
            commands.Add(new AddTextAddCommand(_textCreator, this));
            commands.Add(new AddRectangleAddCommand(_rectCreator, this));
            commands.Add(new AddCircleAddCommand(_circleCreator, this));
            //commands.Add(new AddArrowAddCommand(_arrowCreator, this));
            commands.Add(new AddCustomArrowAddCommand(_custArrowCreator, this));
            commands.Add(new AddAnnotateBubleAddCommand(_annotateCreator, _reverseAnnotateCreator, this));
            return commands;
        }


        public void UpdateUndoRedo()
        {
            _undoCommand.Enabled = UndoManager.IsUndoAvailable();
            _redoCommand.Enabled = UndoManager.IsRedoAvailable();
        }

        public void AddFigureWithoutUndoRedo(IFigure figure)
        {
            AddFigureToSurface(figure);
        }

        /// <summary>
        /// This method performs to add figure
        /// </summary>
        /// <param name="figure">figure</param>
        public void AddFigure(IFigure figure)
        {
            AddFigureToSurface(figure);
            UndoManager.StoreState(new FigureState(StateAction.Add, figure, this));
        }


        public void Undo()
        {
            FigureState figureState = UndoManager.Undo();
            if (figureState != null)
            {
                figureState.AcceptState();
            }
            UpdateUndoRedo();
            if (_selectedFigure != null)
            {
                _markers = _selectedFigure.CreateMarkers();
            }
            InvalidateSurface();
        }

        public void Redo()
        {
            FigureState figureState = UndoManager.Redo();
            if (figureState != null)
            {
                figureState.AcceptState();
            }
            UpdateUndoRedo();
            if (_selectedFigure != null)
            {
                _markers = _selectedFigure.CreateMarkers();
            }
            InvalidateSurface();
        }

        public void DeleteFigureWithoutUndoRedo(IFigure figure)
        {
            _selectedFigure = null;
            if (_figures.Contains(figure))
            {
                _figures.Remove(figure);
            }
            CallFigureSelectionChanged();
            _markers.Clear();
        }

        /// <summary>
        /// This method performs to delete figure
        /// </summary>
        /// <param name="figure"></param>
        public void DeleteFigure(IFigure figure)
        {
            UndoManager.StoreState(new FigureState(StateAction.Remove, figure, this));
            DeleteFigureWithoutUndoRedo(figure);
        }

        /// <summary>
        /// This method performs to invalidate surface
        /// </summary>
        public void InvalidateSurface()
        {
            Invalidate();
        }

        /// <summary>
        /// This method performs to initiate figure adding process
        /// </summary>
        /// <param name="creator"></param>
        public void InitiateFigureAdding(FigureCreator.FigureCreator creator)
        {
            DefaultCreator = creator;
            _currentMode = SurfaceMode.Adding;
            InvalidateSurface();
        }

        /// <summary>
        /// This method performs to add figure to surface
        /// </summary>
        /// <param name="figure">figure</param>
        private void AddFigureToSurface(IFigure figure)
        {
            _currentMode = SurfaceMode.Default;
            figure.ZIndex = FigureBase.NextIndex;
            figure.GenerateName();
            _figures.Add(figure);
            PropertyEditor.Instance.FiguresDataSource = _figures;
            figure.RedrawFigure += _selectedFigure_RedrawFigure;
            SelectFigure(figure, _selectedFigure == figure ? null : _selectedFigure);

            Invalidate();
        }

        #endregion
    }
}