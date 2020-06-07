using System;
using System.Drawing;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.Figures;
using RembyClipper2.DrawingTool.UndoRedo;

namespace RembyClipper2.DrawingTool.FiguresCommands
{
    /// <summary>
    /// Command for changing figure fill command
    /// </summary>
    public class ChangeFigureFillColorCommand : CommandBase
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="figure">affected figure</param>
        /// <param name="surface">working surface</param>
        public ChangeFigureFillColorCommand(IFigure figure, IDrawingSurface surface) : base(figure, surface)
        {
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.FillColor), RembyClipper2.Properties.Resources.fill_color, (sender, args) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.ChangeFillColor);
            changeItemBackColor(_figure.FillColor);
        }

        /// <summary>
        /// This method performs to execute the command
        /// </summary>
        public override void Execute()
        {
            CustomColorDialog dlg = CustomColorDialog.GetInstance();
            dlg.Color = _figure.FillColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DrawingSurface.UndoManager.StoreState(new FigureState(StateAction.FillColorChange, _figure, _surface));
                _figure.FillColor = dlg.Color;
            }

            _surface.CurrentFillColor = _figure.FillColor;
            AppConfig.Instance.DrawingFillrColor = _figure.FillColor;
            changeItemBackColor(AppConfig.Instance.DrawingFillrColor);
            _surface.InvalidateSurface();
            
        }
    }
}