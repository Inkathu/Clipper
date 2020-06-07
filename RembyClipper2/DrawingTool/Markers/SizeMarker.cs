using System;
using System.Drawing;
using System.Windows.Forms;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.Markers
{
    /// <summary>
    /// Size change marker
    /// </summary>
    public class SizeMarker : Marker
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location">marker location</param>
        /// <param name="figure">affected figure</param>
        /// <param name="surface">worknig surface</param>
        public SizeMarker(Point location, IFigure figure, IDrawingSurface surface)
            : base(location, figure, surface)
        {
        }

        /// <summary>
        /// This method performs to move figure
        /// </summary>
        /// <param name="current">current point</param>
        /// <param name="start">start point</param>
        public override void Offset(Point current, Point start)
        {
            int dx = current.X - start.X;
            int dy = current.Y - start.Y;

            base.Offset(current, start);
            _figure.Size = SizeF.Add(_figure.Size, new SizeF(dx, dy));

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
            _location = new Point((int)Math.Round(bounds.Right) + DEFAULT_SIZE / 2, (int)Math.Round(bounds.Bottom) + DEFAULT_SIZE / 2);
        }
    }
}