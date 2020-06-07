using System;
using System.Collections.Generic;

namespace RembyClipper2.DrawingTool.UndoRedo
{
    public class UndoRedoManager
    {
        private readonly Stack<FigureState> _states;
        private readonly Stack<FigureState> _redoStates;


        public event EventHandler ActionCalled;

        public UndoRedoManager()
        {
            _states = new Stack<FigureState>();
            _redoStates = new Stack<FigureState>();
        }

        public void StoreState(FigureState state)
        {
            _states.Push(state);
            _redoStates.Clear();
            if (ActionCalled != null)
            {
                ActionCalled(this, EventArgs.Empty);
            }
        }


        public FigureState Undo()
        {
            if(_states.Count == 0)
            {
                return null;
            }
            FigureState figureState = _states.Pop();
            FigureState redoState = figureState.Clone();
            _redoStates.Push(redoState.ReverseIfRequired());
            if(ActionCalled != null)
            {
                ActionCalled(this, EventArgs.Empty);
            }
            return figureState;
        }

        public FigureState Redo()
        {
            if(_redoStates.Count == 0)
            {
                return null;
            }
            FigureState figureState = _redoStates.Pop();
            FigureState undoState = figureState.Clone();
            _states.Push(undoState.ReverseIfRequired());
            if (ActionCalled != null)
            {
                ActionCalled(this, EventArgs.Empty);
            }
            return figureState;
        }

        public void ClearStates()
        {
            _states.Clear();
            _redoStates.Clear();
        }

        public bool IsUndoAvailable()
        {
            return _states.Count > 0;
        }
        public bool IsRedoAvailable()
        {
            return _redoStates.Count > 0;
        }


    }
}