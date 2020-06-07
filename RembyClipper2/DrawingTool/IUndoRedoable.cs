using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool
{
    public interface IUndoRedoable
    {
        void AddFigureWithoutUndoRedo(IFigure figure);
        void DeleteFigureWithoutUndoRedo(IFigure figure);

    }
}