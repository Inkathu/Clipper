using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RembyClipper2.Base
{
    public class BaseListView : System.Windows.Forms.ListView
    {
        public event EventHandler Scroll;
        private const int WM_HSCROLL = 0x0114;
        private const int WM_VSCROLL = 0x0115;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_MOUSEWHEEL = 0x020A;


        public BaseListView()
        {
            BackColor = Color.FromArgb(0xC9, 0xCA, 0xCA);
        }

        protected void OnScroll()
        {

            if (this.Scroll != null)
                this.Scroll(this, EventArgs.Empty);

        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_VSCROLL ||
             m.Msg == WM_HSCROLL ||
             m.Msg == WM_KEYDOWN ||
             m.Msg == WM_MOUSEWHEEL)
                this.OnScroll();
        }
    }
}
