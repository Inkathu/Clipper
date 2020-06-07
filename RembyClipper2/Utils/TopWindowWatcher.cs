using System;
using System.Windows.Forms;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Helpers;

namespace RembyClipper2.Utils
{
    public class TopWindowWatcher
    {
        private IntPtr _mainWnd;
        private IntPtr _messageWnd;
        private DateTime _lastCall;

        public TopWindowWatcher(IntPtr mainWnd, IntPtr messageWnd)
        {
            _lastCall = DateTime.Now;
            this._mainWnd = mainWnd;
            this._messageWnd = messageWnd;
        }

        public void Start()
        {
            AppConfig.topnav.ServiceTimerTick += new System.Action(topnav_ServiceTimerTick);
        }


        public void Stop()
        {
            AppConfig.topnav.ServiceTimerTick += new System.Action(topnav_ServiceTimerTick);
        }

        void topnav_ServiceTimerTick()
        {
            DateTime callTime = DateTime.Now;

            if((callTime-_lastCall) > TimeSpan.FromMinutes(3))
            {
                
                //ResetTopMost();
                DebugHelper.Log("[TopWindowWatcher] : topnav_ServiceTimerTick - it looks like pc is raising up from sleep or hibernate. To avoid auth problems, just restart it.");
                Application.Restart();
            }
            _lastCall = callTime;

        }

        private void ResetTopMost()
        {
            if (_mainWnd != IntPtr.Zero)
            {
                WIN32_API.ResetWindowTopMost(_mainWnd);
            }
            if(_messageWnd != IntPtr.Zero)
            {
                WIN32_API.ResetWindowTopMost(_messageWnd);
            }
        }
    }
}