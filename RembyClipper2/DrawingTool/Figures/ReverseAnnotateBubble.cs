using System.Drawing;

namespace RembyClipper2.DrawingTool.Figures
{
    public class ReverseAnnotateBubble : AnnotateBubleFigure
    {
        public ReverseAnnotateBubble(Point location, IDrawingSurface surface) : base(location, surface, true)
        {
        }
    }
}