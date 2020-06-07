namespace RembyClipper2.DrawingTool.UndoRedo
{
    public interface IStatable
    {
        FigureState GetState(StateAction action);
    }
}