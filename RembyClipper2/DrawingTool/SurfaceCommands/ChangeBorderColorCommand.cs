using System;
using System.Windows.Forms;
using Localization;

namespace RembyClipper2.DrawingTool.SurfaceCommands
{

    /// <summary>
    /// Commanf changing border color
    /// </summary>
    public class ChangeBorderColorCommand : SurfaceCommandBase
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="surface"></param>
        public ChangeBorderColorCommand(IDrawingSurface surface) : base(surface)
        {
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.BorderColor), RembyClipper2.Properties.Resources.icon_bordercolor, (sender, args) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.ChangeBorderColor);
        }

        /// <summary>
        /// This method performs to execute command
        /// </summary>
        public override void Execute()
        {
            CustomColorDialog dlg = CustomColorDialog.GetInstance();
            dlg.Color = _surface.CurrentBorderColor;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                _surface.CurrentBorderColor = dlg.Color;
                _item.BackColor = dlg.Color;
            }
        }

        /// <summary>
        /// This method performs to get menu item for the command
        /// </summary>
        /// <returns></returns>
        public override ToolStripItem GetMenu()
        {
            _item.BackColor = _surface.CurrentBorderColor;
            return base.GetMenu();
        }
    }

}