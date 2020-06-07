using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.FiguresCommands
{
    /// <summary>
    /// Command for changenging font for the figure
    /// </summary>
    public class ChangeFigureFontCommand : CommandBase
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="figure">Affected figure</param>
        /// <param name="surface">working surface</param>
        public ChangeFigureFontCommand(IFigure figure, IDrawingSurface surface) : base(figure, surface)
        {
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.Font), RembyClipper2.Properties.Resources.font, (sender, args) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.ChangeTextFont);

        }

        
        /// <summary>
        /// This method performs to execute the command
        /// </summary>
        public override void Execute()
        {
            FontDialog d = new FontDialog();
            d.Font = _figure.Font;
            if(d.ShowDialog() == DialogResult.OK)
            {
                _figure.Font = d.Font;
                AppConfig.Instance.FigureFont = d.Font;
                AppConfig.Instance.Store();
            }
            _surface.InvalidateSurface();
        }
    }
}