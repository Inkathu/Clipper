using System.Windows.Forms;

namespace RembyClipper2.DrawingTool.SurfaceCommands
{
    public class RedoCommand : SurfaceCommandBase
    {
        public RedoCommand(IDrawingSurface surface, bool enabled) : base(surface)
        {
            _item = new ToolStripButton("#Redo Text#", Properties.Resources.redo, (sender, args) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _item.ToolTipText = "#Redo tooltip text#";
            _item.Enabled = enabled;
        }

        public override void Execute()
        {
            _surface.Redo();
        }
    }
}