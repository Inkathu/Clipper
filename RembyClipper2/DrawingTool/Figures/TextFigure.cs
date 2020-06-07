using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.FiguresCommands;

namespace RembyClipper2.DrawingTool.Figures
{

    /// <summary>
    /// Text figure class
    /// </summary>
    public class TextFigure : RectangleFigure
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location">figure location</param>
        /// <param name="surface">working surface</param>
        public TextFigure(Point location, IDrawingSurface surface)
            : base(location, surface)
        {
            _borderPen = new Pen(Color.Transparent, DEFAULT_PEN_SIZE);
            _fillBrush = new SolidBrush(Color.Transparent);

        }

        /// <summary>
        /// This method performs to get figure commands
        /// </summary>
        /// <returns>List of commands</returns>
        public override List<ICommand> GetCommands()
        {
            List<ICommand> commands = base.GetCommands();

            ICommand cmd = commands.OfType<ChangeFigureFillColorCommand>().FirstOrDefault();

            if (cmd != null)
            {
                commands.Remove(cmd);
            }

            cmd = commands.OfType<ChangeFigureBorderColorCommand>().FirstOrDefault();

            if (cmd != null)
            {
                commands.Remove(cmd);
            }

           cmd = commands.OfType<ChangeFigureOpacityCommand>().FirstOrDefault();

            if (cmd != null)
            {
                commands.Remove(cmd);
            }

           cmd = commands.OfType<ChangeFigureBorderSizeCommand>().FirstOrDefault();

            if (cmd != null)
            {
                commands.Remove(cmd);
            }

            return commands;
        }

    }
}