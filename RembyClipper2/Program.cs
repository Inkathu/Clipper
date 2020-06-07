using System;
using System.Collections.Generic;

using System.Windows.Forms;
using Localization;
using RembyClipper2.Base;
using RembyClipper2.Config;
using System.Diagnostics;
using RembyClipper2.Forms;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Properties;
using RembyClipper2.Utils;
using RembyClipper2.Utils.DragAndDrop;
using RembyClipper2.Utils.Meesenger;

namespace RembyClipper2
{
    static class Program
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static bool HasPriorInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();
            string fileName = currentProcess.StartInfo.FileName;
            foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (process.Id == currentProcess.Id) { continue; }
                if (process.StartInfo.FileName != fileName) { continue; }
                if (process.Responding == false) { process.Kill(); continue; }
                SetForegroundWindow(process.MainWindowHandle);
                return true;
            }
            return false;
        }
        
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            if (!HasPriorInstance())
            {
                if (Settings.Default.LastLanguage.HasValue())
                {
                    Language lng = (Language)Enum.Parse(typeof (Language), Settings.Default.LastLanguage);
                    LanguageMgr.LM.SetDefaultLanguage(lng);
                }
                
                //Debugger.Break();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                //object o = new RembyEditingForm();
                //Application.Run(new Forms.Form1());
                InfoBoxDispatcher.InitAllWindows();
                //Forms.Form1 frm = new Forms.Form1();
                //frm.Show();

                RembyMessenger.Show();
                Application.Run(new TopNav());
            }
        }



        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

       

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            //if (AppConfig.Instance.ClearPasswordOnExit)
            //{
            //    AppConfig.Instance.Username = "";
            //    AppConfig.Instance.Password = "";
            //}
            //AppConfig.Instance.Store();
            //RembyMessenger.Close();
     
        }
    }
}
