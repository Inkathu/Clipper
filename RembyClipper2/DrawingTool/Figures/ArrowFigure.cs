using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.FigureCreator;
using RembyClipper2.DrawingTool.FiguresCommands;
using RembyClipper2.DrawingTool.Markers;
using System.Linq;
using RembyClipper2.DrawingTool.SurfaceCommands;
using RembyClipper2.Utils;

namespace RembyClipper2.DrawingTool.Figures
{
    /// <summary>
    /// Arrow figure class
    /// </summary>
    public class ArrowFigure : FigureBase
    {

        /// <summary>
        /// Start point of the arrow
        /// </summary>
        public PointF Start
        {
            get { return _start; }
            set
            {
                _start = value;
                RefreshPath();
            }
        }
        private PointF _start;

        /// <summary>
        /// End point of the arrow
        /// </summary>
        public PointF End
        {
            get { return _end; }
            set
            {
                _end = value;
                RefreshPath();
            }
        }
        private PointF _end;
        
//        /// <summary>
//        /// Rectangle outside of the arrow
//        /// </summary>
//        private Rectangle _rect;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location">figure location</param>
        /// <param name="surface">working surface</param>
        public ArrowFigure(Point location, IDrawingSurface surface)
            : base(location, surface)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 1, 1.5f, -2.5f);
            path.AddLine(0, 1, -1.5f, -2.5f);
            var endLineCap = new CustomLineCap(null, path);
            endLineCap.BaseCap = LineCap.Round;
            endLineCap.StrokeJoin = LineJoin.Round;
            endLineCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
            endLineCap.WidthScale = 0.6f;
            _borderPen.EndCap = LineCap.Custom;
            _borderPen.CustomEndCap = endLineCap;
            _figurePath = new GraphicsPath();
            Start = new PointF(_location.X, _location.Y);
            End = new PointF(_location.X + DEFAULT_SIZE, _location.Y + DEFAULT_SIZE);

        }

        /// <summary>
        /// This method performs to refresh figure path structure
        /// </summary>
        public override void RefreshPath()
        {
            _figurePath.Reset();
            _figurePath.AddLine(Start.X, Start.Y, End.X, End.Y);
        }

        /// <summary>
        /// This method performs to move figure
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public override void Offset(float dx, float dy)
        {
            _location = _location.Offset(dx, dy);
            _start = _start.Offset(dx, dy);
            _end = _end.Offset(dx, dy);
            RefreshPath();
        }

        /// <summary>
        /// This method performs to move figure
        /// </summary>
        /// <param name="current"></param>
        /// <param name="start"></param>
        public override void Offset(Point current, Point start)
        {
            int dx = current.X - start.X;
            int dy = current.Y - start.Y;
            Offset(dx, dy);
            
            RefreshPath();
        }

        /// <summary>
        /// This method performs to determine could we fill figure or no
        /// </summary>
        /// <returns></returns>
        public override bool AllowFill()
        {
            return false;
        }

        /// <summary>
        /// This method performs to determine could we write text inside of the figure or no
        /// </summary>
        /// <returns></returns>
        public override bool AllowText()
        {
            return false;
        }

        /// <summary>
        /// This method performs to determine could we draw selection rectangle or no
        /// </summary>
        /// <returns></returns>
        public override bool AllowSelectRectangle()
        {
            return false;
        }

        /// <summary>
        /// Bounds for the text
        /// </summary>
        public override RectangleF TextBounds
        {
            get { return new RectangleF(Start.X, Start.Y, End.X - Start.X, End.Y - Start.Y);}
        }

        /// <summary>
        /// This method performs to determine is the passed point of the figure visible or no
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override bool IsPointVisible(Point p)
        {
            return _figurePath.IsOutlineVisible(p.X , p.Y, new Pen(Brushes.Red, 3));
        }

        /// <summary>
        /// This method performs to create markers for the figure
        /// </summary>
        /// <returns></returns>
        public override List<IFigure> CreateMarkers()
        {
            List<IFigure> result = new List<IFigure>();

            result.Add(MarkerCreator.CreateArrowMarker(Start, this, _surface, true));
            result.Add(MarkerCreator.CreateArrowMarker(End, this, _surface, false));

            return result;
        }

        /// <summary>
        /// Arrow size
        /// </summary>
        public override SizeF Size
        {
            get { return base.Size; }
            set
            {
                SizeF oldsize = Size;
                float dx = value.Width - oldsize.Width;
                float dy = value.Height - oldsize.Height;
                End = new Point((int)(End.X + dx), (int)(End.Y + dy));
                RefreshPath();
            }
        }

        /// <summary>
        /// This method performs to get arrow commands
        /// </summary>
        /// <returns>List of commands</returns>
        public override List<ICommand> GetCommands()
        {
            List<ICommand> commands = base.GetCommands();
            ICommand cmd;
            if (!AllowFill())
            {
                cmd = commands.OfType<ChangeFigureFillColorCommand>().FirstOrDefault();

                if (cmd != null)
                {
                    commands.Remove(cmd);
                }
            }

            cmd = commands.OfType<ChangeFigureBorderSizeCommand>().FirstOrDefault();
            if(cmd != null)
            {
                commands.Remove(cmd);
                commands.Add(new ChangeFigureBorderSizeCommand(this, _surface, 2));

            }
            
            return commands;
        }

        public override void SetLocation(PointF location)
        {
            int dx = (int)(location.X - _location.X);
            int dy = (int)(location.Y - _location.Y);
            base.SetLocation(location);
            _start.X += dx;
            _start.Y += dy;
            
            _end.X += dx;
            _end.Y += dy;


        }

        public override void Draw(Graphics gr)
        {
//            LineJoin old = _borderPen.LineJoin;
//
//            Brush oldBrush = _borderPen.Brush;
//            Color oldC = _borderPen.Color;
//            Brush oldFillBr = _fillBrush;
//            _borderPen.Brush = new SolidBrush(Color.FromArgb(0, Color.Black));
//            _fillBrush = new SolidBrush(Color.FromArgb(190, Color.Black));
//            gr.TranslateTransform(-2, 3f);
//            base.Draw(gr);
//            gr.ResetTransform();
//            _borderPen.Color = oldC;
//            _borderPen.Brush = oldBrush;
//            _fillBrush = oldFillBr;
            base.Draw(gr);
//            _borderPen.LineJoin = old;
        }





    }
}