using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using RembyClipper2.DrawingTool.Markers;
using RembyClipper2.Utils;

namespace RembyClipper2.DrawingTool.Figures
{
    public class AnnotateBubleFigure : FigureBase
    {
       
        private List<PointF> points = new List<PointF>();
        private RectangleF _rect;
        private bool _reverse;
        public AnnotateBubleFigure(Point location, IDrawingSurface surface, bool reverse = false) : base(location, surface)
        {
            _figurePath = new GraphicsPath();
            _reverse = reverse;
        }

        public override void RefreshPath()
        {
            Matrix m = new Matrix();
            float item = 0;
            _figurePath = createPath(_location, new PointF(_location.X + _rect.Width, _location.Y + _rect.Height), out item);
            m.Translate(_location.X, _location.Y);
            _figurePath.Transform(m);
            _textRect = _rect;
            _textRect.Offset(_location.X, _location.Y);

        }

        public override void Draw(Graphics gr)
        {
            var old = _borderPen.LineJoin;
            _borderPen.LineJoin = LineJoin.Round;
            //gr.TranslateTransform(Bounds.X + Bounds.Width, Bounds.Y + Bounds.Height);
            //gr.RotateTransform(-90);
            //gr.TranslateTransform(-(Bounds.X + Bounds.Width/2), -(Bounds.Y + Bounds.Height/2));
           
            base.Draw(gr);
            //gr.ResetTransform();
            _borderPen.LineJoin = old;
        }


        public PointF AnnotatePoint
        {
            get { return _annotatePoint; }
            set
            {
                PointF old = _annotatePoint;
                _annotatePoint = value;
                OnAnnotatePointLocationChanged(old, value);
            }
        }
        private PointF _annotatePoint;
        
        private bool pointShouldNotBeRecalculated = false;
        private float _item;
        private GraphicsPath createPath(PointF start, PointF end, out float itemSize)
        {

            GraphicsPath path = new GraphicsPath();

            float dX = end.X - start.X;
            float dY = end.Y - start.Y;
            dX = dX == 0 ? 1 : dX;

            _item = (float)Math.Abs(Math.Sqrt(dX * dX + dY * dY)) / 7;
            itemSize = _item;
            //float angle = ((float)Math.Atan(Math.Abs(dY / dX))) * ((float)(180 / Math.PI));
            _item *= 0.75f;
            List<PointF> points = new List<PointF>();

            switch (_pointPlace)
            {
                case PointPlace.BottomRight:
                    CreateBottomRightPoints(dX, dY, _item, points);
                    break;
                case PointPlace.BottomLeft:
                    CreateBottomLeftPoints(dX, dY, _item, points);
                    break;
                case PointPlace.RightBottom:
                    CreateRightBottomPoints(dX, dY, _item, points);
                    break;
                case PointPlace.RightTop:
                    CreateRightTopPoints(dX, dY, _item, points);
                    break;
                case PointPlace.TopLeft:
                    CreateTopLeftPoints(dX, dY, _item, points);
                    break;
                case PointPlace.TopRight:
                    CreateTopRightPoints(dX, dY, _item, points);
                    break;
                case PointPlace.LeftTop:
                    CreateLeftTopPoints(dX, dY, _item, points);
                    break;
                case PointPlace.LeftBottom:
                    CreateLeftBottomPoints(dX, dY, _item, points);
                    break;
                case PointPlace.None:
                    CreateBottomRightPoints(dX, dY, _item, points);
                    break;
                default:
                    CreateBottomRightPoints(dX, dY, _item, points);
                    break;
            }

          
            

            


            path.AddPolygon(points.ToArray());

            
            //Debug.WriteLine(string.Format("item = {0}", item));
            return path;
        }
        public override void CalcSizeForInnerText()
        {
            pointShouldNotBeRecalculated = !pointShouldNotBeRecalculated;
            base.CalcSizeForInnerText();
            RefreshPath();
        }

