using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RembyClipper2.Forms.InformationDialog.FormPlacer
{
    public class BottomRightPlacer : FormPlacerBase
    {
        #region Implementation of IFormPlacer

        public override void Place(Form form)
        {
            base.Place(form);
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            int oldTop = form.Top;
            form.Left = rect.Right - form.Width;
            form.Top = rect.Bottom - form.Height;

            if (VisibleForms.Contains(form))
            {
                form.Top = oldTop;

            }
            else if (VisibleForms.Count > 0)
            {
                int totalHeight = VisibleForms.Select(frm => frm.Height).Aggregate((first, second) => (first + second));
                form.Top -= totalHeight;
            }
        }

        public override void SlideWindow(Form wnd, int slideDiff)
        {
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            wnd.Top += slideDiff;
            if(wnd.Bottom > rect.Bottom)
            {
                wnd.Top = rect.Bottom - wnd.Height;
            }
          
        }

        #endregion
    }
}