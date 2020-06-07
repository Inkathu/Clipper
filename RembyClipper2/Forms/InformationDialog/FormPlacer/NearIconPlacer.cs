using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using RembyClipper2.Config;
using System.Linq;

namespace RembyClipper2.Forms.InformationDialog.FormPlacer
{
    public class NearIconPlacer : FormPlacerBase
    {
        public override void Place(Form form)
        {
            base.Place(form);
            Rectangle topnav = AppConfig.topnav.Bounds;
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            int oldTop = form.Top;
            form.Left = rect.Right - form.Width;
            form.Top = rect.Top;
            if((rect.Right - topnav.Right) < form.Width)
            {
                //can't place message window at the right side
                //place it at the left
                form.Top = topnav.Top;
                form.Left = topnav.Left - form.Width;

            }
            else 
            {
                //place the window at the right side
                form.Top = topnav.Top;
                form.Left = topnav.Right + 1;
            }
            if(VisibleForms.Contains(form))
            {
                form.Top = oldTop;
                 
            } else if (VisibleForms.Count > 0)
            {
                int totalHeight = VisibleForms.Select(frm => frm.Height).Aggregate((first, second) => (first + second));
                form.Top += totalHeight;
            }

        }

        public override void SlideWindow(Form wnd, int slideDiff)
        {
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            wnd.Top -= slideDiff;
            if(wnd.Top < rect.Top)
            {
                wnd.Top = rect.Top;
            }
        }

        public override AnimateWindowFlags HideWindowAnimation
        {
            get { return AnimateWindowFlags.AW_VER_NEGATIVE | AnimateWindowFlags.AW_HIDE; }
        }

        public override AnimateWindowFlags ShowWindowAnimation
        {
            get { return AnimateWindowFlags.AW_VER_POSITIVE | AnimateWindowFlags.AW_ACTIVATE; }
        }
    }
}