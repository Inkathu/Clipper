using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using RembyClipper.Helpers;
using RembyClipper2.VideoEngine;

namespace RembyClipper2.Base
{
    public class BaseCaptureForm : Form
    {
        public bool AllowTransparencyKeyChange { get; set; }

        public new Color TransparencyKey { 
            get {
                return base.TransparencyKey;
            }

            set
            {
                DebugHelper.Log(base.TransparencyKey.ToString()+" "+value.ToString());
                if (AllowTransparencyKeyChange)
                    base.TransparencyKey = value;
            }

        }

        public BaseCaptureForm()
        {
            AllowTransparencyKeyChange = true;

        }
    }
}
