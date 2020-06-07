using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using StreamCoders.Devices;
using System.Drawing;
using RembyClipper2.Config;
using RembyClipper.Helpers;
using SmartAssembly.Attributes;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace RembyClipper2.VideoEngine
{
    
    public class CameraControl : IDisposable
    {
        CamCapture cam;
        Timer drawTimer = new Timer();

        public enum CamState { On, Off, Unavailable, Disposed };

        public CamState State { get; set; }

        private Control _surface;

        public bool InitCam(Control surface)
        {
            bool b = _InitCam(surface);
            if (b)
                State = CamState.On;
            else
                State = CamState.Unavailable;
            return b;
        }
        
        private bool _InitCam(Control surface)
        {
            if (!CameraControl.IsCamAttached())
            {
                return false;
            }
            try
            {
                cam = new CamCapture();

                _surface = surface;

                drawTimer.Interval = 50;
                drawTimer.Tick += new EventHandler(drawTimer_Tick);

                if (AppConfig.Instance.CaptureDevice == "")
                {
                    var list = cam.GetDeviceList();
                    if (list.Count == 0)
                        return false;

                    AppConfig.Instance.CaptureDevice = list[0];
                    AppConfig.Instance.Store();
                }

                DebugHelper.Log("Is the selected cam attached?");
                List<string> captureDevices = new List<string>(CameraControl.GetCameras());

                if (!captureDevices.Contains(AppConfig.Instance.CaptureDevice))
                {
                    AppConfig.Instance.CaptureDevice = captureDevices[0];
                }

                var c = cam.SelectDevice(AppConfig.Instance.CaptureDevice);

                CamMetrics cm = new CamMetrics();
                cm.Height = AppConfig.Instance.CaptureHeight;
                cm.Width = AppConfig.Instance.CaptureWidth;
                cm.Fps = AppConfig.Instance.CaptureFPS;

                if (!cam.SelectMetrics(cm))
                {
                    DebugHelper.Log("Metric not selected, trying to recover");
                    if (c == null || c.Count == 0)
                    {
                        DebugHelper.Log("Trying to start video with very basic settings");
                        cm.Width = 320;
                        cm.Height = 240;
                        cm.Fps = 15;
                        if (!cam.SelectMetrics(cm))
                        {
                            DebugHelper.Log("Metric not selected");
                            return false;
                        }
                    }
                    else if (c.Count != 0 && c[0] != null)
                    {
                        cm = c[0];
                        AppConfig.Instance.CaptureFPS = (int)cm.Fps;
                        AppConfig.Instance.CaptureHeight = cm.Height;
                        AppConfig.Instance.CaptureWidth = cm.Width;
                        if (!cam.SelectMetrics(cm))
                        {
                            DebugHelper.Log("Metric not selected");
                            return false;
                        }
                    }
                    else
                        return false;
                }

                DebugHelper.Log("Metrics: " + cm.Width.ToString() + "x" + cm.Height.ToString() + "@" + cm.Fps.ToString());

                if (cam.Start())
                {
                    DebugHelper.Log("Cam started");
                    drawTimer.Enabled = true;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                DebugHelper.Error(e.ToString());
                return false;
            }
        }

        public void StopCam()
        {
            if (cam == null)
                return;
            if (State == CamState.On)
            {
                cam.Stop();
                drawTimer.Stop();
                State = CamState.Off;
                this.LastFrame = null;
            }
        }

        public void DrawFrame()
        {
            drawTimer_Tick(null, null);
        }

        void drawTimer_Tick(object sender, EventArgs e)
        {
            if (_surface.IsDisposed)
            {
                drawTimer.Enabled = false;
                return;
            }
            if (_surface is IWebCamSurface)
            {
                ((IWebCamSurface)_surface).HideLoading();
            }
            using (Graphics g = _surface.CreateGraphics())
            {
                try
                {
                    byte[] f = cam.GetFrame();
                    if (f == null)
                        return;

                    lock (f)
                    {

                        Bitmap bmp = new Bitmap(cam.Metrics.Width, cam.Metrics.Height, PixelFormat.Format24bppRgb);

                        //Create a BitmapData and Lock all pixels to be written 
                        BitmapData bmpData = bmp.LockBits(
                                             new Rectangle(0, 0, bmp.Width, bmp.Height),
                                             ImageLockMode.WriteOnly, bmp.PixelFormat);
                   
                        //Copy the data from the byte array into BitmapData.Scan0
                        Marshal.Copy(f, 0, bmpData.Scan0, f.Length);


                        //Unlock the pixels
                        bmp.UnlockBits(bmpData);


                        Bitmap np = new Bitmap(_surface.Size.Width, _surface.Height);
                        using (Graphics ng = Graphics.FromImage((Image)np))
                        {
                            
                            ng.DrawImage(bmp, 0, 0, _surface.Width, _surface.Height);
                            DrawRoundRect(ng, new Pen(Color.FromArgb(127,237, 84, 00)), 0, 0, _surface.Width - 1, _surface.Height - 1, 2);
                        }
                        np.RotateFlip(RotateFlipType.Rotate180FlipX);

                        

                        g.DrawImage(np, 0, 0);
                       
                        LastFrame = (Bitmap)np.Clone();
                        np.Dispose();
                        bmp.Dispose();
                    }
                }
                catch (Exception ee)
                {
                    DebugHelper.Error(ee.ToString());
                }
            }
        }

        public void DrawRoundRect(Graphics g, Pen p, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
            gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
            gp.CloseFigure();

            g.DrawPath(p, gp);
            gp.Dispose();
        }

        public Bitmap LastFrame { get; private set; }
        public Control Surface { get { return _surface; } }

        #region IDisposable Members

        public void Dispose()
        {
            if (cam == null)
                return;
            if (State != CamState.Disposed)
            {
                cam.Dispose();
                drawTimer.Dispose();
                State = CamState.Disposed;
            }
        }

        #endregion

        public static string[] GetCameras()
        {
            CamCapture cc = new CamCapture();
            var tmp = cc.GetDeviceList();
            cc.Dispose();
            if (tmp == null)
                return null;
            return tmp.ToArray();
        }

        public static bool IsCamAttached()
        {
            string[] t = CameraControl.GetCameras();
            if (t == null || t.Length == 0)
                return false;
            else
                return true;
        }
    }
}
