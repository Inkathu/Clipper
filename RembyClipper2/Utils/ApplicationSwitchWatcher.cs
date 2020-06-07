using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using RembyClipper2.Config;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Helpers;
using RembyClipper2.Utils;

namespace RembyClipper2.Utils
{
    /// <summary>
    /// Need to watch for foreground applications
    /// to get latest active(except the current one)
    /// </summary>
    internal class ApplicationSwitchWatcher
    {
        public List<string> _specialApps = new List<string>()
                                               {
                                                   "safari"
                                               };
        public event Action<string> ApplicationChanged;
        private readonly object _lastAppLocker = new object();

        private IntPtr _lastAppHandle;
        private IntPtr _mainHandle;
        private int _mainProcessId;
        public string LastAppTitle
        {
            get
            {

                string result = "";
                string appName = "";
                if (_lastAppHandle != IntPtr.Zero)
                {
                    lock (_lastAppLocker)
                    {
                        StringBuilder builder = new StringBuilder(512);
                        int processId = WIN32_API.GetWindowProcessID(_lastAppHandle.ToInt32());
                        Process p = Process.GetProcessById(processId);
                        appName = p.ProcessName;
                        int charCount = WIN32_API.GetWindowText(_lastAppHandle, builder, 512);
                        if (charCount > 0)
                        {

                            result = builder.ToString();
                        }
                    }

                }
                if (_specialApps.Contains(appName))
                {
                    result += " - " + appName.ToTitleCase();
                }
                return result;
            }
        }

        public string LastProcessName
        {
            get 
            { 
                string res = "";
                if (_lastAppHandle != IntPtr.Zero)
                {
                    lock (_lastAppLocker)
                    {
                        int processId = WIN32_API.GetWindowProcessID(_lastAppHandle.ToInt32());
                        Process p = Process.GetProcessById(processId);
                        res = p.ProcessName;
                    }
                }
                return res;
            }
        }

        public IntPtr LastAppHandle
        {
            get { return _lastAppHandle; }
        }

        public ApplicationSwitchWatcher(IntPtr mainHandle)
        {
            _mainHandle = mainHandle;
            _mainProcessId = WIN32_API.GetWindowProcessID(_mainHandle.ToInt32());
            
        }

        public void Start()
        {
            AppConfig.topnav.ServiceTimerTick += topnav_ServiceTimerTick;
        }

        void topnav_ServiceTimerTick()
        {
            IntPtr curHandle = WIN32_API.GetForegroundWindow();
            int curProcess = WIN32_API.GetWindowProcessID(curHandle.ToInt32());
            if (curProcess != _mainProcessId)
            {
                //Always set last 
                bool riseEvent = curHandle == IntPtr.Zero ? false : curHandle != _lastAppHandle;
                lock (_lastAppLocker)
                {

                    _lastAppHandle = curHandle;
                }
                if (riseEvent)
                {
                    OnLastAppChanged();
                }
            }
        }


        public void Stop()
        {
            AppConfig.topnav.ServiceTimerTick -= topnav_ServiceTimerTick;
        }

        private void OnLastAppChanged()
        {
            lock (_lastAppLocker)
            {
                Action<string> eventToRaise = ApplicationChanged;

                if (eventToRaise != null)
                {
                    eventToRaise(LastAppTitle);
                }
            }

        }

    }
}
