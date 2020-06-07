using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.Markers
{
    /// <summary>
    /// Marker object
    /// </summary>
    public abstract class Marker : FigureBase, IMarker
    {
        /// <summary>
        /// default size
        /// </summary>
        protected new int DEFAULT_SIZE = 3;

        /// <summary>
        /// Figure affected by the marker
        /// </summary>
        protected IFigure _figure;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location">marker location</param>
        /// <param name="figure">working figure</param>
        /// <param name="surface">working surface</param>
        public Marker(PointF location, IFigure figure, IDrawingSurface surface) : base(location, surface)
        {
            
            _figure = figure;
            _borderPen = new Pen(BorderColor, DEFAULT_PEN_SIZE);
            _fillBrush = new SolidBrush(FillColor);
            _figurePath = new GraphicsPath();
            ResetPath();

        }

        protected virtual void ResetPath()
        {
            _figurePath.Reset();
            _figurePath.AddRectangle(new RectangleF(_location.X - DEFAULT_SIZE, _location.Y - DEFAULT_SIZE, DEFAULT_SIZE * 2, DEFAULT_SIZE * 2));

        }

        /// <summary>
        /// This method performs to determine if the marker point visible or no
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override bool IsPointVisible(Point p)
        {
            if (p.X < _location.X - DEFAULT_SIZE || p.X > _location.X + DEFAULT_SIZE)
                return false;
            if (p.Y < _location.Y - DEFAULT_SIZE || p.Y > _location.Y + DEFAULT_SIZE)
                return false;

            return true;
        }

        public IFigure GetControlledFigure()
        {
            return _figure;
        }

        /// <summary>
        /// This method performs to draw marker
        /// </summary>
        /// <param name="gr"></param>
        public override void Draw(Graphics gr)
        {
            ResetPath();
            gr.FillPath(_fillBrush, _figurePath);
            gr.DrawPath(_borderPen, _figurePath);
        }

        /// <summary>
        /// This method performs to get marker cursor
        /// </summary>
        /// <returns></returns>
        public abstract Cursor GetMarkerCursor();

        /// <summary>
        /// This method performs to update marker location
        /// </summary>
        public abstract void UpdateLocation();


    }
}
