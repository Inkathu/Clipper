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
    /// Command for changing opacity of te figure
    /// </summary>
    public class ChangeFigureOpacityCommand : CommandBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="figure">figure affected by the command</param>
        /// <param name="surface">working surface</param>
        public ChangeFigureOpacityCommand(IFigure figure, IDrawingSurface surface) : base(figure, surface)
        {

            var item = new ToolStripDropDownButton(LanguageMgr.LM.GetText(Labels.Opacity), RembyClipper2.Properties.Resources.opacity);
            item.ImageScaling = ToolStripItemImageScaling.None;
            item.ToolTipText = LanguageMgr.LM.GetText(Labels.ChangeFigureOpacity);
            for (int i = 0; i <= 100; i+=10)
            {

                ToolStripMenuItem dItem = new ToolStripMenuItem(
                    string.Format("{0}%", i),
                    null,
                    (s, a) => Execute((int) ((ToolStripDropDownItem) s).Tag)
                    ) {Tag = (int)((double)i * 255 / 100)};
                item.DropDownItems.Add(dItem);
            }
            _item = item;
        }

        /// <summary>
        /// This method performs to execute command
        /// </summary>
        /// <param name="opacity">new opacity for the figure</param>
        public void Execute(int opacity)
        {
            DrawingSurface.UndoManager.StoreState(new FigureState(StateAction.OpacityChange, _figure, _surface));
            _figure.BorderColor = Color.FromArgb(opacity, _figure.BorderColor);
            _figure.FillColor = Color.FromArgb(opacity, _figure.FillColor);
            _figure.FontColor = Color.FromArgb(opacity, _figure.FontColor);
            AppConfig.Instance.FigureOpacity = (byte)opacity;
            AppConfig.Instance.DrawingFillrColor = _figure.FillColor;
            AppConfig.Instance.DrawingBorderColor = _figure.BorderColor;
            AppConfig.Instance.FigureFontColor = _figure.FontColor;
            _surface.CurrentFillColor = _figure.FillColor;
            _surface.CurrentBorderColor = _figure.BorderColor;
            _surface.InvalidateSurface();
        }

        /// <summary>
        /// This method performs to  execute command
        /// </summary>
        public override void Execute()
        {
           
        }
    }
}