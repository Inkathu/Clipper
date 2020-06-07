using System.Collections.Generic;
using System.Drawing;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.FigureCreator
{
    /// <summary>
    /// Abstract figure builder
    /// </summary>
    public abstract class FigureCreator
    {
        /// <summary>
        /// This method performs to create figure
        /// </summary>
        /// <param name="point">point of the left upper corner</param>
        /// <param name="borderColor">color of the border</param>
        /// <param name="fillColor">fill color of the figure</param>
        /// <param name="surface">working surface</param>
        /// <param name="opacity">figure opacity</param>
        /// <returns>Created figure</returns>
        public abstract IFigure CreateFigure(Point point, Color borderColor, Color fillColor, IDrawingSurface surface, byte opacity);

        public IFigure InitFigure(IFigure figure, Color borderColor, Color fillColor, Font font, Color fontColor, string name, int borderSize)
        {
            figure.BorderColor = borderColor;
            figure.FillColor = fillColor;
            figure.Name = name;
            figure.Font = font;
            figure.FontColor = fontColor == Color.Empty ? Color.Red : fontColor;
            figure.BorderSize = borderSize;
            return figure;
        }
    }
}