        private void CreateBottomRightPoints(float dX, float dY, float item, List<PointF> points)
        {
            points.Add(new PointF(0, 0));
            points.Add(new PointF(dX, 0));
            points.Add(new PointF(dX, dY));


            points.Add(new PointF(dX - item, dY));
            if (!pointShouldNotBeRecalculated || IsNewFigure)
            {
                AnnotatePoint = new PointF(dX - item, dY + item);
                pointShouldNotBeRecalculated = true;
            }
            points.Add(AnnotatePoint);
            points.Add(new PointF(dX - item - item, dY));
            points.Add(new PointF(0, dY));
        }
 
        private void CreateBottomLeftPoints(float dX, float dY, float item, List<PointF> points)
        {
            if(IsNewFigure)
            {
                _pointPlace = PointPlace.BottomRight;
            }
            points.Add(new PointF(0, 0));
            points.Add(new PointF(dX, 0));
            points.Add(new PointF(dX, dY));

            points.Add(new PointF(0 + 2 * item, dY));

            if (!pointShouldNotBeRecalculated)
            {
                AnnotatePoint = new PointF(0 + item, dY + item);
                pointShouldNotBeRecalculated = true;
            }
            points.Add(AnnotatePoint);
            points.Add(new PointF(0 + item, dY));
            points.Add(new PointF(0, dY));
        }
        private void CreateRightBottomPoints(float dX, float dY, float item, List<PointF> points)
        {
            points.Add(new PointF(0, 0));
            points.Add(new PointF(dX, 0));
            points.Add(new PointF(dX, dY - 2 * item));
            if (!pointShouldNotBeRecalculated)
            {
                AnnotatePoint = new PointF(dX + item, dY - 1 * item);
                pointShouldNotBeRecalculated = true;
            }
            points.Add(AnnotatePoint);
            points.Add(new PointF(dX, dY - 1 * item));
            points.Add(new PointF(dX, dY));
            points.Add(new PointF(0, dY));
        }

        private void CreateRightTopPoints(float dX, float dY, float item, List<PointF> points)
        {
            points.Add(new PointF(0, 0));
            points.Add(new PointF(dX, 0));
            points.Add(new PointF(dX, 0+item));
            if (!pointShouldNotBeRecalculated)
            {
                AnnotatePoint = new PointF(dX + item, 0 + item);
                pointShouldNotBeRecalculated = true;
            }
            points.Add(AnnotatePoint);
            points.Add(new PointF(dX, 0 + 2 * item));
            points.Add(new PointF(dX, dY));
            points.Add(new PointF(0, dY));
        }
        private void CreateLeftBottomPoints(float dX, float dY, float item, List<PointF> points)
        {
            points.Add(new PointF(0, 0));
            points.Add(new PointF(dX, 0));
           
            points.Add(new PointF(dX, dY));
            points.Add(new PointF(0, dY));
            points.Add(new PointF(0, dY - 1 * item));
            if (!pointShouldNotBeRecalculated)
            {
                AnnotatePoint = new PointF(0 - item, dY - 2 * item);
                pointShouldNotBeRecalculated = true;
            }
            points.Add(AnnotatePoint);
            points.Add(new PointF(0, dY - 2 * item));
        }

        private void CreateLeftTopPoints(float dX, float dY, float item, List<PointF> points)
        {
            if(IsNewFigure)
            {
                _pointPlace = PointPlace.BottomRight;
            }
            points.Add(new PointF(0, 0));
            points.Add(new PointF(dX, 0));

            points.Add(new PointF(dX, dY));
            points.Add(new PointF(0, dY));
            points.Add(new PointF(0, 0 + 2 * item));
            if (!pointShouldNotBeRecalculated)
            {
                AnnotatePoint = new PointF(0 - item, 0 + 1 * item);
                pointShouldNotBeRecalculated = true;
            }
            points.Add(AnnotatePoint);
            points.Add(new PointF(0, 0 + 1 * item));
        }
        
