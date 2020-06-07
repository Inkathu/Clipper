using System.Collections.Generic;
using RembyClipper2.DrawingTool;

namespace RembyClipper2.DrawingTool.Figures
{
    /// <summary>
    /// Interface for entity which provide the command emit
    /// </summary>
    public interface ICommandsProvider
    {
        /// <summary>
        /// This method performs to get list of commands which could be allpied for the emittent object
        /// </summary>
        /// <returns>List of commands</returns>
        List<ICommand> GetCommands();
    }
}