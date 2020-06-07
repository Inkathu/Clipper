using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using ManagedWinapi.Windows;
using RembyClipper2.Base;
using System.Windows.Forms;
using RembyClipper2.VideoEngine;
using System.Runtime.InteropServices;
using RembyClipper2.Config;

namespace RembyClipper2.Helpers
{
    public enum GrabScreenSource { Screenshot, Screenvideo };

    public static class GrabScreen
    {
        public static Image Snap(Rectangle _Bounds, bool includeWM, GrabScreenSource gss)
        {
            return Snap(_Bounds, includeWM, null, gss); 
        }

        public static Image Snap(Rectangle _Bounds, bool includeWM, CameraControl cc, GrabScreenSource gss)
        {
            if (_Bounds.Width == 0 && _Bounds.Height == 0)
                _Bounds = CaptureForm.GetScreenBounds();
            
            System.Drawing.Bitmap X = new System.Drawing.Bitmap(_Bounds.Width, _Bounds.Height, PixelFormat.Format24bppRgb);
            using (System.Drawing.Graphics G = System.Drawing.Graphics.FromImage(X))
            {
                G.CopyFromScreen(_Bounds.Location, new System.Drawing.Point(), _Bounds.Size);

                if (includeWM)
                {
                    if (AppConfig.subscriptions["watermark_screenshot"] == "0" && gss == GrabScreenSource.Screenshot)
                        includeWM = false;

                    if (AppConfig.subscriptions["watermark_screenvideo"] == "0" && gss == GrabScreenSource.Screenvideo)
                        includeWM = false;
                }

                if (_Bounds.Width * _Bounds.Height < 320 * 240 && _Bounds.Width < 400)
                    includeWM = false;

                if (includeWM)
                {
                    G.DrawImage(global::RembyClipper2.Properties.Resources.remby_logo_book_text_v1, _Bounds.Width - 125, _Bounds.Height - 50);
                    //G.FillRectangle(new SolidBrush(Color.FromArgb(128,Color.White)), 0, 0, 230, 18);
                    //G.DrawString("Remby Clipper evalutation, www.remby .com", new Font("Tahoma", 8), new SolidBrush(Color.FromArgb(197, Color.Black)), 0, 0);
                    
                }
                if (cc != null && cc.LastFrame != null)
                {
                    if (_Bounds.Contains(cc.Surface.Bounds))
                    {
                        Point point = new Point();
                        point.X = Math.Abs(_Bounds.X - cc.Surface.Location.X);
                        point.Y = Math.Abs(_Bounds.Y - cc.Surface.Location.Y);
                        G.DrawImage(cc.LastFrame, point);
                    }
                }
                //draw cursor
                Point location = new Point(Cursor.Position.X - _Bounds.Left, Cursor.Position.Y - _Bounds.Top);
                Cursor current = Cursors.Arrow;
                Rectangle cursorBounds = new Rectangle(location, current.Size);
                
                current.Draw(G, cursorBounds);
                //Point p = new Point(Cursor.Position.X - _Bounds.Location.X, Cursor.Position.Y - _Bounds.Location.Y);
                //System.Drawing.Rectangle CurBounds = new System.Drawing.Rectangle(p, System.Windows.Forms.Cursor.Current.Size);
                //Cursors.Default.Draw(G, CurBounds);
            }
            return X;
        }

        public static Bitmap GetDesktopImage()
        {
            WIN32_API.SIZE size;

            IntPtr hDC = WIN32_API.GetDC(WIN32_API.GetDesktopWindow());
            IntPtr hMemDC = WIN32_API.CreateCompatibleDC(hDC);

            size.cx = WIN32_API.GetSystemMetrics(WIN32_API.SM_CXSCREEN);
            size.cy = WIN32_API.GetSystemMetrics(WIN32_API.SM_CYSCREEN);

            var m_HBitmap = WIN32_API.CreateCompatibleBitmap(hDC, size.cx, size.cy);

            if (m_HBitmap != IntPtr.Zero)
            {
                IntPtr hOld = (IntPtr)WIN32_API.SelectObject(hMemDC, m_HBitmap);
                WIN32_API.BitBlt(hMemDC, 0, 0, size.cx, size.cy, hDC, 0, 0, WIN32_API.SRCCOPY);
                WIN32_API.SelectObject(hMemDC, hOld);
                WIN32_API.DeleteDC(hMemDC);
                WIN32_API.ReleaseDC(WIN32_API.GetDesktopWindow(), hDC);
                return System.Drawing.Image.FromHbitmap(m_HBitmap);
            }
            return null;
        }

        

    }

