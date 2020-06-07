using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Utils.Meesenger
{
    public partial class NotificationBase : UserControl, INotification
    {
//        public event EventHandler Clicked;

        [Browsable(true)]
        [DefaultValue(15)]
        public int RoundingRadius { get; set; }

        string INotification.Text
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public new string Text
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public Image Image
        {
            get { return pictureBox.Image; }
            set { pictureBox.Image = value; }
        }

        public string Timer
        {
            set { timerLabel.Text = value; }
        }

        public bool CanBeRemoved { get; set; }

        public DateTime TTL { get; set; }

        object INotification.Tag { get { return this.Tag; } set { this.Tag = value; } }
        int INotification.Height { get { return this.Height; } set { this.Height = value; } }
        int INotification.Width { get { return this.Width; } set { this.Width = value; } }

        protected event EventHandler NotificationHided;

        public bool closedByCross = false;

        public NotificationBase()
        {
            InitializeComponent();
            RoundingRadius = 18;
            SizeChanged += new EventHandler(Control_SizeChanged);
            Control_SizeChanged(this, EventArgs.Empty);
            CanBeRemoved = true;
            TTL = DateTime.Now.AddSeconds(5);
            

        }

        /// <summary>
        /// Should be called at moment of the removing notification from the notifications area window
        /// </summary>
        public void OnNotificationRemoved()
        {
            if(NotificationHided != null)
            {
                NotificationHided(this, EventArgs.Empty);
            }
        }

        public INotification ExtendTTL(int seconds)
        {
            TTL = TTL.AddSeconds(seconds);
            return this;
        }



        void Control_SizeChanged(object sender, EventArgs e)
        {
            GraphicsPath clipPath = new GraphicsPath();
            int r = RoundingRadius;
            int w = Width;
            int h = Height;
            clipPath.StartFigure();
            clipPath.AddArc(-1, -1, r, r, 180, 90);
            clipPath.AddLine(r, -1, w - r, -1);
            clipPath.AddArc(w - r, -1, r, r, 270, 90);
            clipPath.AddLine(w, r, w, h - r);
            clipPath.AddArc(w - r, h - r, r, r, 0, 90);
            clipPath.AddLine(w - r, h, r, h);
            clipPath.AddArc(-1, h - r, r, r, 90, 90);
            clipPath.CloseFigure();
            Region = new Region(clipPath);
        }

        private void label_Click(object sender, EventArgs e)
        {
            CanBeRemoved = false;
        }

        public void InitiateClosing()
        {
            CanBeRemoved = true;
            TTL = DateTime.Now.AddSeconds(-1);
        }
        private void NotificationCross_Click(object sender, EventArgs e)
        {
            closedByCross = true;
            InitiateClosing();
        }

        public void ShowTTL()
        {
            timerLabel.Visible = true;
            TimeSpan ts = TTL - DateTime.Now;
            timerLabel.Text = (ts.Seconds + 1).ToString();
        }
    }
}
