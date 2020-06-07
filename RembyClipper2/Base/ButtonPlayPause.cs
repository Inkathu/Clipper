using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace RembyClipper2.Base
{
    public partial class ButtonPlayPause : BaseControl
    {
        public ButtonPlayPause()
        {
            InitializeComponent();
        }

        public enum PlayState { Play, Pause }

        private PlayState _state = PlayState.Play;

        public PlayState State
        {
            get { return _state; }
            set { _state = value; pictureBox1_MouseLeave(null, null); }
        }

        public override void DoClick()
        {
            base.DoClick();
            pictureBox1_Click(null, null);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (_state == PlayState.Play)
                pictureBox1.Image = global::RembyClipper2.Properties.Resources.Button_play_hover;
            else
                pictureBox1.Image = global::RembyClipper2.Properties.Resources.Button_pause_hover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (_state == PlayState.Play)
                pictureBox1.Image = global::RembyClipper2.Properties.Resources.Button_play;
            else
                pictureBox1.Image = global::RembyClipper2.Properties.Resources.Button_pause;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_state == PlayState.Play)
                State = PlayState.Pause;
            else
                State = PlayState.Play;

            this.OnClick(e);
        }
    }
}
