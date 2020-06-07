using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace RembyUninstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();

            if (Environment.CommandLine.Contains("registry"))
            {
                try
                {
                    string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "RembyClipper2.exe");
                    if (!File.Exists(iconSourcePath))
                        return;

                    RegistryKey myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    for (int i = 0; i < mySubKeyNames.Length; i++)
                    {
                        RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                        object myValue = myKey.GetValue("DisplayName");
                        if (myValue != null && myValue.ToString() == "Remby Clipper")
                        {
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                        }

                        object uninstallValue = myKey.GetValue("UninstallString");
                        if (uninstallValue != null)
                        {
                            using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),@"RembyClipper\uninstall.bat"), false))
                                sw.WriteLine(uninstallValue.ToString());
                            myKey.SetValue("UninstallString", Environment.CurrentDirectory + @"\RembyUninstaller.exe");
                            break;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }

            else
            {
                try
                {
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "RembyClipper2.lnk"))
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "RembyClipper2.lnk");



                    DirectoryInfo di = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"RembyClipper"));
                    foreach (FileInfo fi in di.GetFiles("*.dat"))
                        fi.Delete();

                    foreach (DirectoryInfo dii in di.GetDirectories())
                        di.Delete(true);

                    Application.Exit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Process t = new Process();
                    t.StartInfo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"RembyClipper\uninstall.bat");
                    t.Start();
                }
            }

            Application.Exit();
        }
    }
}
/*

*/