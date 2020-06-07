using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.Figures;
using RembyClipper2.DrawingTool.UndoRedo;

namespace RembyClipper2.DrawingTool.FiguresCommands
{

    /// <summary>
    /// Command for changing figure border size
    /// </summary>
    public class ChangeFigureBorderSizeCommand : CommandBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="figure">affected figure</param>
        /// <param name="surface">working surface</param>
        public ChangeFigureBorderSizeCommand(IFigure figure, IDrawingSurface surface, int limit = 20) : base(figure, surface)
        {
            var item = new ToolStripDropDownButton(LanguageMgr.LM.GetText(Labels.BorderWidth), RembyClipper2.Properties.Resources.border_size);
            item.ImageScaling = ToolStripItemImageScaling.None;
            item.ToolTipText = LanguageMgr.LM.GetText(Labels.ChangeBorderWidth);
            for (int i = 0; i <= limit; i ++)
            {

                ToolStripMenuItem dItem = new ToolStripMenuItem(
                    string.Format("{0}", i == 0 ? LanguageMgr.LM.GetText(Labels.NoBorder) : i.ToString() + LanguageMgr.LM.GetText(Labels.BorderSizyType)),
                    null,
                    (s, a) => Execute((int)((ToolStripDropDownItem)s).Tag)
                    ) { Tag = (int)((double)i * 255 / 100) };
                item.DropDownItems.Add(dItem);
            }
            _item = item;

        }

        /// <summary>
        /// This method performs to execute the command
        /// </summary>
        /// <param name="borderSize">border size</param>
        public void Execute(int borderSize)
        {
            DrawingSurface.UndoManager.StoreState(new FigureState(StateAction.BorderSizeChange, _figure, _surface)); 
            _figure.BorderSize = borderSize;
            _surface.InvalidateSurface();
            AppConfig.Instance.FigureBorderSize = borderSize;
            AppConfig.Instance.Store();
        }

        /// <summary>
        /// This method performs to execute the command
        /// </summary>
        public override void Execute()
        {
          
        }

    }
}