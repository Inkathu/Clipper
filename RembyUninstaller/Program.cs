using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.Linq;
using RembyClipperUinstall.Helpers;

namespace RembyUninstaller
{
    static class Program
    {
#if DEBUG
        public const string RembyFlashCookieName = "staging.remby.com";
#else
        public const string RembyFlashCookieName = "remby.com";
#endif
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args.Contains("registry"))
            {
                //Debugger.Break();
                try
                {

                    string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "RembyCollector.exe");
                    if (!File.Exists(iconSourcePath))
                        return;

                    RegistryKey myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    for (int i = 0; i < mySubKeyNames.Length; i++)
                    {
                        RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                        object myValue = myKey.GetValue("DisplayName");
                        if (myValue != null && myValue.ToString() == "RembyCollector")
                        {
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                            object uninstallValue = myKey.GetValue("UninstallString");
                            if (uninstallValue != null)
                            {
                                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"RembyCollector\uninstall.bat"), false))
                                    sw.WriteLine(uninstallValue.ToString());
                                myKey.SetValue("UninstallString", Environment.CurrentDirectory + @"\RembyUninstaller.exe");
                                break;
                            }

                        } 

                    }
                }
                catch (Exception ex)
                {
                    DebugHelper.Log(ex.ToString());
                }
            }

            else
            {
                try
                {
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "RembyCollector.lnk"))
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "RembyCollector.lnk");



                    DirectoryInfo di = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"RembyCollector"));
                    foreach (FileInfo fi in di.GetFiles("*.dat"))
                        fi.Delete();

                    foreach (DirectoryInfo dii in di.GetDirectories())
                        dii.Delete(true);

                    ClearSOLInfo();

                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString() + "\r\n" + (ex.StackTrace != null ? ex.StackTrace : " "));
                }
                finally
                {
                    string cmd = "";
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                               @"RembyCollector\uninstall.bat");
                    if (File.Exists(path))
                    {
                        using (TextReader reader = new StreamReader(path))
                        {
                            cmd = reader.ReadLine();
                        }
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            string app = cmd.Substring(0, cmd.IndexOf(" "));
                            cmd = cmd.Substring(cmd.IndexOf(" ") + 1);
                            Process.Start(app, cmd);
                        }
                        //                    Process t = new Process();
                        //                    t.StartInfo.FileName = "";
                        //                    t.Start();
                    }
                }
            }

            Application.Exit();

//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new Form1());
        }

        private static void ClearSOLInfo()
        {
            string location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Macromedia\Flash Player\#SharedObjects");
            DirectoryInfo dir = new DirectoryInfo(location);
            if (!dir.Exists)
            {
                //Flash not installed - just exit
                return;
            }
            DirectoryInfo di = new DirectoryInfo(dir.GetDirectories()[0].FullName + @"\" + RembyFlashCookieName);
            if (di.Exists)
            {
                //delete flash cookie folder
                di.Delete(true);    
            }
        }
    }
}
