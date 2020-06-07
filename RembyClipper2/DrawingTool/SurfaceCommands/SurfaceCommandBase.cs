using System.Windows.Forms;

namespace RembyClipper2.DrawingTool.SurfaceCommands
{
    /// <summary>
    /// Base class for command affected to the surface
    /// </summary>
    public abstract class SurfaceCommandBase : ICommand
    {
        /// <summary>
        /// Working surface
        /// </summary>
        protected IDrawingSurface _surface;

        /// <summary>
        /// Menu item
        /// </summary>
        protected ToolStripItem _item;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="surface"></param>
        protected SurfaceCommandBase(IDrawingSurface surface)
        {
            _surface = surface;
        }

        /// <summary>
        /// This method performs to execute command
        /// </summary>
        public abstract void Execute();


        /// <summary>
        /// This method performs to get menu item for the command
        /// </summary>
        /// <returns></returns>
        public virtual ToolStripItem GetMenu()
        {
            return _item;
        }        

        public bool Enabled
        {
            set { _item.Enabled = value; }
        }
    }
}