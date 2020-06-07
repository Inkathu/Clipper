using System;
using System.Windows.Forms;

namespace RembyClipper2.DrawingTool.SurfaceCommands
{
    public class UndoCommand : SurfaceCommandBase
    {
        public UndoCommand(IDrawingSurface surface, bool enabled) : base(surface)
        {
            _item = new ToolStripButton("#Undo Text#", Properties.Resources.undo, (sender, args) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _item.ToolTipText = "#Undo tooltip text#";
            _item.Enabled = enabled;
        }

        public override void Execute()
        {
            _surface.Undo();
        }
    }
}