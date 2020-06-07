using System;
using System.Windows.Forms;
using Localization;

namespace RembyClipper2.DrawingTool.SurfaceCommands
{
    /// <summary>
    /// Change fill color command
    /// </summary>
    public class ChangeFillColorCommand : SurfaceCommandBase
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="surface">working surface</param>
        public ChangeFillColorCommand(IDrawingSurface surface) : base(surface)
        {
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.FillColor), RembyClipper2.Properties.Resources.icon_fillcolor, (sender, args) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.ChangeFillColor);


        }

        /// <summary>
        /// This method performs to execute the command
        /// </summary>
        public override void Execute()
        {
            CustomColorDialog dlg = CustomColorDialog.GetInstance();
            dlg.Color = _surface.CurrentFillColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _surface.CurrentFillColor = dlg.Color;
                _item.BackColor = dlg.Color;
            }
        }


        /// <summary>
        /// This method performs to get menu for the command
        /// </summary>
        /// <returns></returns>
        public override ToolStripItem GetMenu()
        {
            _item.BackColor = _surface.CurrentFillColor;
            return base.GetMenu();
        }
    }
}