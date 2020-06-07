using System.Windows.Forms;
using Localization;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.FiguresCommands
{
    /// <summary>
    /// Command for removing figure 
    /// </summary>
    public class RemoveFigureCommand : CommandBase
    {
        /// <summary>
        /// Copstructor
        /// </summary>
        /// <param name="figure">affected figure</param>
        /// <param name="surface">working surface</param>
        public RemoveFigureCommand(IFigure figure, IDrawingSurface surface) : base(figure, surface)
        {
            _surface = surface;
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.Remove), RembyClipper2.Properties.Resources.remove, (sender, args) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.RemoveFigure);
        }


        /// <summary>
        /// This method performs to execute the command
        /// </summary>
        public override void Execute()
        {
            _surface.DeleteFigure(_figure);
            _figure.IsDeleted = true;
            _surface.InvalidateSurface();
            ToolStrip toolStrip = _item.GetCurrentParent();
            if(toolStrip != null)
            {
                toolStrip.Items.Clear();    
            }
            
        }


    }
}