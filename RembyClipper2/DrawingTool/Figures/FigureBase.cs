using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RembyClipper2.Config;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.FigureCreator;
using RembyClipper2.DrawingTool.FiguresCommands;
using RembyClipper2.DrawingTool.UndoRedo;

namespace RembyClipper2.DrawingTool.Figures
{
    /// <summary>
    /// Basic figure abstract class
    /// </summary>
    [Serializable]
    public abstract class FigureBase : IFigure
    {
        /// <summary>
        /// default size of the figure
        /// </summary>
        protected const int DEFAULT_SIZE = 100;

        /// <summary>
        /// Default pen size
        /// </summary>
        protected const int DEFAULT_PEN_SIZE = 5;

        /// <summary>
        /// Pen for drawing border
        /// </summary>
        protected Pen _borderPen;
        
        /// <summary>
        /// brush for fill figure
        /// </summary>
        protected Brush _fillBrush;


        /// <summary>
        /// Figure location
        /// </summary>
        protected PointF _location;

        /// <summary>
        /// Figure path
        /// </summary>
        protected GraphicsPath _figurePath;
        
        /// <summary>
        /// Figure redrawing event
        /// </summary>
        public event EventHandler RedrawFigure;

        /// <summary>
        /// size of the border
        /// </summary>
        protected int _borderSize;

        /// <summary>
        /// Rectangle for the text showing
        /// </summary>
        protected RectangleF _textRect;

        /// <summary>
        /// Figure angel
        /// </summary>
        protected float _angle;

       
        /// <summary>
        /// Command which could be applied for the figure
        /// </summary>
        private List<ICommand> _commands;

        /// <summary>
        /// Surface where figure drawing
        /// </summary>
        protected IDrawingSurface _surface;

        /// <summary>
        /// MAX index of the figure
        /// </summary>
        private static int _figureIndex = 1;

        /// <summary>
        /// This property performs to get max index for the figure
        /// </summary>
        public static int NextIndex
        {
            get { return _figureIndex++; }
        }

        public Size TextBoxSize {get; set; }

        /// <summary>
        /// Figure border color
        /// </summary>
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
               
