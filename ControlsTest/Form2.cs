using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using StreamCoders;
using StreamCoders.Decoder;
using StreamCoders.Reader;

namespace ControlsTest
{
    public partial class Form2 : Form
    {
        private bool isRunning;
        private H264Decoder videoDecoder;
        private Bitmap dImage;
        private Rectangle dImageRect;
        private Graphics pictureGraphics;
        private Thread videoThread;
        private decimal picturesDisplayed = 0;
        private MP4Reader reader;
        public Form2()
        {
            InitializeComponent();
            isRunning = false;
        }

        private void CreateVideoDecoder()
        {
            reader = new MP4Reader();
            reader.FileName = textBox1.Text;
            reader.Init();

            videoDecoder = new H264Decoder();
            videoDecoder.SetInputFrameRate(10);
            videoDecoder.SetInputResolution(176, 144);
            videoDecoder.VideoSource = StreamSources.FILE_MP4;
            bool res = videoDecoder.Init();
            if (res == false)
            {
                MessageBox.Show("Unable to initialize decoder.");
                return;
            }
        }

        private void DeleteVideoDecoder()
        {

            H264Decoder h264 = (H264Decoder)videoDecoder;
            h264.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateVideoDecoder();


            dImage = new Bitmap(videoDecoder.InputWidth, videoDecoder.InputHeight, PixelFormat.Format24bppRgb);
            dImageRect = new Rectangle(0, 0, videoDecoder.InputWidth, videoDecoder.InputHeight);
            pictureGraphics = panel1.CreateGraphics();

            isRunning = true;
            videoThread = new System.Threading.Thread(new System.Threading.ThreadStart(VideoDecoderThread));
            videoThread.Start();
        }

        private void VideoDecoderThread()
        {
            int iterations = 1;
            while (isRunning)
            {
                iterations++;

               System.Threading.Thread.Sleep(0);

                var mediaPackage = reader.GetNextFrame(0);

                mediaPackage = videoDecoder.Decode(mediaPackage);
                if (mediaPackage == null)
                    continue;
                iterations++;
                //MediaPackage mp = new MediaPackage();
                //mp.Buffer = pic;
                DisplayPicture(mediaPackage);
            }
        }

        private void ShutdownThread()
        {
            isRunning = false;
            videoThread.Join();
            Application.Exit();
        }

        private void DisplayPicture(MediaPackage mp)
        {
            if (isRunning == false)
                return;
            var picData = dImage.LockBits(dImageRect, ImageLockMode.ReadWrite, dImage.PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(mp.Buffer, 0, picData.Scan0, mp.Buffer.Length);
            dImage.UnlockBits(picData);
            picturesDisplayed++;
            this.Invoke((MethodInvoker)delegate
            {
                pictureGraphics.DrawImage(dImage, 0, 0, panel1.Width, panel1.Height);
            });
        }
    }
}
