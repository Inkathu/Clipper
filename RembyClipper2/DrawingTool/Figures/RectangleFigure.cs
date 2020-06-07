using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using RembyClipper2.DrawingTool;
using RembyClipper2.DrawingTool.FiguresCommands;

namespace RembyClipper2.DrawingTool.Figures
{
    /// <summary>
    /// Rectangle figure
    /// </summary>
    public class RectangleFigure : FigureBase
    {
        private RectangleF _rect;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location">figure location</param>
        /// <param name="surface">working surface</param>
        public RectangleFigure(Point location, IDrawingSurface surface) : base(location, surface)
        {
            _figurePath = new GraphicsPath();
            RefreshPath();
        }
        
        /// <summary>
        /// This method performs to refresh figure path
        /// </summary>
        public override void RefreshPath()
        {
            _rect = new RectangleF(_location.X, _location.Y, (int)_rect.Width, (int)_rect.Height);
            _figurePath.Reset();
            _figurePath.AddRectangle(_rect);
            _textRect = _rect;

        }

        /// <summary>
        /// Size of the figure
        /// </summary>
        public override SizeF Size
        {
            get { return base.Size; }
            set 
            { 

                _rect.Height = value.Height;
                _rect.Width = value.Width;
                if(_rect.Height <= 1)
                {
                    _rect.Height = 1;
                }
                if(_rect.Width <= 1)
                {
                    _rect.Width = 1;
                }
                
                _textRect = _rect;
                TextBoxSize = new Size((int)_rect.Width, (int)_rect.Height);
                //_figurePath.Reset();
                //_figurePath.AddRectangle(_rect);
                RefreshPath();
            }
        }
    }
}
