using System;
using System.Drawing;
using RembyClipper2.DrawingTool.Figures;

namespace RembyClipper2.DrawingTool.UndoRedo
{


    public enum StateAction
    {
        Add,
        Remove,
        Move,
        SizeChange, 
        BorderColorChange,
        FillColorChange,
        ArrowStartMove,
        ArrowEndMove,
        OpacityChange,
        BorderSizeChange,
    }

    public class FigureState
    {
        private PointF _location;
        private SizeF _size;
        private Color _fillColor;
        private Color _borderColor;
        private StateAction _action;
        private IFigure _figure;
        private IDrawingSurface _surface;
        private PointF _arrowStart;
        private PointF _arrowEnd;
        private byte _opacity;
        private int _borderSize;
        private ArrowFigure _arrow
        {
            get { return _figure as ArrowFigure; }
        }


        public FigureState(StateAction action, IFigure referencedFigure, IDrawingSurface surface)
        {
            _action = action;
            _figure = referencedFigure;
            _surface = surface;

            switch (action)
            {
                case StateAction.Add:
                    break;
                case StateAction.Remove:
                    break;
                case StateAction.Move:
                    _location = referencedFigure.GetLocation();
                    break;
                case StateAction.SizeChange:
                    _size = referencedFigure.Size;
                    break;
                case StateAction.BorderColorChange:
                    _borderColor = referencedFigure.BorderColor;
                    break;
                case StateAction.FillColorChange:
                    _fillColor = referencedFigure.FillColor;
                    break;
                case StateAction.ArrowEndMove:
                    if(_arrow != null)
                    {
                        _arrowEnd = _arrow.End;
                    }
                    break;
                case StateAction.ArrowStartMove:
                    if (_arrow != null)
                    {
                        _arrowStart = _arrow.Start;
                    }
                    break;
                case StateAction.BorderSizeChange:
                    _borderSize = _figure.BorderSize;
                break;
                case StateAction.OpacityChange:
                    _opacity = _figure.FillColor.A;
                break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }

        public void AcceptState()
        {
            switch (_action)
            {
                case StateAction.Add:
                    _surface.DeleteFigureWithoutUndoRedo(_figure);
                    break;
                case StateAction.Remove:
                    _surface.AddFigureWithoutUndoRedo(_figure);
                    break;
                case StateAction.Move:
                    _figure.SetLocation(_location);
                    break;
                case StateAction.SizeChange:
                    _figure.Size = _size;
                    break;
                case StateAction.BorderColorChange:
                    _figure.BorderColor = _borderColor;
                    break;
                case StateAction.FillColorChange:
                    _figure.FillColor = _fillColor;
                    break;
                case StateAction.ArrowEndMove:
                    if (_arrow != null)
                    {
                        _arrow.End = _arrowEnd;
                    }
                    break;
                case StateAction.ArrowStartMove:
                    if (_arrow != null)
                    {
                        _arrow.Start = _arrowStart;
                    }
                    break;
                case StateAction.BorderSizeChange:
                    _figure.BorderSize = _borderSize;
                break;
                case StateAction.OpacityChange:
                    _figure.BorderColor = Color.FromArgb(_opacity, _figure.BorderColor);
                    _figure.FillColor = Color.FromArgb(_opacity, _figure.FillColor);
                break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public FigureState ReverseIfRequired()
        {
            switch (_action)
            {
                case StateAction.Add:
                    _action = StateAction.Remove;
                    break;
                case StateAction.Remove:
                    _action = StateAction.Add;
                    break;
                case StateAction.Move:
                    _location = _figure.GetLocation();
                    break;
                case StateAction.SizeChange:
                    _size = _figure.Size;
                    break;
                case StateAction.BorderColorChange:
                    _borderColor = _figure.BorderColor;
                    break;
                case StateAction.FillColorChange:
                    _fillColor = _figure.FillColor;
                    break;
                case StateAction.ArrowEndMove:
                    if (_arrow != null)
                    {
                        _arrowEnd = _arrow.End;
                    }
                    break;
                case StateAction.ArrowStartMove:
                    if (_arrow != null)
                    {
                        _arrowStart = _arrow.End;
                    }
                break;
                case StateAction.BorderSizeChange:
                    _borderSize = _figure.BorderSize;
                break;
                case StateAction.OpacityChange:
                    _opacity = _figure.FillColor.A;
                break;
            }

            return this;
        }

        public FigureState Clone()
        {

            return (FigureState) MemberwiseClone();
        }
    }
}