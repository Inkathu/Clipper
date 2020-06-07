#define hotkeys
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using RembyClipper2.Base;
using RembyClipper2.Config;
using RembyClipper.Helpers;
using RembyClipper2.Forms;
using System.Media;
using RembyClipper2.Helpers;

namespace RembyClipper2.HotKeys
{
    public static class HotKeysHandler
    {
        delegate void registerKeysDelegate();

        private static List<Hotkey> Hotkeys = new List<Hotkey>();

//        struct MSG
//        {
//            IntPtr hwnd;
//            uint message;
//            IntPtr wParam;
//            IntPtr lParam;
//            int time;
//            int ptX;
//            int ptY;
//        }

        [DllImport("User32.dll")]
        extern static bool PeekMessage(out Message Msg, uint hWnd, uint
        wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

        const uint PM_REMOVE = 1;

        public static void ClearMessages()
        {
            Message msg;
            while (PeekMessage(out msg, 0, 0, 0, PM_REMOVE)) ;
        }

        public static void RegisterAllHotkeys()
        {
#if hotkeys
            if (AppConfig.topnav.InvokeRequired)
            {
                registerKeysDelegate d = new registerKeysDelegate(RegisterAllHotkeys);
                AppConfig.topnav.BeginInvoke(d);
            }
            else
            {
                Hotkey tmp = new Hotkey(Keys.S, true, true, false, false);
                tmp.Pressed += delegate
                                   {
                                       AppConfig.topnav.BeginInvoke((MethodInvoker)(() => AppConfig.topnav.hideTopNavContextMenu()));
                                       AppConfig.topnav.BeginInvoke((MethodInvoker)(() => AppConfig.topnav.pictureBoxPhoto_Click(null, null)));
                                   };
                Hotkeys.Add(tmp);

                tmp = new Hotkey(Keys.V, true, true, false, false);
                 
                tmp.Pressed += delegate { AppConfig.topnav.hideTopNavContextMenu(); AppConfig.topnav.pictureBoxVideo_Click(null, null); };
                Hotkeys.Add(tmp);
//
//                tmp = new Hotkey(Keys.S, true, true, true, false);
//                tmp.Pressed += delegate { AppConfig.topnav.hideTopNavContextMenu(); AppConfig.topnav.captureFullScreen(); };
//                Hotkeys.Add(tmp);
//
                //tmp = new Hotkey(Keys.T, true, true, false, false);
                //tmp.Pressed += delegate { AppConfig.topnav.hideTopNavContextMenu(); AppConfig.topnav.tetToolStripMenuItem_Click(null, null); };
                //Hotkeys.Add(tmp);

                tmp = new Hotkey(Keys.O, true, true, true, false);
                tmp.Pressed += delegate { DebugHelper.PropertyDump(AppConfig.Instance); SystemSounds.Beep.Play(); };
                Hotkeys.Add(tmp);

                tmp = new Hotkey(Keys.R, false, true, true, false);
                tmp.Pressed += delegate { AppConfig.IsEditorEnabled = !AppConfig.IsEditorEnabled; SystemSounds.Beep.Play(); };
                Hotkeys.Add(tmp);

                /*tmp = new Hotkey(Keys.L, false, true, true, false);
                tmp.Pressed += delegate { Web.WebLogin w = new Web.WebLogin(); };
                Hotkeys.Add(tmp);*/

                foreach (Hotkey t in Hotkeys)
                    if (t.GetCanRegister(AppConfig.topnav))
                        t.Register(AppConfig.topnav);
                    else
                        DebugHelper.Log(t.ToString() + " failed to register");
            }
#endif
        }

        public static void UnregisterAllHotkeys()
        {
#if hotkeys
            foreach (Hotkey t in Hotkeys)
            {
                DebugHelper.Log("Unregistering " + t.ToString());
                if (t.Registered)
                    t.Unregister();
            }
#endif
        }
    }
}
