using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.DrawingTool.Editors
{
    /// <summary>
    /// Double buffered panel.  Need to avoid flickering at drawing process.
    /// </summary>
    public partial class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint | 
                          ControlStyles.OptimizedDoubleBuffer, true);

            this.UpdateStyles();
        }
    }
}
