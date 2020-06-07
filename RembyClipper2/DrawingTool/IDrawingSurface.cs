using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool
{
    /// <summary>
    /// Figure order changing type
    /// </summary>
    public enum ChangeOrderType
    {
        SendToBack,
        BringToFront,
        SendBackward,
        BringForward
    }

    /// <summary>
    /// Surface interface
    /// </summary>
    public interface IDrawingSurface : IUndoRedoable
    {
        /// <summary>
        /// This method performs to get surface commands
        /// </summary>
        /// <returns></returns>
        List<ICommand> GetCommands();

        /// <summary>
        /// This method performs to add figure to the surface
        /// </summary>
        /// <param name="figure">figure</param>
        void AddFigure(IFigure figure);

        /// <summary>
        /// This method performs to delete figure form the surface
        /// </summary>
        /// <param name="figure">figure</param>
        void DeleteFigure(IFigure figure);

        /// <summary>
        /// This method performs to invalidate surface
        /// </summary>
        void InvalidateSurface();

        /// <summary>
        /// This method performs to initiate figure adding process
        /// </summary>
        /// <param name="creator"></param>
        void InitiateFigureAdding(FigureCreator.FigureCreator creator);
        
        /// <summary>
        /// This method performs to Change figure order
        /// </summary>
        /// <param name="figure">affected figure</param>
        /// <param name="changeType">change type</param>
        void ChangeFigureOrder(IFigure figure, ChangeOrderType changeType);

        /// <summary>
        /// This method performs to set back image of the surface
        /// </summary>
        /// <param name="img">image</param>
        void SetImage(Image img);


        /// <summary>
        /// Current border Color of the figures
        /// </summary>
        Color CurrentBorderColor { get; set; }

        /// <summary>
        /// Fill color of the figures 
        /// </summary>
        Color CurrentFillColor { get; set; }

        /// <summary>
        /// Size of the surface
        /// </summary>
        Size SurfaceSize { get; }

        /// <summary>
        /// This method performs to show some debug info
        /// </summary>
        /// <param name="str"></param>
        [Obsolete]
        void ShowDebugInfo(string str);

        /// <summary>
        /// Performs to set focus to the surface
        /// </summary>
        void SetFocus();

        void Undo();
        void Redo();
        void UpdateUndoRedo();

    }
}