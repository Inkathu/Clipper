using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using RembyClipper2.DrawingTool;

namespace RembyClipper2.DrawingTool.Figures
{
    /// <summary>
    /// Custom arrow figure
    /// </summary>
    public class CustomArrowFigure : ArrowFigure
    {

        /// <summary>
        /// Custom arrow figure class
        /// </summary>
        /// <param name="location">figure location</param>
        /// <param name="surface">working surface</param>
        public CustomArrowFigure(Point location, IDrawingSurface surface)
            : base(location, surface)
        {
            RefreshPath();

            
        }


        //public override void DrawText(Graphics gr)
        //{
        //    float angle = CalcAngle(Start, End);
        //    gr.TranslateTransform(-_textRect.Width/2, -_textRect.Height/2);
        //    gr.RotateTransform(angle);
        //    gr.TranslateTransform(_textRect.Width / 2, _textRect.Height / 2);

        //    //gr.TranslateTransform(Start.X, Start.Y);
        //    //gr.RotateTransform(angle);

        //    _textRect.X -= Start.X;
        //    _textRect.Y -= Start.Y;
        //    base.DrawText(gr);
        //    gr.DrawRectangle(_borderPen, _textRect.GetRect());
        //    gr.ResetTransform();
        //}

        public override void Draw(Graphics gr)
        {
            //float angle = CalcAngle(Start, End);
            //gr.TranslateTransform(Start.X, Start.Y);
            //gr.RotateTransform(angle);
            _borderPen.LineJoin = LineJoin.Bevel;
            base.Draw(gr);
            _borderPen.LineJoin = LineJoin.Miter;
            //gr.ResetTransform();
        }

        public override void RefreshPath()
        {
            
            Matrix m = new Matrix();
            _figurePath = createArrowPath(Start, End);
            float angle = CalcAngle(Start, End);
            m.Rotate(angle-36);
            _figurePath.Transform(m);
            m.Reset();
            m.Translate(Start.X, Start.Y);
            _figurePath.Transform(m);
            _textRect = _figurePath.GetBounds();
            
        }

        private GraphicsPath createArrowPath(PointF start, PointF end)
        {
            GraphicsPath path = new GraphicsPath();


            float dX = end.X - start.X;
            float dY = end.Y - start.Y;
            dX = dX == 0 ? 1 : dX;

            float length = (float)Math.Abs(Math.Sqrt(dX * dX + dY * dY)) -15;
            float item = length / 7;
            
            float angle = ((float)Math.Atan(Math.Abs(dY / dX))) * ((float)(180 / Math.PI));

            angle = RotateToQuadrant(dX, dY, angle);
            List<PointF> points = new List<PointF>();

            #region fixed width
            PointF p = new PointF(0, 0.5f);
            points.Add(p);

            p = new PointF(length-5, 4);
            points.Add(p);

            p = new PointF(length -11, 11);
            points.Add(p);

            p = new PointF(length +11, 0);
            points.Add(p);

            p = new PointF(length - 11, -11);
            points.Add(p);

            p = new PointF(length - 5, -4);
            points.Add(p);

            p = new PointF(0, -0.5f);
            points.Add(p);


            #endregion


            #region latest
//            PointF p = new PointF(0, 0);
//            points.Add(p);
//
//            p = CalcPoint(p, CalcHipo(0.12f * item, 0.12f * item), 200.5f);
//            points.Add(p);
//
//            p = CalcPoint(p, CalcHipo(6f * item, 2f * item), 54f);
//            points.Add(p);
//
//            p = CalcPoint(p, CalcHipo(0.1f * item, 0.1f * item), 190.5f);
//            points.Add(p);
//
//            p = CalcPoint(p, CalcHipo(0.5f * item, 0.5f * item), 38f);
//            points.Add(p);
//            //////
//
//
//            p = CalcPoint(p, CalcHipo(0.5f * item, 0.5f * item), -110);
//            points.Add(p);
//
//
//            p = CalcPoint(p, CalcHipo(0.1f * item, 0.1f * item), -260.5f);
//            points.Add(p);
//
//            p = CalcPoint(p, CalcHipo(6f * item, 2f * item), -126.1f);
//            points.Add(p);

            #endregion

            #region third narrow variant
            //PointF p = new PointF(0, 0);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(0.2f * item, 0.2f * item), 202.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(6f * item, 2f * item), 89.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(0.2f * item, 0.2f * item), 222.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(0.7f * item, 0.7f * item), 66f);
            //points.Add(p);
            ////////


            //p = CalcPoint(p, CalcHipo(0.7f * item, 0.7f * item), -66f);
            //points.Add(p);


            //p = CalcPoint(p, CalcHipo(0.2f * item, 0.2f * item), -222.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(6f * item, 2f * item), -89f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(0.2f * item, 0.2f * item), -202.5f);
            //points.Add(p);
            #endregion

            #region second middle varriant

            //PointF p = new PointF(0, 0);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(0.4f * item, 0.53f * item), 202.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(6f * item, 1.8f * item), 87.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(0.3f * item, 0.3f * item), 222.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(1f * item, 1f * item), 62.4f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(1f * item, 1f * item), -62.4f);
            //points.Add(p);


            //p = CalcPoint(p, CalcHipo(0.3f * item, 0.3f * item), -222.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(6f * item, 1.8f * item), -87.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(0.4f * item, 0.53f * item), -202.5f);
            //points.Add(p);

            #endregion

            #region first wide variant

            //p = CalcPoint(p, CalcHipo(item, item / 2), 202.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(5.5f * item, 0.5f * item), 84.806f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(0.5f * item, 0.5f * item), 222.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(1.7f * item, 2f * item), 66.4f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(1.7f * item, 2f * item), -66.4f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(0.5f * item, 0.5f * item), -222.5f);
            //points.Add(p);

            //p = CalcPoint(p, CalcHipo(5.5f * item, 0.5f * item), -84.806f);
            //points.Add(p);

            #endregion


            path.AddPolygon(points.ToArray());
            Matrix m = new Matrix();
            m.Rotate(36);
            path.Transform(m);
            return path;
        }

        /// <summary>
        /// This method performs to determine is the passed point of the figure visible or no
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override bool IsPointVisible(Point p)
        {
            return _figurePath.IsVisible(p.X, p.Y);
        }

        public override bool AllowFill()
        {
            return true;
        }

        public override bool AllowText()
        {
            return false;
        }
    }
}