using System;
using System.Drawing;
using System.Windows.Forms;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.Markers
{

    /// <summary>
    /// Arrow marker
    /// </summary>
    public class ArrowMarker : Marker
    {
        /// <summary>
        /// Arrow figure 
        /// </summary>
        private ArrowFigure _arrowFigure;


        public bool IsStartMarker
        {
            get { return _isStart; }
        }
        /// <summary>
        /// Is it start point marker
        /// </summary>
        private bool _isStart = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location">marker location</param>
        /// <param name="figure">affected figure</param>
        /// <param name="surface">working surface</param>
        /// <param name="start">is marker for start point</param>
        public ArrowMarker(PointF location, IFigure figure, IDrawingSurface surface, bool start = false) : base(location, figure, surface)
        {
            _isStart = start;
            if (figure is ArrowFigure)
            {
                _arrowFigure = (ArrowFigure)figure;
            } else
            {
                throw new Exception("Wrong figure used for this marker");
            }
        }

        /// <summary>
        /// This method performs to move marker
        /// </summary>
        /// <param name="current"></param>
        /// <param name="start"></param>
        public override void Offset(Point current, Point start)
        {
            int dx = current.X - start.X;
            int dy = current.Y - start.Y;

            base.Offset(current, start);

            if(_isStart)
            {
                PointF p = new PointF(_arrowFigure.Start.X + dx, _arrowFigure.Start.Y + dy);
                _arrowFigure.Start = p;
            }
            else
            {
                PointF p = new PointF(_arrowFigure.End.X + dx, _arrowFigure.End.Y + dy);
                _arrowFigure.End = p;
            }

        }

        #region Overrides of Marker

        /// <summary>
        /// This method performs to get marker cursor
        /// </summary>
        /// <returns></returns>
        public override Cursor GetMarkerCursor()
        {
            return Cursors.SizeNWSE;
        }

        /// <summary>
        /// This method performs to update location of the marker
        /// </summary>
        public override void UpdateLocation()
        {
            if(_isStart)
            {
                Point p = new Point((int)(_arrowFigure.Start.X), (int)(_arrowFigure.Start.Y));
                _location = p;
            }else
            {
                Point p = new Point((int)(_arrowFigure.End.X), (int)(_arrowFigure.End.Y));
                _location = p;
            }
        }

        #endregion
    }
}