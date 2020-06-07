using System;
using System.Drawing;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.FigureCreator
{
    public class AnnotateBubleCreator : FigureCreator
    {
        public override IFigure CreateFigure(Point point, Color borderColor, Color fillColor, IDrawingSurface surface, byte opacity)
        {
            AnnotateBubleFigure figure = new AnnotateBubleFigure(point, surface);
            return InitFigure(figure, borderColor, fillColor, AppConfig.Instance.FigureFont, AppConfig.Instance.FigureFontColor, LanguageMgr.LM.GetText(Labels.AnnotateBubble), AppConfig.Instance.FigureBorderSize);
        }
    }

    public class ReverseAnnotateBubleCreator : FigureCreator
    {
        public override IFigure CreateFigure(Point point, Color borderColor, Color fillColor, IDrawingSurface surface, byte opacity)
        {
            AnnotateBubleFigure figure = new AnnotateBubleFigure(point, surface, true);
            return InitFigure(figure, borderColor, fillColor, AppConfig.Instance.FigureFont, AppConfig.Instance.FigureFontColor, LanguageMgr.LM.GetText(Labels.AnnotateBubble), AppConfig.Instance.FigureBorderSize);
        }
    }
}