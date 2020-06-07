using System;
using System.Windows.Forms;
using Localization;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.FiguresCommands
{
    /// <summary>
    /// Command for changing order of figures
    /// </summary>
    public class ChangeFigureOrderCommand : CommandBase
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="figure">figure affected by the command</param>
        /// <param name="surface">working surface</param>
        public ChangeFigureOrderCommand(IFigure figure, IDrawingSurface surface) : base(figure, surface)
        {
            var item = new ToolStripDropDownButton(LanguageMgr.LM.GetText(Labels.Reorder), RembyClipper2.Properties.Resources.reorder);
            item.ImageScaling = ToolStripItemImageScaling.None;
            item.ToolTipText = LanguageMgr.LM.GetText(Labels.ChangeFiguresOrder);
            ToolStripMenuItem dItem = new ToolStripMenuItem(
                LanguageMgr.LM.GetText(Labels.SendToBack),
                null,
                (s, a) => Execute((ChangeOrderType)((ToolStripDropDownItem)s).Tag)
                ) { Tag = ChangeOrderType.SendToBack};
            item.DropDownItems.Add(dItem);

            dItem = new ToolStripMenuItem(
                            LanguageMgr.LM.GetText(Labels.BringToFront),
                            null,
                            (s, a) => Execute((ChangeOrderType)((ToolStripDropDownItem)s).Tag)
                            ) { Tag = ChangeOrderType.BringToFront};
            item.DropDownItems.Add(dItem);

            dItem = new ToolStripMenuItem(
                            LanguageMgr.LM.GetText(Labels.SendBackward),
                            null,
                            (s, a) => Execute((ChangeOrderType)((ToolStripDropDownItem)s).Tag)
                            ) { Tag = ChangeOrderType.SendBackward};
            item.DropDownItems.Add(dItem);

            dItem = new ToolStripMenuItem(
                            LanguageMgr.LM.GetText(Labels.BringForward),
                            null,
                            (s, a) => Execute((ChangeOrderType)((ToolStripDropDownItem)s).Tag)
                            ) { Tag = ChangeOrderType.BringForward};
            item.DropDownItems.Add(dItem);



            _item = item;


        }

        /// <summary>
        /// This method performs to execute command
        /// </summary>
        /// <param name="orderType">tyoe of figure order</param>
        public void Execute(ChangeOrderType orderType)
        {
            _surface.ChangeFigureOrder(_figure, orderType);
        }

        /// <summary>
        /// This method performs to execute the command
        /// not used for this figure.
        /// </summary>
        public override void Execute()
        {
            
        }

    }
}