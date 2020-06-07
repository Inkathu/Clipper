using System.Windows.Forms;

namespace RembyClipper2.DrawingTool.SurfaceCommands
{

    /// <summary>
    /// Add figure command
    /// </summary>
    public abstract class SurfaceAddCommandBase : SurfaceCommandBase
    {
        /// <summary>
        /// Figure creator
        /// </summary>
        protected FigureCreator.FigureCreator _creator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="creator">figure creator</param>
        /// <param name="surface">working surface</param>
        protected SurfaceAddCommandBase(FigureCreator.FigureCreator creator, IDrawingSurface surface) : base(surface)
        {
            _creator = creator;
        }

        /// <summary>
        /// This method performs to execute the command
        /// </summary>
        public override void Execute()
        {
            _surface.InitiateFigureAdding(_creator);
        }
    }
}