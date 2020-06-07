using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.Markers
{
    /// <summary>
    /// Rotate marker
    /// </summary>
    public class RotateMarker : Marker
    {
        public RotateMarker(Point location, IFigure figure, IDrawingSurface surface)
            : base(location, figure, surface)
        {
        }

        /// <summary>
        /// Move marker
        /// </summary>
        /// <param name="current"></param>
        /// <param name="start"></param>
        public override void Offset(Point current, Point start)
        {

            base.Offset(current, start);
            PointF figCenter = _figure.GetLocation();
            double y2 = current.Y;
            double y1 = figCenter.Y;
            double x2 = current.X;
            double x1 = figCenter.X;
            float angle = (float)Math.Atan2((y1 - y2), (x1 - x2));
            angle = angle  * ((float)(180 / Math.PI));

            float angleCur = _figure.GetAngle();
            float dAngle = (angle - angleCur);
            _figure.SetAngle(angle);
            _figure.Rotate(dAngle);
        }

        /// <summary>
        /// This method performs to get marker cursor
        /// </summary>
        /// <returns></returns>
        public override Cursor GetMarkerCursor()
        {
            return Cursors.SizeNWSE;
        }

        /// <summary>
        /// This method performs to update marker location
        /// </summary>
        public override void UpdateLocation()
        {
            RectangleF bounds = _figure.Bounds;
            _location = new Point((int)(Math.Round(bounds.Left) + bounds .Width/ 2 + DEFAULT_SIZE / 2), (int)Math.Round(bounds.Top) - DEFAULT_SIZE / 2);
        }

        /// <summary>
        /// This method performs to draw marker
        /// </summary>
        /// <param name="gr"></param>
        public override void Draw(Graphics gr)
        {
            gr.DrawEllipse(_borderPen, _location.X - DEFAULT_SIZE, _location.Y - DEFAULT_SIZE, DEFAULT_SIZE * 2, DEFAULT_SIZE * 2);
            gr.FillEllipse(_fillBrush, _location.X - DEFAULT_SIZE, _location.Y - DEFAULT_SIZE, DEFAULT_SIZE * 2, DEFAULT_SIZE * 2);
        }

    }
}