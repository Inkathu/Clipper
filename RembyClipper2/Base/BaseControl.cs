using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public delegate void CustomButtonClicked();
    public delegate void CustomError();

    public class BaseControl : UserControl
    {
        public BaseControl()
        {
            
            if (!this.DesignMode)
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.DoubleBuffer, true);
                this.Disposed += new EventHandler(BaseControl_Disposed);
            }
        }

        public virtual void DoClick()
        {
            OnClick(new EventArgs());
        }

        void BaseControl_Disposed(object sender, EventArgs e)
        {
            foreach (var c in this.Controls)
            {
                if (c is PictureBox)
                {
                    PictureBox p = (PictureBox)c;
                    if (p.BackgroundImage != null)
                        p.BackgroundImage.Dispose();
                    if (p.Image != null)
                        p.Image.Dispose();
                }

                if (c is IDisposable)
                    ((IDisposable)c).Dispose();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }

      
    }
}
