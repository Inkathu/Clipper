/*
 * Benutzer: thomas
 * Datum: 20.03.2007
 * Zeit: 21:54
 * 
 */

using System;
using System.Drawing;

namespace RembyClipper.Helpers
{
	/// <summary>
	/// Description of GuiRectangle.
	/// </summary>
	public class GuiRectangle
	{
		private GuiRectangle()
		{
			
		}

        public static RectangleF GetGuiRectangle(float x, float y, float w, float h)
        {
			if (w < 0) {
				x = x + w;
				w = -w;
			}
			if (h < 0) {
				y = y + h;
				h = -h;
			}
			return new RectangleF(x, y, w, h);
		}

        public static Rectangle GetGuiRectangleInt(float x, float y, float w, float h)
        {
            if (w < 0)
            {
                x = x + w;
                w = -w;
            }
            if (h < 0)
            {
                y = y + h;
                h = -h;
            }
            return new Rectangle((int)x, (int)y, (int)w, (int)h);
        }
		
	}
}
