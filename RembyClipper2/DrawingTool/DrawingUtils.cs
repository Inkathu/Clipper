using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace RembyClipper2.DrawingTool
{

    /// <summary>
    /// Some drawing stuff
    /// </summary>
    public static class DrawingUtils
    {
        /// <summary>
        /// This method performs to draw on panel with the passed color
        /// </summary>
        /// <param name="panel">panel for drawing</param>
        /// <param name="color">color</param>
        public static void DrawColor(this Panel panel, Color color)
        {
            using(var gr = panel.CreateGraphics())
            {
                using (Brush br = new SolidBrush(color))
                {
                    gr.FillRectangle(br, panel.Bounds);
                }
            }
        }

        /// <summary>
        /// This method performs to convert RectangleF structure to Rectangle
        /// </summary>
        /// <param name="rect">RectangleF structure</param>
        /// <returns>Rectangle structure</returns>
        public static Rectangle GetRect(this RectangleF rect)
        {
            return new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }


        /// <summary>
        /// This method performs to calculate angle between 2 lines
        /// </summary>
        /// <param name="l1S">line 1 start point</param>
        /// <param name="l1E">line 1 end point</param>
        /// <param name="l2S">line 2 start point</param>
        /// <param name="l2E">line 2 end point</param>
        /// <returns>angle</returns>
        public static double CalcAngel(Point l1S, Point l1E, Point l2S, Point l2E)
        {
            //(y-y1)/(y2-y1)=(x-x1)/(x2-x1)
            //k = (y2-y1)/(x2-x1)
            int j = (l1E.X - l1S.X);
            if(j == 0)
            {
                j = 1;
            }
            double k1 = Math.Abs((l1E.Y - l1S.Y)/j);
            int i = (l2E.X - l2S.X);
            if(i == 0)
            {
                i = 1;
            }
            double k2 = Math.Abs((l2E.Y - l2S.Y)/i);
            double tg = Math.Abs((k2 - k1)/(1 + k1*k2));
            double angRad = Math.Atan(tg); //arctan of tg
            double angDeg = angRad * 180.0 / Math.PI; //radians to degrees
            double ang = (int)Math.Floor(angDeg) % 360; //get an angle and clamp him to [0; 360]
            return ang;
        }

        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}