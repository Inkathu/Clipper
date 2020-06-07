using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RembyClipper2.Base;
using RembyClipper2.Config;
using RembyClipper2.DrawingTool.Editors;
using System.Linq;
using RembyClipper2.Forms.InformationDialog.FormPlacer;
using RembyClipper2.Helpers;
using RembyClipper2.Utils.Meesenger;

namespace RembyClipper2.Forms
{
    public partial class NotificationsAreaForm : Form
    {
        Button btn = new Button();

        Timer remover = new Timer();

        /// <summary>
        /// This property performs to hide window from alt+tab
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        public Place DefaultPlace { get; set; }

        public NotificationsAreaForm()
        {
            InitializeComponent();
            Load += new EventHandler(Form1_Load);
            remover.Tick += new EventHandler(remover_Tick);
            remover.Interval = 500;
            DefaultPlace = AppConfig.Instance.MessageBoxDefaultPlace;
            this.DoubleBuffered = true;
            

        }

        void remover_Tick(object sender, EventArgs e)
        {
            var toStay = flowLayoutPanel1.Controls.Cast<INotification>().Where(
                notification => notification.CanBeRemoved && (DateTime.Now < notification.TTL)).ToList();
            toStay.ForEach(notification => notification.ShowTTL());
            var toRemove = flowLayoutPanel1.Controls.Cast<INotification>().Where(notification => notification.CanBeRemoved && (DateTime.Now > notification.TTL)).ToList();
            if (toRemove.Count() > 0)
            {
                toRemove.ForEach(controlRemover);

            } else if(flowLayoutPanel1.Controls.Count == 0)
            {
                remover.Stop();
            }
            this.Invalidate();
            
        }
        private void controlRemover(INotification control)
        {
            Timer t = new Timer();
            t.Interval = 10;
            t.Tick += new EventHandler(ControlRemoveTimerTick);
            t.Tag = control;
            ((Control)control).SuspendLayout();
            t.Start();

        }

        private void ControlRemoveTimerTick(object sender, EventArgs e)
        {
            Control ctrl = (Control)((Timer) sender).Tag;
            INotification notif = ctrl as INotification;
            if (ctrl.Height > 5)
            {
                ctrl.Height-=5;
            }
            else
            {
                ((Timer)sender).Stop();
                flowLayoutPanel1.Controls.Remove(ctrl);
                if(notif != null)
                {
                    notif.OnNotificationRemoved();
                }
                
            }
            Invalidate();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            WIN32_API.MakeWindowTopMost(this.Handle);
        }

        /// <summary>
        /// This method performs to find appropriate place for the area(near R icon or somewhere in the corner
        /// </summary>
        public void CheckPlace()
        {
            var r = Screen.PrimaryScreen.WorkingArea;
            DefaultPlace = AppConfig.Instance.MessageBoxDefaultPlace;
            switch (DefaultPlace)
            {
                case Place.BottomRight:
                    Top = r.Top;
                    Left = r.Right - this.Width;
                    Height = r.Height;
                    flowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
                    break;
                case Place.TopRight:
                    Top = r.Top;
                    Left = r.Right - this.Width;
                    Height = r.Height;
                    flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                    break;
                case Place.NearIcon:
                    if (Width > (r.Width - AppConfig.topnav.Right))
                    {
                        //to few place at the right side of R icon - move area to the left side
                        Top = AppConfig.topnav.Top;
                        Left = AppConfig.topnav.Left - Width;
                        Height = r.Height;


                    }else
                    {
                        //to few place at the left side of R icon - move area to the right side

                        Top = AppConfig.topnav.Top;
                        Left = AppConfig.topnav.Right;
                        Height = r.Height;

                    }
                    flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// This method performs to add new notification
        /// </summary>
        /// <param name="notification"></param>
        public void AddNotification(INotification notification)
        {
            if (IsHandleCreated)
            {
                BeginInvoke((MethodInvoker) CheckPlace);
                BeginInvoke((MethodInvoker) (() => ControlAdder(notification, flowLayoutPanel1)));
            }
        }

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            var ctrl =
                new NotificationBase()
                    {
                        Text = "qrwerwerwerwerwer",
                        Image = RembyClipper2.Properties.Resources.tick1
                    };
            AddNotification(ctrl);
        }

        private Random rnd = new Random();

        /// <summary>
        /// This method performs to add new notification to the area
        /// </summary>
        /// <param name="ctrl">control for adding</param>
        /// <param name="parent">parent</param>
        private void ControlAdder(INotification ctrl, FlowLayoutPanel parent)
        {
            ctrl.Width += rnd.Next(100);

            if(parent.Width > ctrl.Width)
            {
                var m = ((Control)ctrl).Margin;
                ((Control)ctrl).Margin = new Padding(parent.Width - ctrl.Width, m.Top, m.Right, m.Bottom);
            } else
            {
                ctrl.Width = parent.Width - ((Control)ctrl).Margin.Left;
            }
            ctrl.Tag = ctrl.Height;
            ctrl.Height = 1;
            parent.Controls.Add((Control)ctrl);
            //parent.Controls.SetChildIndex(ctrl, 0);
            Timer t1 = new Timer();
            t1.Interval = 1;
            t1.Tick += new EventHandler(AddControlTimerTick);
            t1.Tag = ctrl;
            t1.Start();
            if(!remover.Enabled)
            {
                remover.Start();
            }
        }

        void AddControlTimerTick(object sender, EventArgs e)
        {
            Control ctrl = ((Timer)sender).Tag as Control;
            int height = (int)ctrl.Tag;
            if (ctrl.Height < height)
            {
                ctrl.Height+=4;
            } else
            {
                ((Timer)sender).Stop();
            }
            Invalidate();
        }

    }

    public class CustomFlowLayoutPanel : FlowLayoutPanel
    {
        public CustomFlowLayoutPanel()
        {
            DoubleBuffered = true;
        }
    }
}
