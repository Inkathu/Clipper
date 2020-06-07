using System;
using System.Drawing;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.SurfaceCommands
{
    /// <summary>
    /// Add text command
    /// </summary>
    public class AddTextAddCommand : SurfaceAddCommandBase
    {
        /// <summary>
        /// default size of the figure
        /// </summary>
        private const int DEFAULT_SIZE = 100;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="creator">figure creator</param>
        /// <param name="surface">working surface</param>
        public AddTextAddCommand(FigureCreator.FigureCreator creator, IDrawingSurface surface) : base(creator, surface)
        {
            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.Text), RembyClipper2.Properties.Resources.icon_text, (sender, args) => Execute());
            _item .ImageScaling = ToolStripItemImageScaling.None;
            _item.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.AddText);
        }

        /// <summary>
        /// This method performs to execute command
        /// </summary>
        public override void Execute()
        {
            var point = new Point(
                (_surface.SurfaceSize.Width - DEFAULT_SIZE)/2,
                (_surface.SurfaceSize.Height - DEFAULT_SIZE) / 2);
            var figure = _creator.CreateFigure(point, _surface.CurrentBorderColor, _surface.CurrentFillColor,
                                               _surface, AppConfig.Instance.FigureOpacity);
            
            figure.Size = new SizeF(DEFAULT_SIZE, DEFAULT_SIZE);
            _surface.AddFigure(figure);
            
            var s = System.Configuration.ConfigurationManager.AppSettings.Get("SendKeys");
            _surface.SetFocus();
            SendKeys.SendWait("{F2}");
        }

    }
}