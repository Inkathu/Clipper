using System;
using System.Collections.Generic;
using System.Linq;
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

namespace RembyClipper2.VideoEngine
{
    
    public class CameraControl : IDisposable
    {
        CamCapture cam;
        Timer drawTimer = new Timer();

        private Control _surface;
        
        public bool InitCam(Control surface)
        {
            if (!CameraControl.IsCamAttached())
                return false;
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

                var c = cam.SelectDevice(AppConfig.Instance.CaptureDevice);

                CamMetrics cm = new CamMetrics();
                cm.Height = AppConfig.Instance.CaptureHeight;
                cm.Width = AppConfig.Instance.CaptureWidth;
                cm.Fps = AppConfig.Instance.CaptureFPS;

                if (!cam.SelectMetrics(cm))
                {
                    DebugHelper.Log("Metric not selected");
                    return false;
                }

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
            cam.Stop();
            drawTimer.Stop();
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
                            ng.DrawImage(bmp, 0, 0, _surface.Width, _surface.Height);

                        np.RotateFlip(RotateFlipType.Rotate180FlipX);

                        g.DrawImage(np, 0, 0);

                        bmp.Dispose();
                        np.Dispose();
                    }
                }
                catch (Exception ee)
                {
                    DebugHelper.Error(ee.ToString());
                }
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (cam == null)
                return;
            cam.Dispose();
            drawTimer.Dispose();
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
            if (t == null || t.Count() == 0)
                return false;
            else
                return true;
        }
    }
}
