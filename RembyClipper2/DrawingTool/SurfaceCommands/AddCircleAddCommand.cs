using System.Windows.Forms;
using Localization;

namespace RembyClipper2.DrawingTool.SurfaceCommands
{
    /// <summary>
    /// Add circle command
    /// </summary>
    public class AddCircleAddCommand : SurfaceAddCommandBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="creator">Figure creator</param>
        /// <param name="surface">working surface</param>
        public AddCircleAddCommand(FigureCreator.FigureCreator creator, IDrawingSurface surface) : base(creator, surface)
        {
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.Circle), RembyClipper2.Properties.Resources.icon_circle, (s, a) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.AddCircle);
        }
    }
}