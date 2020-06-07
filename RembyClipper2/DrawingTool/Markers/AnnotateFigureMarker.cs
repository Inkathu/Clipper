using System;
using System.Drawing;
using System.Windows.Forms;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.Markers
{
    public class AnnotateFigureMarker : Marker
    {
        public AnnotateFigureMarker(PointF location, IFigure figure, IDrawingSurface surface) : base(location, figure, surface)
        {
            _borderPen = new Pen(Color.Black, 2);
            _fillBrush = new SolidBrush(Color.Gray);
            
        }

        /// <summary>
        /// This method performs to move figure
        /// </summary>
        /// <param name="current">current point</param>
        /// <param name="start">start point</param>
        public override void Offset(Point current, Point start)
        {
            RectangleF bounds = _figure.Bounds;
            PointF center = new Point((int) Math.Round(bounds.Right), (int) Math.Round(bounds.Bottom));
            int dx = current.X - start.X;
            int dy = current.Y - start.Y;

            base.Offset(current, start);
            //_figure.Size = SizeF.Add(_figure.Size, new SizeF(dx, dy));
            AnnotateBubleFigure figure = _figure as AnnotateBubleFigure;
            if (figure != null)
            {
                figure.AnnotatePoint = new PointF(figure.AnnotatePoint.X + dx, figure.AnnotatePoint.Y + dy);
            }
            _figure.RefreshPath();
        }

        /// <summary>
        /// This method performs to get marker cursor
        /// </summary>
        /// <returns></returns>
        public override Cursor GetMarkerCursor()
        {
            return Cursors.Cross;
        }

        /// <summary>
        /// This method performs to update marker location
        /// </summary>
        public override void UpdateLocation()
        {
            AnnotateBubleFigure figure = _figure as AnnotateBubleFigure;
            if(figure == null)
            {
                return;
            }
            //RectangleF bounds = _figure.Bounds;
            //_location = new Point((int)Math.Round(bounds.Right ) + DEFAULT_SIZE / 2 + 20, (int)Math.Round(bounds.Bottom) + DEFAULT_SIZE / 2 + 20);
            //_location = new Point((int)figure.AnnotatePoint.X + figure.GetLocation().X, (int)figure.AnnotatePoint.Y +figure.GetLocation().Y);
            _location = new PointF(figure.GetLocation().X + (int)figure.AnnotatePoint.X,
                                  (figure.GetLocation().Y + (int)figure.AnnotatePoint.Y));
        }
    }
}