using System;
using System.Windows.Forms;
using Localization;

namespace RembyClipper2.DrawingTool.SurfaceCommands
{
    /// <summary>
    /// Add rectangle command
    /// </summary>
    public class AddRectangleAddCommand : SurfaceAddCommandBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="creator">figure creator</param>
        /// <param name="surface">working surface</param>
        public AddRectangleAddCommand(FigureCreator.FigureCreator creator, IDrawingSurface surface) : base(creator, surface)
        {
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.Rectangle), RembyClipper2.Properties.Resources.icon_square, (sender, args) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.AddRectangle);
        }

    }
}