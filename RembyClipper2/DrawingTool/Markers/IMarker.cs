using System.Windows.Forms;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.Markers
{
    /// <summary>
    /// Marker interface
    /// </summary>
    public interface IMarker
    {
        /// <summary>
        /// This method performs to get marker cursor
        /// </summary>
        /// <returns></returns>
        Cursor GetMarkerCursor();

        /// <summary>
        /// This method performs to update marker location
        /// </summary>
        void UpdateLocation();

        IFigure GetControlledFigure();
    }
}