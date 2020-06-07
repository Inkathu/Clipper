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
    /// Command for changing figure border color
    /// </summary>
    public class ChangeFigureBorderColorCommand : CommandBase
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="figure">affected figure</param>
        /// <param name="surface">working surface</param>
        public ChangeFigureBorderColorCommand(IFigure figure, IDrawingSurface surface) : base(figure, surface)
        {
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.BorderColor), RembyClipper2.Properties.Resources.border_color, (sender, args) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.ChangeBorderColor);
            changeItemBackColor(_figure.BorderColor);

        }

        /// <summary>
        /// This method performs to execute the command
        /// </summary>
        public override void Execute()
        {
            CustomColorDialog dlg = CustomColorDialog.GetInstance();
            dlg.Color = _figure.BorderColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DrawingSurface.UndoManager.StoreState(new FigureState(StateAction.BorderColorChange, _figure, _surface));
                _figure.BorderColor = dlg.Color;
            }

            _surface.CurrentBorderColor = _figure.BorderColor;
            AppConfig.Instance.DrawingBorderColor = _figure.BorderColor;
            changeItemBackColor(AppConfig.Instance.DrawingBorderColor);

            _surface.InvalidateSurface();

        }

      

        //private Color InverseColor(Color color)
        //{
        //    byte r = (byte)Math.Abs(~color.R);
        //    byte g = (byte)Math.Abs(~color.G);
        //    byte b = (byte)Math.Abs(~color.B);
        //    byte a = (byte)Math.Abs(~color.A);
        //    return Color.FromArgb(0, r, g, b);
        //}

    }
}