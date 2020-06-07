using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using RembyClipper2.DrawingTool;

namespace RembyClipper2.DrawingTool.Figures
{

    /// <summary>
    /// Circle afigure class
    /// </summary>
    public class CircleFigure : FigureBase
    {
        /// <summary>
        /// circle width
        /// </summary>
        private float _width;

        /// <summary>
        /// circe height
        /// </summary>
        private float _height;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location">figure location</param>
        /// <param name="surface">working surface</param>
        public CircleFigure(Point location, IDrawingSurface surface)
            : base(location, surface)
        {
            _figurePath = new GraphicsPath();
            _width = DEFAULT_SIZE;
            _height = DEFAULT_SIZE;
            
            
            RecalcTextArea();
        }

        /// <summary>
        /// This method performs to refresh figure path structure
        /// </summary>
        public override void RefreshPath()
        {
            _figurePath.Reset();
            _figurePath.AddEllipse(_location.X, _location.Y, _width, _height);
            RecalcTextArea();

        }

        /// <summary>
        /// This method performs to recalculate area for text drawing
        /// </summary>
        private void RecalcTextArea()
        {
            float hW = _width / 2;
            float hH = _height / 2;
            float o = (_width/2) * 0.65f; // offset
            float hr = _height/2; //half radius
            _textRect = new RectangleF(_location.X, _location.Y, _width, _height);
            //_textRect = new RectangleF(hr - o, hr - o, (hr - o) * 3.8f, (hr - o) * 3.8f);
        }


        /// <summary>
        /// Size of the figure
        /// </summary>
        public override SizeF Size
        {
            get { return base.Size; }
            set
            {
                _height = value.Height;
                _width = value.Width;
                RefreshPath();
            }
        }
    }
}