    public class WIN32_API
    {
        public struct SIZE
        {
            public int cx;
            public int cy;
        }

        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 SWP_SHOWWINDOW = 0x0040;
        private const UInt32 SWP_HIDEWINDOW = 0x0080;
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private static readonly IntPtr HWND_TOP = new IntPtr(0);
        public const int SRCCOPY = 13369376;
        public const int SM_CXSCREEN = 0;
        public const int SM_CYSCREEN = 1;
        //c po sur elle marche po xD
        public const int WM_GETTEXT = 0x000D;


        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern IntPtr DeleteDC(IntPtr hDc);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern IntPtr DeleteObject(IntPtr hDc);

        [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
        public static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, int RasterOp);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int abc);

        [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
        public static extern IntPtr GetWindowDC(Int32 ptr);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy,
                                               uint uFlags);


        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowText(IntPtr hWnd, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nMaxCount);

        [DllImport("user32")]
        private static extern UInt32 GetWindowThreadProcessId(
          Int32 hWnd,
          out Int32 lpdwProcessId
        );

        public static void MakeWindowTopMost(IntPtr hWnd)
        {
            SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }

        public static void ResetWindowTopMost(IntPtr hWnd)
        {
            SetWindowPos(hWnd, HWND_TOP, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_HIDEWINDOW);
            SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
    
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, StringBuilder lParam);
        public static Int32 GetWindowProcessID(Int32 hwnd)
        {
            Int32 pid = 0;
            GetWindowThreadProcessId(hwnd, out pid);
            return pid;
        }

        public const Int32 CURSOR_SHOWING = 0x00000001;
        [StructLayout(LayoutKind.Sequential)]
        public struct ICONINFO
        {
            public bool fIcon;         // Specifies whether this structure defines an icon or a cursor. A value of TRUE specifies 
            public Int32 xHotspot;     // Specifies the x-coordinate of a cursor's hot spot. If this structure defines an icon, the hot 
            public Int32 yHotspot;     // Specifies the y-coordinate of the cursor's hot spot. If this structure defines an icon, the hot 
            public IntPtr hbmMask;     // (HBITMAP) Specifies the icon bitmask bitmap. If this structure defines a black and white icon, 
            public IntPtr hbmColor;    // (HBITMAP) Handle to the icon color bitmap. This member can be optional if this 
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct CURSORINFO
        {
            public Int32 cbSize;        // Specifies the size, in bytes, of the structure. 
            public Int32 flags;         // Specifies the cursor state. This parameter can be one of the following values:
            public IntPtr hCursor;          // Handle to the cursor. 
            public POINT ptScreenPos;       // A POINT structure that receives the screen coordinates of the cursor. 
        }


        [DllImport("user32.dll", EntryPoint = "GetCursorInfo")]
        public static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll", EntryPoint = "CopyIcon")]
        public static extern IntPtr CopyIcon(IntPtr hIcon);

        [DllImport("user32.dll", EntryPoint = "GetIconInfo")]
        public static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);

        public static IntPtr GetCurrentCursorHandle()
        {
            IntPtr result = IntPtr.Zero;

            CURSORINFO ci = new CURSORINFO();
            ci.cbSize = Marshal.SizeOf(ci);

            if (GetCursorInfo(out ci))
            {
                result = ci.hCursor;
            }

            return result;
        }
        static Dictionary<IntPtr, Cursor> _cursoprsPool = new Dictionary<IntPtr, Cursor>();
        public static Cursor GetCurrentCursor()
        {
            IntPtr ch = GetCurrentCursorHandle();
            Cursor result = Cursors.Default;
            if(ch != IntPtr.Zero)
            {
                if (_cursoprsPool.ContainsKey(ch))
                {
                    result = _cursoprsPool[ch];
                }
                else
                {
                    result = new Cursor(ch);
                    _cursoprsPool.Add(ch, result);
                }
            }

            return result;
        }


        
    }

    
}