                if(_borderPen != null)
                {
                    _borderPen.Color = value;
                } else
                {
                    _borderPen = new Pen(value, BorderSize);
                }
                CallRedraw();
            }
        }

        private Color _borderColor;

        public bool IsNewFigure 
        {
            get { return _isNewFigure; } 
            set { _isNewFigure = value; } 
        }
        private bool _isNewFigure;


        #region Implementation of ICloneable
        /// <summary>
        /// Performs to clone figure object
        /// </summary>
        /// <returns>clonned object</returns>
        public FigureBase Clone()
        {
            var figureBase = (FigureBase)MemberwiseClone();
            figureBase._figurePath = (GraphicsPath)figureBase._figurePath.Clone();
            figureBase.BorderColor = Color.FromArgb(figureBase._borderColor.A, figureBase._borderColor);
            figureBase.FillColor = Color.FromArgb(figureBase.FillColor.A, figureBase.FillColor);
            figureBase._fillBrush = (Brush)figureBase._fillBrush.Clone();
            figureBase._borderPen = (Pen) figureBase._borderPen.Clone();
            return figureBase;
        }
        /// <summary>
        /// Performs to clone figure object
        /// </summary>
        /// <returns>clonned object</returns>
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        #endregion

        /// <summary>
        /// This method performs to initiate figure redrawing
        /// </summary>
        protected void CallRedraw()
        {
            if(RedrawFigure != null)
            {
                RedrawFigure(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// This method performs to recalculate size of the rect
        /// </summary>
        public virtual void CalcSizeForInnerText()
        {
            Size size = TextRenderer.MeasureText(Text, _font, new Size((int)Size.Width, int.MaxValue), TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);
            //if(size.Width > Size.Width)
            //{
            //    int width = size.Width;
            //    size.Width = (int)Size.Width;
            //    float sq = size.Height * (width - size.Width);
            //    int lb = Text.Split(new char[] {'\n'}).Length + 1;
            //    size.Height += (int)(sq/size.Width /2);
            //}
            if(size.Height > Size.Height)
            {
                Size = size;
                _textRect.Size = size;
                CallRedraw();
            }
        }


        /// <summary>
        /// This property performs to determine whether the figure deleted or no
        /// </summary>
        public virtual bool IsDeleted { get; set; }


        public event EventHandler DragFinished;
        public void TellThatDragFinished()
        {
            EventHandler handler = DragFinished;
            if(handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }


        public event EventHandler SizeChanged;
        public void TellThatSizeChanged()
        {
            EventHandler h = SizeChanged;
            if(h != null)
            {
                h(this, EventArgs.Empty);
            }
        }

        public virtual void SetLocation(PointF location)
        {
            float dx = location.X - _location.X;
            float dy = location.Y - _location.Y;
            Matrix m = new Matrix();
            m.Translate(dx, dy);
            _location = new Point((int)location.X, (int)location.Y);
            _figurePath.Transform(m);
            _textRect.X += dx;
            _textRect.Y += dy;

        }

        /// <summary>
        /// Fill color
        /// </summary>
        public Color FillColor
        {
            get { return _fillColor; }
            set
            {
                _fillColor = value;
                _fillBrush = new SolidBrush(value);
                CallRedraw();
            }
        }

        private Color _fillColor;

        /// <summary>
        /// Figure size
        /// </summary>
        public virtual SizeF Size
        {
            get { return _figurePath.GetBounds().Size; }
            set
            {
                SizeF oldSize = _figurePath.GetBounds().Size;
                SizeF newSize = new SizeF(Math.Max(1, value.Width), Math.Max(1, value.Height));
                //x axis koeff
                float kx = newSize.Width / oldSize.Width;
                //y axis koeff
                float ky = newSize.Height / oldSize.Height;
                Scale(kx, ky);
                CalcSizeForInnerText();
            }
        }

        /// <summary>
        /// This method performs to scale figure
        /// </summary>
        /// <param name="scaleX">X axis scale</param>
        /// <param name="scaleY">y axis scale</param>
        public void Scale(float scaleX, float scaleY)
        {
            //scale
            Matrix m = new Matrix();
            m.Scale(scaleX, scaleY);
            _figurePath.Transform(m);
            //scale text rect
            _textRect = new RectangleF(_textRect.Left * scaleX, _textRect.Top * scaleY, _textRect.Width * scaleX, _textRect.Height * scaleY);
        }

        /// <summary>
        /// This method performs to get HR string(actually name of the figure)
        /// </summary>
        /// <returns>HR string</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location">figure location</param>
        /// <param name="surface">working surface</param>
        protected FigureBase(PointF location, IDrawingSurface surface)
        {
            IsNewFigure = true;
            _surface = surface;
            _borderSize = DEFAULT_PEN_SIZE;
            _borderPen = new Pen(Color.Gray, _borderSize);
            _fillBrush = new SolidBrush(Color.WhiteSmoke);
            _location = location;
            _figurePath = new GraphicsPath();
            _font = new Font("Arial", 9, FontStyle.Regular);
            _fontColor = Color.Black;
            BorderSize = DEFAULT_PEN_SIZE;
            IsDeleted = false;
            _angle = 90;
            TextBoxSize = System.Drawing.Size.Empty;
            //_startAnglePoint = new Point(_location.X, _location.Y - 10);

        }

        #region Implementation of IFigure

        /// <summary>
        /// This method performs to set figure angel
        /// </summary>
        /// <param name="angle"></param>
        public virtual void SetAngle(float angle)
        {
            _angle = (float) angle;
        }

        /// <summary>
        /// This method performs to get location of the figure
        /// </summary>
        /// <returns></returns>
        public virtual PointF GetLocation()
        {
            return _location;
        }

        /// <summary>
        /// This method performs to determine whether or not draw text inside of the figure
        /// </summary>
        /// <returns></returns>
        public virtual bool AllowText()
        {
            return true;
        }

        /// <summary>
        /// This method performs to determine whether or not allow to fill figure
        /// </summary>
        /// <returns></returns>
        public virtual bool AllowFill()
        {
            return true;
        }

        /// <summary>
        /// Figure Z index
        /// </summary>
        public int ZIndex { get; set; }

        /// <summary>
        /// Figure name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Figure text
        /// </summary>
        public virtual string Text { get; set; }
        
        
        /// <summary>
        /// Size of the border
        /// </summary>
        public int BorderSize
        {
            get { return _borderSize; }
            set 
            {
                _borderSize = value;
                if (_borderPen != null)
                {
                    _borderPen.Width = value;
                }
                CallRedraw();
            }
        }

        #endregion

        /// <summary>
        /// Font used for drawing the text
        /// </summary>
        public Font Font
        {
            get { return _font; }
            set
            {
                _font = value;
                CallRedraw();
            }
        }
        protected Font _font;

        /// <summary>
        /// Color of the font
        /// </summary>
        public Color FontColor
        {
            get { return _fontColor; }
            set 
            { 
                _fontColor = value; 
                if(value == Color.Empty)
                {
                    _fontColor = Color.Red;
                }
                CallRedraw();
            }
        }

        protected Color _fontColor;


        /// <summary>
        /// Figure bounds
        /// </summary>
        public virtual RectangleF Bounds
        {
            get
            {
                RectangleF bounds = _figurePath.GetBounds();
                return new RectangleF(bounds.Left, bounds.Top, bounds.Width, bounds.Height);
            }
        }

        /// <summary>
        /// Text bounds
        /// </summary>
        public virtual RectangleF TextBounds
        { 
            get
            {
                return new RectangleF(_textRect.X, _textRect.Y, _textRect.Width, _textRect.Height);
            } 
        }
        /// <summary>
        /// Text format
        /// </summary>
        protected virtual StringFormat StringFormat
        {
            get
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                return stringFormat;
            }
        }


        public virtual void Draw(Graphics gr)
        {
            int x = (int)(Bounds.Left);
            int y = (int)(Bounds.Top);
            //gr.TranslateTransform(x, y);
            //gr.RotateTransform(_angle);
            gr.FillPath(_fillBrush, _figurePath);
            if (_borderPen.Width > 0)
            {
                gr.DrawPath(_borderPen, _figurePath);
            }
            if (!string.IsNullOrEmpty(Text))
            {
//                gr.TranslateTransform(-_location.X, -_location.Y);
//                gr.RotateTransform(_angle);
//                gr.TranslateTransform(_location.X, _location.Y);
//
                //gr.DrawRectangle(_borderPen, _textRect.GetRect());
                DrawText(gr);
            }
            //gr.ResetTransform();
            //_angle = 0;

        }

        public virtual void DrawText(Graphics gr)
        {
            gr.DrawString(Text, Font, new SolidBrush(FontColor), _textRect, StringFormat);
        }

        public virtual float GetAngle()
        {
            return _angle;
        }


        public virtual void Offset(float dx, float dy)
        {
            _location = new PointF(_location.X + dx, _location.Y + dy);
            //            if (_location.X < 0)
            //                _location.X = 0;
            //            if (_location.Y < 0)
            //                _location.Y = 0;
            RefreshPath();
        }

        public virtual void Offset(Point current, Point start)
        {
            float dx = current.X - start.X;
            float dy = current.Y - start.Y;
            Offset(dx, dy);
        }

        public virtual void RefreshPath()
        {
            
        }

        public virtual void Rotate(float dAngle)
        {
//            int angle = (int)DrawingUtils.CalcAngel(_location, _startAnglePoint, _location, cursor);
//            Debug.WriteLine(angle);
            //angle -= _angle;
//            Matrix m = new Matrix();
//            m.Rotate(angle);
//            _figurePath.Transform(m);
//            _textRect = _figurePath.GetBounds();
//            _angle = angle;

            //_angle += angle;

            //-------------
            Matrix m = new Matrix();
            m.Translate(_location.X + Bounds.Width /2 , _location.Y + Bounds.Height /2);
            m.Rotate(dAngle);
            m.Translate(-_location.X - Bounds.Width / 2, -_location.Y - Bounds.Height / 2);
            _figurePath.Transform(m);
            //--_textRect = _figurePath.GetBounds();
            //_angle = angle;

        }
        public virtual void MoveTo(int x, int y)
        {
            _location.X = x;
            _location.Y = y;
        }

        public virtual bool IsPointVisible(Point p)
        {
            return _figurePath.IsVisible(p.X, p.Y);
        }

        public virtual List<IFigure> CreateMarkers()
        {
            List<IFigure> result = new List<IFigure>();
            var location = new Point((int)(_location.X + Bounds.Width + 2), (int)(_location.Y + Bounds.Height + 2));
            result.Add(MarkerCreator.CreateSizeMarker(location, this, _surface));
            //result.Add(MarkerCreator.CreateRotateMarker(location, this, _surface));
            return result;

        }


        public virtual void GenerateName()
        {
            Name = this.GetType().Name + ZIndex.ToString();//TODO: Use names from localization library(obfuscation!!!!)
        }

        
        public virtual List<ICommand> GetCommands()
        {
            _commands = new List<ICommand>();
            _commands.Add(new RemoveFigureCommand(this, _surface));
            //_commands.Add(new CloneFigureCommand(this, _surface));
            _commands.Add(new ChangeFigureOpacityCommand(this, _surface));
            _commands.Add(new ChangeFigureFillColorCommand(this, _surface));
            _commands.Add(new ChangeFigureBorderColorCommand(this, _surface));
            _commands.Add(new ChangeFigureBorderSizeCommand(this, _surface));
            _commands.Add(new ChangeFigureOrderCommand(this, _surface));
            if(!string.IsNullOrEmpty(Text))
            {
                _commands.Add(new ChangeFigureFontCommand(this, _surface));
                _commands.Add(new ChangeFigureFontColor(this, _surface));
            }
            return _commands;
        }

        public virtual void CallCommand(Type commandType)
        {
            foreach (var command in _commands)
            {
                if(command.GetType().Equals(commandType))
                {
                    command.Execute();
                    break;
                }
            }
        }

        public virtual bool AllowSelectRectangle()
        {
            return true;
        }


        protected static float CalcHipo(float k1, float k2)
        {
            float hipo = 0;
            hipo = (float)Math.Sqrt(k1 * k1 + k2 * k2);
            return hipo;
        }


        protected static PointF CalcPoint(PointF current, float lenght, float angle)
        {
            float ang = (float)(angle * (Math.PI / 180));
            return new PointF()
            {
                X = (float)(current.X + lenght * Math.Sin(ang)),
                Y = (float)(current.Y + lenght * Math.Cos(ang))
            };
        }

        protected float CalcAngle(PointF start, PointF end)
        {
            float dx = end.X - start.X;
            float dy = end.Y - start.Y;
            float item = (float)Math.Abs(Math.Sqrt(dx * dx + dy * dy)) / 7;
            float angle = ((float)Math.Atan(Math.Abs(dy / dx))) * ((float)(180 / Math.PI));
            angle = RotateToQuadrant(dx, dy, angle);
            return angle;
        }

        protected float RotateToQuadrant(float dx, float dy, float ang)
        {
            int qr = 1;
            float angle = ang;


            if (dy >= 0 && dx > 0)
            {
                qr = 1;
            }
            else if (dx <= 0 && dy > 0)
            {
                qr = 2;
            }
            else if (dy <= 0 && dx < 0)
            {
                qr = 3;
            }
            else if (dx >= 0 && dy < 0)
            {
                qr = 4;
            }

            switch (qr)
            {
                case 1:
                    angle = ang;
                    break;
                case 2:
                    angle = 180 - ang;
                    break;
                case 3:
                    angle = 180 + ang;
                    break;
                case 4:
                    angle = 360 - ang;
                    break;

            }


            return angle;


        }

    }
}
