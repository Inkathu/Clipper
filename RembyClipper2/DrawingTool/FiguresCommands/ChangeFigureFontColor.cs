using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.FiguresCommands
{
    /// <summary>
    /// Command for changing figure font color
    /// </summary>
    public class ChangeFigureFontColor : CommandBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="figure">affected figure</param>
        /// <param name="surface">working surface</param>
        public ChangeFigureFontColor(IFigure figure, IDrawingSurface surface) : base(figure, surface)
        {
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.FontColor), RembyClipper2.Properties.Resources.text_color, (sender, args) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.ChangeTextColor);
            changeItemBackColor(_figure.FontColor);
        }

        /// <summary>
        /// This method performs to execute command
        /// </summary>
        public override void Execute()
        {
            CustomColorDialog d = CustomColorDialog.GetInstance();
            d.Color = _figure.FontColor;
            if (d.ShowDialog() == DialogResult.OK)
            {
                _figure.FontColor = d.Color;
                AppConfig.Instance.FigureFontColor = d.Color;
                changeItemBackColor(AppConfig.Instance.FigureFontColor);
                AppConfig.Instance.Store();
            }
            _surface.InvalidateSurface();
        }

    }
}