using System;
using System.Collections.Generic;
using System.Drawing;
using RembyClipper2.DrawingTool.UndoRedo;

namespace RembyClipper2.DrawingTool.Figures
{
    /// <summary>
    /// Figure interface
    /// </summary>
    public interface IFigure : ICommandsProvider, ICloneable//, IStatable
    {
        /// <summary>
        /// Figure redrawing event
        /// </summary>
        event EventHandler RedrawFigure;

        event EventHandler DragFinished;

        event EventHandler SizeChanged;
        bool IsNewFigure { get; set; }
        Size TextBoxSize { get; set; }
        /// <summary>
        /// Size of the border
        /// </summary>
        int BorderSize { get; set; }

        /// <summary>
        /// Color of the border
        /// </summary>
        Color BorderColor { get; set; }

        /// <summary>
        /// Fill color
        /// </summary>
        Color FillColor { get; set; }

        /// <summary>
        /// ZIndex of the figure
        /// </summary>
        int ZIndex { get; set; }

        /// <summary>
        /// Figure name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Figure font
        /// </summary>
        Font Font { get; set; }

        /// <summary>
        /// Figure font color
        /// </summary>
        Color FontColor { get; set; }

        /// <summary>
        /// Figure text
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Figure bounds
        /// </summary>
        RectangleF Bounds { get; }

        /// <summary>
        /// Size of the figure
        /// </summary>
        SizeF Size { get; set; }

        /// <summary>
        /// Is figure deleted or no?
        /// </summary>
        bool IsDeleted { get; set; }

        /// <summary>
        /// Text bounds
        /// </summary>
        RectangleF TextBounds { get; }

        /// <summary>
        /// Draw graphics
        /// </summary>
        /// <param name="gr"></param>
        void Draw(Graphics gr);

        /// <summary>
        /// Move figure
        /// </summary>
        /// <param name="current">current point</param>
        /// <param name="start">start point</param>
        void Offset(Point current, Point start);

        /// <summary>
        /// Move figure
        /// </summary>
        /// <param name="dx">x axis offset </param>
        /// <param name="dy">y axis offset</param>
        void Offset(float dx, float dy);
        
        /// <summary>
        /// Create figure markers
        /// </summary>
        /// <returns>List of markers</returns>
        List<IFigure> CreateMarkers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>Check is the passed point in figure visible
        /// <returns>true if visible, otherwise false</returns>
        bool IsPointVisible(Point p);

        /// <summary>
        /// Move figure to location
        /// </summary>
        /// <param name="x">location x coord</param>
        /// <param name="y">location y coord</param>
        void MoveTo(int x, int y);

        /// <summary>
        /// Whether or not allow text in figure
        /// </summary>
        /// <returns>true if text allowed, otherwise false</returns>
        bool AllowText();

        /// <summary>
        /// Whether or not allow figure filling
        /// </summary>
        /// <returns>true if allowed, otherwise false</returns>
        bool AllowFill();
        

        /// <summary>
        /// Whether or not allow to draw selection rectangle
        /// </summary>
        /// <returns></returns>
        bool AllowSelectRectangle();

        /// <summary>
        /// This method performs to rotate the figure
        /// </summary>
        /// <param name="angel"></param>
        void Rotate(float angel);

        /// <summary>
        /// This method performs to get figure angel
        /// </summary>
        /// <returns></returns>
        float GetAngle();

        void SetLocation(PointF location);
        /// <summary>
        /// This method performs to set figure angel
        /// </summary>
        /// <param name="angle">angel</param>
        void SetAngle(float angle);
        
        /// <summary>
        /// This method performs to generate figure name
        /// </summary>
        void GenerateName();

        /// <summary>
        /// This method performs to get figure location
        /// </summary>
        /// <returns></returns>
        PointF GetLocation();

        /// <summary>
        /// This method performs to execute command for the figure
        /// </summary>
        /// <param name="commandType">type of the command</param>
        void CallCommand(Type commandType);

        /// <summary>
        /// This method performs to refresh figure path structure
        /// </summary>
        void RefreshPath();

        /// <summary>
        /// 
        /// </summary>
        void TellThatDragFinished();


        void TellThatSizeChanged();
        void CalcSizeForInnerText();
    }
}