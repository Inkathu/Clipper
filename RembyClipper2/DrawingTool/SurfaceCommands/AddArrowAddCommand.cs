using System.Windows.Forms;
using Localization;

namespace RembyClipper2.DrawingTool.SurfaceCommands
{
    /// <summary>
    /// Add arrow command
    /// </summary>
    public class AddArrowAddCommand : SurfaceAddCommandBase
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="creator">Figure creator</param>
        /// <param name="surface">working surface</param>
        public AddArrowAddCommand(FigureCreator.FigureCreator creator, IDrawingSurface surface) : base(creator, surface)
        {
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.Arrow), RembyClipper2.Properties.Resources.SimpleArrow, (s, a) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.AddArrow);
        }
    }
}