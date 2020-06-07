using System.Collections.Generic;
using System.Drawing;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.FigureCreator
{

    /// <summary>
    /// Text figure builder
    /// </summary>
    public class TextCreator : FigureCreator
    {
        #region Overrides of FigureCreator
        /// <summary>
        /// This method performs to create text figure
        /// </summary>
        /// <param name="point">point of the left upper corner</param>
        /// <param name="borderColor">color of the border</param>
        /// <param name="fillColor">fill color of the figure</param>
        /// <param name="surface">working surface</param>
        /// <returns>Created figure</returns>
        public override IFigure CreateFigure(Point point, Color borderColor, Color fillColor, IDrawingSurface surface, byte opacity)
        {
            TextFigure figure = new TextFigure(point, surface);
            //figure.BorderColor = borderColor;
            //figure.FillColor = fillColor;
            figure.Name = LanguageMgr.LM.GetText(Labels.Text);
            figure.Text = LanguageMgr.LM.GetText(Labels.TextFigureText);
            figure.Font = AppConfig.Instance.FigureFont;
            figure.FontColor = AppConfig.Instance.FigureFontColor;
            return figure;
        }

        #endregion
    }
}