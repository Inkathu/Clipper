using System;
using System.Collections.Generic;
using System.Drawing;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.FigureCreator
{
    /// <summary>
    /// Custom arrow figure builder
    /// </summary>
    public class CustomArrowCreator : FigureCreator
    {
        #region Overrides of FigureCreator

        /// <summary>
        /// This method performs to create custom arrow figure
        /// </summary>
        /// <param name="point">point of the left upper corner</param>
        /// <param name="borderColor">color of the border</param>
        /// <param name="fillColor">fill color of the figure</param>
        /// <param name="surface">working surface</param>
        /// <returns>Created figure</returns>
        public override IFigure CreateFigure(Point point, Color borderColor, Color fillColor, IDrawingSurface surface, byte opacity)
        {
            CustomArrowFigure figure = new CustomArrowFigure(point, surface);
            return InitFigure(figure, borderColor,  fillColor, AppConfig.Instance.FigureFont,
                AppConfig.Instance.FigureFontColor, LanguageMgr.LM.GetText(Labels.Arrow), 2);

        }

        #endregion
    }
}