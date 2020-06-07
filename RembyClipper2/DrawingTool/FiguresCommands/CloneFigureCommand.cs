using System.Drawing;
using System.Windows.Forms;
using Localization;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.FiguresCommands
{

    /// <summary>
    /// Figure clone command
    /// </summary>
    public class CloneFigureCommand : CommandBase
    {

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="figure">figure which affected by command</param>
        /// <param name="surface">working surface</param>
        public CloneFigureCommand(IFigure figure, IDrawingSurface surface) : base(figure, surface)
        {
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.Clone), RembyClipper2.Properties.Resources.clone, (sender, args) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.CloneSelectedFigure);

        }

        #region Implementation of ICommand

        /// <summary>
        /// This method performs to execute the command
        /// </summary>
        public override void Execute()
        {
            IFigure figure = _figure.Clone() as IFigure;
            figure.Offset(new Point(0,0), new Point(-10, -10));
            figure.ZIndex = FigureBase.NextIndex;
            _surface.AddFigure(figure);
            _surface.InvalidateSurface();
        }

        #endregion
    }
}