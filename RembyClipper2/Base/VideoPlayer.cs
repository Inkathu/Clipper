using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using RembyClipper2.Helpers;
using RembyClipper2.VideoEngine;
using System.Threading;
using System.IO;
using RembyClipper2.Config;
using RembyClipper.Helpers;
using FilePlayer;



namespace RembyClipper2.Base
{
    public partial class VideoPlayer : BaseControl
    {
        public event CustomError OnVideoError;

        private enum PlayState
        {
            Play,
            Pause
        }

        private PlayState state;
        public VideoPlayer()
        {
            AppConfig.SuspendForceGC = true;
            InitializeComponent();
            this.Disposed += new EventHandler(VideoPlayer_Disposed);
            videoControl = panel1;
            state = PlayState.Pause;
            //GC.SuppressFinalize(this);
        }

        private Control videoControl;

        public Control VideoControl 
        {
            get { return videoControl; }
            set { videoControl = value; }
        }

        public new Form ParentForm { get; set; }


        void VideoPlayer_Disposed(object sender, EventArgs e)
        {
            //GC.ReRegisterForFinalize(this);
            AppConfig.SuspendForceGC = false;
        }

        public string Filename { get; set; }
        PlayerForm pf = new PlayerForm();
        //private Video theVideo;

        private void VideoPlayer_Load(object sender, EventArgs e)
        {
            //Thread init = new Thread(InitInBG);
            //init.Start();
            pictureBoxLoading.Visible = false;
            panel1.Visible = true;

            //pf.Show ();
        }

        public void Init()
        {
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.BackgroundImage = ImageHelper.LoadFromFile(Filename + ".png");
            pf.filename = Filename;
            pf.Surface = panel1;
            pf.parent = this.ParentForm;
            pf.progressBar = rembyProgressBar1;
            pf.progressLabel = label1;
            pf.endReached += new PlayerForm.endReachedDelegate(pf_endReached);
            pf.onVideoError += new PlayerForm.videoErrorDelegate(pf_onVideoError);
            label1.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", 0, 0, 0);

            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
        }

        void pf_onVideoError(string text)
        {
            DebugHelper.Error(text);
            if (OnVideoError != null)
                OnVideoError();
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pf.Stop();
            
        }

        void pf_endReached()
        {
            state = PlayState.Pause;
            buttonPlayPause1.Image = RembyClipper2.NewDesign.video_btn_play;
            //buttonPlayPause1.State = ButtonPlayPause.PlayState.Play;
        }

        private void InitInBG()
        {
            
            ParentForm.Invoke((MethodInvoker)delegate
            {
            });
        }

        //bool stopped = false;
        private void buttonPlayPause1_Click(object sender, EventArgs e)
        {
            DebugHelper.Log(state.ToString());
            try
            {
                switch (state)
                {
                    case PlayState.Pause:
                        pf.Start();
                        buttonPlayPause1.Image = RembyClipper2.NewDesign.video_btn_pause;
                        state = PlayState.Play;
                        break;
                    default:
                        pf.Pause();
                        buttonPlayPause1.Image = RembyClipper2.NewDesign.video_btn_play;
                        state = PlayState.Pause;
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void rembyProgressBar1_MouseClick(object sender, MouseEventArgs e)
        {
            //e.x ... y??
            /*double seekTime = (e.X * theVideo.Duration)/rembyProgressBar1.Size.Width;
            theVideo.CurrentPosition = seekTime;
            timerLength_Tick(sender, e);*/
            /*double seekTime = (e.X * pf.Length) / rembyProgressBar1.Size.Width;
            
            bool restart = false;
            if (pf.PlayerState == PlayerForm.VideoState.Playing)
                restart = true;

            if (pf.PlayerState == PlayerForm.VideoState.Stopped)
                pf.Start();

            pf.Pause();
            pf.Progress = seekTime;

            if (restart)
                pf.Start();*/
        }

        private void rembyProgressBar1_onProgressChange(int changeTo)
        {
            pf.Progress = pf.Length * changeTo / 100;
        }

        
    }
}
