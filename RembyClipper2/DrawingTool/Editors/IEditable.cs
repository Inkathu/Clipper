using System.Drawing;

namespace RembyClipper2.DrawingTool
{
    /// <summary>
    /// Performs entity to be edited
    /// </summary>
    public interface IEditable
    {
        /// <summary>
        /// This method performs to change border color
        /// </summary>
        /// <param name="newColor">new color of the border</param>
        void ChangeBorderColor(Color newColor);

        /// <summary>
        /// This method performs to change border size
        /// </summary>
        /// <param name="newSize">new size of the border</param>
        void ChangeBorderSize(int newSize);

        /// <summary>
        /// This method performs to change fill color of the entity
        /// </summary>
        /// <param name="newColor">new color</param>
        void ChangeFillColor(Color newColor);

        /// <summary>
        /// This method performs to determine if the enity contain text
        /// </summary>
        /// <returns>true if entity contains text, otherwise false</returns>
        bool ContainText();
        
        /// <summary>
        /// This method performs to change entity font
        /// </summary>
        /// <param name="font">new font</param>
        void ChangeFont(Font font);

        /// <summary>
        /// This method performs to change color of the font
        /// </summary>
        /// <param name="newColor">new font color</param>
        void ChangeFontColor(Color newColor);
    }
}