        private void CreateTopLeftPoints(float dX, float dY, float item, List<PointF> points)
        {
            points.Add(new PointF(0, 0));
            
            points.Add(new PointF(0 + item, 0));
            if (!pointShouldNotBeRecalculated)
            {
                AnnotatePoint = new PointF(0 + item, 0 - item);
                pointShouldNotBeRecalculated = true;
            }
            points.Add(AnnotatePoint);


            points.Add(new PointF(2*item, 0));

            points.Add(new PointF(dX, 0));

            points.Add(new PointF(dX, dY));
            points.Add(new PointF(0, dY));
        }

  
        private void CreateTopRightPoints(float dX, float dY, float item, List<PointF> points)
        {
            points.Add(new PointF(0, 0));
            
            points.Add(new PointF(dX - 2 * item, 0));
            if (!pointShouldNotBeRecalculated)
            {
                AnnotatePoint = new PointF(dX - item, 0 - item);
                pointShouldNotBeRecalculated = true;
            }
            points.Add(AnnotatePoint);


            points.Add(new PointF(dX - item, 0));

            points.Add(new PointF(dX, 0));

            points.Add(new PointF(dX, dY));
            points.Add(new PointF(0, dY));
        }


        private PointPlace _pointPlace = PointPlace.BottomRight;
        public event EventHandler AnnotatePointLocationChanged;
        protected virtual void OnAnnotatePointLocationChanged(PointF oldValue, PointF newValue)
        {
            
            EventHandler eventToRise = AnnotatePointLocationChanged;
            
            if(oldValue != newValue)
            {
                PointPlace whereToDraw = WhereToDraw();
                if (whereToDraw != _pointPlace)
                {
                    onAnnotatePlaceChanged(_pointPlace, whereToDraw);
                    _pointPlace = whereToDraw;
                }
                if (eventToRise != null)
                {
                    eventToRise(this, EventArgs.Empty);
                }
                
            }
        }
        private void onAnnotatePlaceChanged(PointPlace old, PointPlace newPl)
        {
            CallRedraw();
        }
        private PointPlace WhereToDraw()
        {
            PointPlace result = PointPlace.BottomRight;
            PointF p = new PointF(AnnotatePoint.X + _location.X, AnnotatePoint.Y + _location.Y);
            RectangleF r = Bounds;
            float cx = r.Left + r.Width/2; //center  X
            float cy = r.Top + r.Height/2; //center  X
            if (p.Y > cy && p.Y < r.Bottom)
            {
                result = p.X > cx ? PointPlace.RightBottom : PointPlace.LeftBottom;
            }
            else if (p.Y > r.Top && p.Y < cy)
            {
                result = p.X > cx ? PointPlace.RightTop: PointPlace.LeftTop;
            }
            else if (p.X > cx/* && p.X < r.Right*/)
            {
                result = p.Y > cy ? PointPlace.BottomRight : PointPlace.TopRight;
            }
            else if (/*p.X > r.Left && */p.X <= cx)
            {
                result = p.Y > cy ? PointPlace.BottomLeft : PointPlace.TopLeft;
            }
  

            return result;
        }

        /// <summary>
        /// Size of the figure
        /// </summary>
        public override SizeF Size
        {
            get { return _rect.Size; }
            set
            {
                float resultHeight = value.Height;
                float resultWidth = value.Width;


                if (value.Height < 10 + _item)
                {
                    resultHeight = 10 + _item;
                }

                if(value.Width < 10 + _item)
                {
                    resultWidth = 10 + _item;
                }

                _rect.Height = resultHeight;
                _rect.Width = resultWidth;
                if (!IsNewFigure)
                {
                    _pointPlace = WhereToDraw();
                }



                RefreshPath();
            }
        }

        public override List<IFigure> CreateMarkers()
        {
            List<IFigure> markers = new List<IFigure>();
            markers.AddRange(base.CreateMarkers());
            markers.Add(new AnnotateFigureMarker(new PointF(_location.X +  (int)AnnotatePoint.X, _location.Y + (int)AnnotatePoint.Y), this, _surface));
            return markers;
        }

        public override RectangleF Bounds
        {
            get { return new RectangleF(_location.X, _location.Y, _rect.Width, _rect.Height); }
        }

        public override void Offset(float dx, float dy)
        {

            _location = _location.Offset(dx, dy);
            AnnotatePoint = new PointF(AnnotatePoint.X - dx, AnnotatePoint.Y - dy);
            RefreshPath();
        }
    }

    public enum PointPlace
    {
        BottomRight,
        BottomLeft,
        RightBottom, 
        RightTop,
        TopLeft,
        TopRight,
        LeftTop,
        LeftBottom,
        None
    }
}