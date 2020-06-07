using System.Drawing;
using RembyClipper2.DrawingTool.Figures;
using RembyClipper2.DrawingTool.Markers;

namespace RembyClipper2.DrawingTool.FigureCreator
{
    /// <summary>
    /// Types of marker
    /// </summary>
    public enum MarkerType
    {
        /// <summary>
        /// Marker for width changing
        /// </summary>
        WidthMarker,

        /// <summary>
        /// Markerfor height chaning
        /// </summary>
        HeightMarker,
        
        /// <summary>
        /// Both H & W change marker
        /// </summary>
        HeightWidthMarker,
    }

    /// <summary>
    /// Marker figure creator
    /// </summary>
    public static class MarkerCreator
    {
      
        /// <summary>
        /// This method performs to create size marker
        /// </summary>
        /// <param name="location">marker location</param>
        /// <param name="figure">figure  that marker belongs to</param>
        /// <param name="surface">working surface</param>
        /// <returns>Created marker</returns>
        public static IFigure CreateSizeMarker(Point location, IFigure figure, IDrawingSurface surface)
        {
            SizeMarker marker = new SizeMarker(location, figure, surface) { BorderColor = Color.Red, FillColor = Color.Black};
            return marker;

        }

        /// <summary>
        /// This method performs to create rotate marker
        /// </summary>
        /// <param name="location">marker location</param>
        /// <param name="figure">figure  that marker belongs to</param>
        /// <param name="surface">working surface</param>
        /// <returns>Created marker</returns>
        public static IFigure CreateRotateMarker(Point location, IFigure figure, IDrawingSurface surface)
        {
            RotateMarker marker = new RotateMarker(location, figure, surface) { BorderColor = Color.Black, FillColor = Color.Yellow };
            return marker;
        }

        /// <summary>
        /// This method performs to create arrow marker
        /// </summary>
        /// <param name="location">marker location</param>
        /// <param name="figure">figure  that marker belongs to</param>
        /// <param name="surface">working surface</param>
        /// <returns>Created marker</returns>
        public static IFigure CreateArrowMarker(PointF location, IFigure figure, IDrawingSurface surface, bool isStart)
        {
            ArrowMarker marker = new ArrowMarker(location, figure, surface, isStart) { BorderColor = Color.Black, FillColor = Color.Black };
            return marker;
        }
    }
}