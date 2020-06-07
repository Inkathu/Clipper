using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using RembyClipper.Helpers;
using RembyClipper2.Utils;

namespace RembyClipper2.Helpers
{
    public static class SOLHelper
    {

        public static string AssemblyVersion
        {
            get
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    Version version = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                    return version.ToString();
                }
                else
                    return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static void Write()
        {
            try
            {
                List<byte> dataToWrite = new List<byte>();
                byte[] staticHeader = new byte[] { 0x00, 0xBF, 0x00, 0x00, 0x00, 0x43, 0x54, 0x43, 0x53, 0x4F, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00 };
                byte[] rootSOName = new byte[] { 0x00, 0x05, 0x72, 0x65, 0x6D, 0x62, 0x79 }; //length + remby
                byte[] padding = new byte[] { 0x00, 0x00, 0x00, 0x00 };

                dataToWrite.AddRange(staticHeader);
                dataToWrite.AddRange(rootSOName);
                dataToWrite.AddRange(padding);

                string var = "Version";
                byte[] var_header_length = new byte[] { 0x00, (byte)var.Length };
                byte[] var_header_content = Encoding.ASCII.GetBytes(var);
                byte[] var_header_end = new byte[] { 0x00 };

                dataToWrite.AddRange(var_header_length);
                dataToWrite.AddRange(var_header_content);
                //dataToWrite.AddRange(var_header_end);

                byte[] var_data_type = new byte[] { 0x02 };
                byte[] var_data_length = new byte[] { 0x00, (byte)SOLHelper.AssemblyVersion.Length };
                byte[] var_data_content = Encoding.ASCII.GetBytes(SOLHelper.AssemblyVersion);
                byte[] var_data_end = new byte[] { 0x00 };

                dataToWrite.AddRange(var_data_type);
                dataToWrite.AddRange(var_data_length);
                dataToWrite.AddRange(var_data_content);
                dataToWrite.AddRange(var_data_end);

                var = "LastUsed";
                var_header_length = new byte[] { 0x00, (byte)var.Length };
                var_header_content = Encoding.ASCII.GetBytes(var);
                var_header_end = new byte[] { 0x00 };

                dataToWrite.AddRange(var_header_length);
                dataToWrite.AddRange(var_header_content);
                //dataToWrite.AddRange(var_header_end);

                var_data_type = new byte[] { 0x02 };
                var_data_length = new byte[] { 0x00, (byte)SOLHelper.unixTime().Length };
                var_data_content = Encoding.ASCII.GetBytes(SOLHelper.unixTime());
                var_data_end = new byte[] { 0x00 };

                dataToWrite.AddRange(var_data_type);
                dataToWrite.AddRange(var_data_length);
                dataToWrite.AddRange(var_data_content);
                dataToWrite.AddRange(var_data_end);

                dataToWrite[5] = (byte)(dataToWrite.Count - 6);


                //C:\Users\Tomi\AppData\Roaming\Macromedia\Flash Player\#SharedObjects\URKHFA56\staging.remby.com
                string location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Macromedia\Flash Player\#SharedObjects");
                DirectoryInfo dir = new DirectoryInfo(location);
                if (!dir.Exists)
                {
                    DebugHelper.Log("Flash not installed");
                    return;
                }
                DirectoryInfo[] directories = dir.GetDirectories();
                DirectoryInfo di;
                if(directories.Length > 0)
                {
                    di = new DirectoryInfo(directories[0].FullName + @"\" + RembyConstants.RembyFlashCookieName);
                    if (!di.Exists)
                        di.Create();
                    using (StreamWriter sw = new StreamWriter(di.FullName + @"\remby.sol", false))
                    {
                        BinaryWriter bw = new BinaryWriter(sw.BaseStream);
                        bw.Write(dataToWrite.ToArray());
                    }

                    DebugHelper.Log("Flash cookie written");
                    
                }


            }
            catch (Exception e)
            {
                DebugHelper.Error(e.ToString());
            }
        }

        private static string unixTime()
        {
            TimeSpan span = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return Math.Round(span.TotalSeconds).ToString();
        }
    }
}
