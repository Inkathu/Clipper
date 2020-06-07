using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace RembyClipper.Helpers
{
    public class MCIPlayer
    {

        private  string Pcommand;
        public  bool isOpen;
        public string filepath;
        public  string fileName;
        public  bool paused;
        StringBuilder sb;

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand,  StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public MCIPlayer()
        {
            sb = new StringBuilder();
        }

        public  void Close()
        {
            Pcommand = "close " + fileName + "";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = false;
            paused = false;
        }


        public  void Open(string sFileName, string mediafilename)
        {
            fileName = mediafilename;
            filepath = sFileName;
            Pcommand = "open \"" + sFileName + "\" type mpegvideo alias " + fileName + "";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = true;
            paused = false;
        }

        public string Status()
        {
            
            Pcommand = "status " + fileName + " mode";

            mciSendString(Pcommand,  sb, sb.Capacity, IntPtr.Zero);

            return sb.ToString();
        }

        public  void Play(bool loop)
        {
            string status = Status();
            if (isOpen && status == "paused")
            {
                Pcommand = "resume " + fileName + "";
                
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
                paused = false;

            }
            else if (isOpen && status == "playing" )
            {
                Pcommand = "pause " + fileName + "";
                
                mciSendString(Pcommand,  null, 0, IntPtr.Zero);

            }
            else if (isOpen && Status() == "stopped")
            {
                Close();
                Open(filepath, fileName);

                Pcommand = "play " + fileName + "";

                mciSendString(Pcommand, null, 0, IntPtr.Zero);
            }
        }


        public int Duration()
        {
            int ReturnSeconds;
            Pcommand = "status " + fileName + " length";
            mciSendString(Pcommand, sb, 128, IntPtr.Zero);

            ReturnSeconds = int.Parse(sb.ToString());
            ReturnSeconds = ReturnSeconds / 1000;
            return ReturnSeconds;
        }

        public int Position
        {
            set
            {
                int seconds = value;
                seconds = seconds * 1000;
                Pcommand = "play " + fileName + " from " + seconds.ToString();
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
            }

            get
            {
                Pcommand = "status " + fileName + " position";
                mciSendString(Pcommand, sb, sb.Capacity, IntPtr.Zero);

                int seconds = int.Parse(sb.ToString());
                seconds = seconds / 1000;
                return seconds;
            }
        }

        public int Volume
        {
            get
            {
                if (Status() != "")
                {
                    mciSendString("status "+fileName+" volume", sb, sb.Capacity, IntPtr.Zero);
                    return int.Parse(sb.ToString());
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (value > 1000)
                    value = 1000;
                if (value < 0)
                    value = 0;
                if (value <= 1000)
                {
                    mciSendString("setaudio "+fileName+" volume to " + value.ToString(), null, 0, IntPtr.Zero);
                }
                
            }
        }
        public  void Pause()
        {
            if (isOpen && ( paused == false))
            {
                paused = true;
                Pcommand = "pause " + fileName + "";


                mciSendString(Pcommand,  null, 0, IntPtr.Zero);
            }
        }

        


    }

}
