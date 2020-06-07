using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public static class Utils
    {
        public static Color Minus(byte alpha, Color color, int val)
        {
            int r = color.R - val;
            byte R = (byte)(r < 0 ? 0 : r);

            int g = color.G - val;
            byte G = (byte)(g < 0 ? 0 : g);

            int b = color.B - val;
            byte B = (byte)(b < 0 ? 0 : b);
            return Color.FromArgb(alpha, R, G, B);
        }

        public static Color Plus(byte alpha, Color color, int val)
        {
            return Minus(alpha, color, val * (-1));
        }

        public static void ShowCustom(this ToolTip toolTip, string message, Control ctrl, int interval = 5000)
        {
            toolTip.Show(message, ctrl, interval);
            Timer t = new Timer() { Tag = toolTip, Interval = interval};
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        static void t_Tick(object sender, EventArgs e)
        {
            Timer t = sender as Timer;
            
            if(t != null)
            {
                ToolTip tt = t.Tag as ToolTip;
                if(tt != null)
                {
                    tt.RemoveAll();
                }
                t.Stop();
                t.Dispose();
            }
        }

        public static void Invoke(this Control control, Action action)
        {
            if (control.IsHandleCreated)
            {
                control.BeginInvoke((Delegate)action);
            }
        }
        public static void Invoke(this Form form, Action action)
        {
            if (form.IsHandleCreated)
            {
                form.BeginInvoke((Delegate)action);
            }
        }
    }
}
