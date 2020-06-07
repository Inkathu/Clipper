using System;
using System.Drawing;
using System.Windows.Forms;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.FiguresCommands
{
    /// <summary>
    /// Base class for the command infrastructure
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        /// <summary>
        /// working figure
        /// </summary>
        protected IFigure _figure;

        /// <summary>
        /// toolstrip menu item
        /// </summary>
        protected ToolStripItem _item;

        /// <summary>
        /// working surface
        /// </summary>
        protected IDrawingSurface _surface;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="surface"></param>
        protected CommandBase(IFigure figure, IDrawingSurface surface)
        {
            _surface = surface;
            _figure = figure;
        }

        #region Implementation of ICommand

        /// <summary>
        /// This method performs to execute the command
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// This method performs to get menu item of the command
        /// </summary>
        /// <returns></returns>
        public virtual ToolStripItem GetMenu()
        {
            return _item;
        }


        protected void changeItemBackColor(Color color)
        {
            _item.BackColor = color;
            _item.ForeColor = InverseColor(_item.BackColor);
        }

        private Color InverseColor(Color c)
        {
            return Color.FromArgb((byte)~c.A, (byte)~c.R, (byte)~c.G, (byte)~c.B);
        }

        public bool Enabled
        {
            set { _item.Enabled = value; }
        }

        #endregion
    }
}