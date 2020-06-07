using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RembyClipper2.DrawingTool.Figures
{
    public class PrettyArrowFigure : ArrowFigure
    {
        public PrettyArrowFigure(Point location, IDrawingSurface surface) : base(location, surface)
        {
            _figurePath = new GraphicsPath();
            Start = new PointF(_location.X, _location.Y);
            End = new PointF(_location.X + DEFAULT_SIZE, _location.Y + DEFAULT_SIZE);

        }

        public override void RefreshPath()
        {
            
        }
    }
}