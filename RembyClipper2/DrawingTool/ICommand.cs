using System.Windows.Forms;

namespace RembyClipper2.DrawingTool
{
    /// <summary>
    /// Command interface
    /// </summary>
    public interface ICommand
    {

        /// <summary>
        /// This method performs to execute the command
        /// </summary>
        void Execute();

        /// <summary>
        /// This method performs to get menu item for the command
        /// </summary>
        /// <returns>menu item</returns>
        ToolStripItem GetMenu();

        bool Enabled { set; }
    }
}
