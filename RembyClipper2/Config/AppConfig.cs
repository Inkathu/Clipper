using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Collections;
using System.Security;
using Google.YouTube;
using Localization;
using RembyClipper.Helpers;
using System.Security.Cryptography;
using RembyClipper2.Forms.InformationDialog.FormPlacer;
using RembyClipper2.Helpers;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using RembyClipper2.Utils;
using RembyClipper2.Web;
using SmartAssembly.Attributes;
using RembyClipper2.Base;

namespace RembyClipper2.Config
{

    public class DoNotResetAttribute : Attribute
    { }

    /// <summary>
    /// AppConfig is used for loading and saving the configuration. All public fields
    /// in this class are serialized with the BinaryFormatter and then saved to the
    /// config file. After loading the values from file, SetDefaults iterates over
    /// all public fields an sets fields set to null to the default value.
    /// 
    /// IE Drag n Drop {E8F1619D-C3D2-4055-965C-16FF31CE5A98}
    /// </summary>
    [Serializable]
    [DoNotObfuscate]
    [DoNotEncodeStrings]
    public class AppConfig
    {
        public int version = 7;

#if !DEBUG
        private static string fileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"RembyCollector");
        private static string _filename = "shared.dat";
#else
        private static string fileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"RembyCollector");
        private static string _filename = "shared.dat";
#endif
        private static AppConfig instance = null;
        private static object locker = new object();
        // the configuration part - all public vars are stored in the config file
        // don't use "null" and "0" as default value!

        [DoNotReset()]
        public string Username = "";

        [DoNotReset()]
        public string Password = "";
        [DoNotReset()]
        public string PasswordHash = "";

        [DoNotReset()]
        public bool ClearPasswordOnExit = false;

        
        public LoginResponse LoginResponse { get; set; }

        [DoNotReset()]
        public bool VideoPrivate = false;
        public int VideoFPS = 15;

        public int audioChannels = 1;
        public int audioSampleFreq = 44100;
        public int audioBitrate = 128000;
        public int audioBitsPerSample = 16;

        public bool legacyStorage = false;

        [DoNotReset()]
        public bool VideoFirstTimeExperienceShown = false;

        //public string YouTubeSignUpLink = "http://www.youtube.com";

        public string[] Categories;
        public string[] Terms;

        public bool StaticBackground = true;

        [DoNotReset()]
        public Point TopNavPosition = new Point(510, 0);    

        [DoNotReset()]
        public bool AutoStart = true;

        [DoNotReset()]
        public Color DrawingBorderColor = Color.Red;

        [DoNotReset()]
        public Color DrawingFillrColor = Color.FromArgb(0, Color.White);        
        
        [DoNotReset()]
        public Color FigureFontColor = Color.Red;

        [DoNotReset()]
        public Font FigureFont = new Font("Arial", 18, FontStyle.Bold);

        [DoNotReset()]
        public byte FigureOpacity = 255;
        
        [DoNotReset()]
        public int FigureBorderSize = 5;
        
        [DoNotReset()]
        public string CaptureDevice = "";
        public int CaptureFPS = 15;
        public int CaptureWidth = 320;
        public int CaptureHeight = 240;

        [DoNotReset()]
        public Localization.Language CurrentLanguage = Localization.Language.English;

        public List<string> History = new List<string>();

        [DoNotReset()]
        public bool GettingStartedWizardShown = false;

        [DoNotReset()]
        public bool OneClickScreenShotShown = false;

        public int SecondsBeforeUpload = 5;

        public Place MessageBoxDefaultPlace;

        public string LastUsedTags = "";


        public string[] BannedFileTypes = new string[] { "exe", "com", "bat", "dll", "vbs", "386", "bin", "cmd", "drv", "ini", "ocx", "pif", "pdb", "scr", "sys", "vb", "vba", "vbe", "vbx" };

        public string[] SupportedVideoFiles = new string[] { "avi", "mkv", "mp4", "wmv", "mov", "flv" };

        public static List<string> VideoProviders = new List<string>()
                                                 {
                                                     "youtube",
                                                     "hulu",
                                                     "rutube",
                                                     "vimeo",
                                                 };


        public enum Updates
        {
            EveryDay,
            Never,
            EveryHour,
            EveryWeek
        }

        public readonly TimeSpan PERIOD_10_MIN = new TimeSpan(0, 10, 0);
        public readonly TimeSpan PERIOD_1_HOUR = new TimeSpan(1, 0, 0);
        public readonly TimeSpan PERIOD_1_DAY  = new TimeSpan(24, 0, 0);
        public readonly TimeSpan PERIOD_1_WEEK = new TimeSpan(7, 0, 0, 0);

        [DefaultValue(Updates.EveryDay)]
        public Updates UpdatePeriod { get; set; }

        public DateTime LastUpdate;


        [DoNotReset()]
        public bool ShowYouTubeMessage = true;
        [DoNotReset()]
        public bool ShowFileUploadingMessage = true;
        [DoNotReset()]
        public bool ShowVideoUploadingMessage = true;
        [DoNotReset()]
        public bool ShowRandomMessage = true;

        /// <summary>
        /// a private constructor because this is a singleton
        /// </summary>
        private AppConfig()
        {
        }


        private void ResetValues()
        {
            ClearPasswordOnExit = false;

            VideoPrivate = false;
            VideoFPS = 15;

            audioChannels = 1;
            audioSampleFreq = 44100;
            audioBitrate = 128000;
            audioBitsPerSample = 16;

            //rembyURL = RembyConstants.RembyURL;
            //mediaStoreURL = RembyConstants.MediaStoreURL;
            legacyStorage = false;

        
            VideoFirstTimeExperienceShown = false;

            //YouTubeSignUpLink = RembyConstants.YouTubeSignUpLink;
            //RembySignUpLink = RembyConstants.RembySignUpLink;
            AutoStart = true;
            CurrentLanguage = Language.English;
            instance = null;

            MessageBoxDefaultPlace = Place.NearIcon;
            UpdatePeriod = Updates.EveryDay;
            

        }

        /// <summary>
        /// get an instance of AppConfig
        /// </summary>
        /// <returns></returns>
        public static AppConfig GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if(instance == null)
                    {
                        try
                        {
                            instance = Load();
                        }
                        catch (Exception e)
                        {
                            DebugHelper.Log("An error occured in attempt to load config:" + e.ToString());
                            instance = new AppConfig();
                        }
                    }

                    var temp = new AppConfig();
                    if (instance.version != temp.version)
                        instance.SetDefaults(true);

                   

                }

                
            }
            return instance;

        }

        public static void RestInstance()
        {
            instance = null;
        }

        public string[] Tags = new string[] { "Remby", "Remby.com", "Rembook", "YouTube", "Google", "Skype", "Screenshot", "Screen video" };

        public static string[] SupportedTags { get { return AppConfig.Instance.Tags; } }


        public static TopNav topnav { get; set; }

        public static bool IsCamConnected { get; set; }

        public static bool SuspendForceGC = false;

        public static History WebHistory;

        public Dictionary<string, string> subscriptionRestrictions = new Dictionary<string, string>();
        public static string accountType = "";
        public int HistoryPollInterval = 1800000;

        internal static RembyClipper2.Paid.Subscription subscriptions;

        internal static AppConfig Instance { get { return GetInstance(); } set { instance = value; } }

        internal static string YTUsername = "";
        internal static string YTPassword = "";
        internal static bool YTValid = false;

        internal static bool IsEditorEnabled = false;
        public const string ACCOUNT_NAME_BASIC = "basic";
        public const string ACCOUNT_NAME_PLUS = "plus";
        public static string AccountType 
        { 
            get
            {
                switch (accountType)
                {
                    case ACCOUNT_NAME_BASIC:
                        {
                            return LanguageMgr.LM.GetText(Labels.AccountType_Basic);
                        }
                    case ACCOUNT_NAME_PLUS:
                        {
                            return LanguageMgr.LM.GetText(Labels.AccountType_Plus);
                        }
                    default:
                        DebugHelper.Log("Unknown account type");
                        return LanguageMgr.LM.GetText(Labels.AccountType_Unknown);
                }
            } 
        }
        public static bool IsAccountTypeKnown
        {
            get { return accountType.Equals(ACCOUNT_NAME_BASIC) || accountType.Equals(ACCOUNT_NAME_PLUS); }
        }
        public int FileSizeLimit
        {
            get
            {
                int res = 3; //default value for the basic account
                int parsed = 0;
                if (subscriptionRestrictions.ContainsKey("max_page_size") && int.TryParse(subscriptionRestrictions["max_page_size"], out parsed))
                {
                    res = (int)Math.Round((decimal)parsed/(1000*1024));
                }

                return res;
            }
        }
        public int StorageSizeLimit
        {
            get
            {
                int res = 100; //default value for the basic account
                int parsed = 0;
                if (subscriptionRestrictions.ContainsKey("max_size_storage_default") && int.TryParse(subscriptionRestrictions["max_size_storage_default"], out parsed))
                {
                    res = (int)Math.Round((decimal)parsed / (1024 * 1024));
                }

                return res;
            }
        }
        internal static void TryAndLoadConfig(string user)
        {
            DirectoryInfo[] di = new DirectoryInfo[] { new DirectoryInfo(AppConfig.fileLocation + @"\" + user) };
            instance = Load(di, true);
        }

        /// <summary>
        /// loads the configuration from the config file
        /// </summary>
        /// <returns>an instance of AppConfig with all values set from the config file</returns>
        /// 
        internal static AppConfig Load()
        {
            return Load(new DirectoryInfo(AppConfig.fileLocation).GetDirectories(), false);
        }


        internal static AppConfig Load(DirectoryInfo[] di, bool ignore)
        {
            AppConfig conf;
            //CheckConfigFile();
            Stream s = null;

            foreach (DirectoryInfo dii in di)
            {
                string filename = dii.FullName + @"/" + AppConfig._filename;
                if (!File.Exists(filename))
                {
                    if (!AppConfig.AllowedToStore)
                    {
                        AppConfig.currentConfigSavedAs = filename;
                        AppConfig.AllowedToStore = true;
                        AppConfig tmp = new AppConfig();
                        tmp.ResetValues();
                        tmp.Store(false, true);
                        AppConfig.AllowedToStore = false;
                    }
                }
                try
                {
                    BinaryFormatter b = new BinaryFormatter();
                    using (Stream es = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {

                        RijndaelManaged algorithm = new RijndaelManaged();
                        algorithm.BlockSize = 256;
                        algorithm.KeySize = 256;

                        es.Position = 0;

                        Crypt.CreateKeyIV();
                        var EncDec = algorithm.CreateDecryptor(Crypt.key, Crypt.iv);
                        var crStream = new CryptoStream(es, EncDec, CryptoStreamMode.Read);
                        StreamReader sr = new StreamReader(crStream);
                        conf = (AppConfig)b.Deserialize(sr.BaseStream);

                        sr.Close();
                        crStream.Close();
                        EncDec.Dispose();
                        //algorithm.Dispose();

                    }

                    //XmlFormatter b = new XmlFormatter(typeof(AppConfig));
                    //conf = (AppConfig) b.Deserialize(s);

                    //s.Close();
                    conf.SetDefaults(false);
                    //if(conf.DrawingBorderColor.A == 0)
                    //{
                    //    conf.DrawingBorderColor = Color.FromArgb(255, conf.DrawingBorderColor);
                    //}
                    //if(conf.DrawingFillrColor.A == 0)
                    //{
                    //    conf.DrawingFillrColor = Color.FromArgb(255, conf.DrawingFillrColor);
                    //}

                    if (ignore)
                    {
                        currentConfigSavedAs = filename;
                        return conf;
                        
                    }
                    if (conf.Username != "" && conf.Password != "")
                    {
                        AppConfig.currentConfigSavedAs = filename;
                        return conf;
                    }
                }
                catch (SerializationException)
                {
                    if (s != null)
                    {
                        s.Close();
                    }
                    //DebugHelper.Log(e.ToString());
                    AppConfig config = new AppConfig();
                    return config;
                }
                catch (Exception)
                {
                    //DebugHelper.Error("Could not load RembyClipper's configuration file. Please check access permissions for '"+filename+"'.\n");
                    Process.GetCurrentProcess().Kill();
                }
            }
            return new AppConfig();
        }

        /// <summary>
        /// Checks for the existence of a configuration file.
        /// First in greenshot's Applicationdata folder (where it is stored since 0.6),
        /// then (if it cannot be found there) in greenshot's program directory (where older 
        /// versions might have stored it).
        /// If the latter is the case, the file is moved to the new location, so that a user does not lose
        /// their configuration after upgrading. 
        /// If there is no file in both locations, a virgin config file is created.
        /// </summary>
        private static void CheckConfigFile()
        {
            /*if (!File.Exists(fileLocation + @"/" + _filename))
            {
#if !DEBUG
				Directory.CreateDirectory(filename.Substring(0,filename.LastIndexOf(@"\")));
#endif
                new AppConfig().Store();
            }*/
        }

        internal static string currentConfigSavedAs = "";

        internal static bool AllowedToStore = false;
        public string SessionID;

        /// <summary>
        /// saves the configuration values to the config file
        /// </summary>
        public void Store(bool removeFile = false, bool forceSave = false)
        {
            if (!AllowedToStore)
                return;

            //if (AppConfig.topnav != null && AppConfig.topnav.IsHandleCreated && AppConfig.topnav.InvokeRequired)
            //{
            //    AppConfig.topnav.Invoke((MethodInvoker) (() => Store(removeFile, forceSave)));
            //}

            string filename = fileLocation + @"/" + Username + @"/" + _filename;
            if (!string.IsNullOrEmpty(currentConfigSavedAs))
            {
                FileInfo cFi = new FileInfo(filename);
                FileInfo cFi2 = new FileInfo(currentConfigSavedAs);
                if (cFi.Directory.FullName != cFi2.Directory.FullName)
                {
                    //firectory mistmatch!!!
                    //delete current config!
                    filename = currentConfigSavedAs;
                }
            }

            if (removeFile)
            {
                DebugHelper.Log("Deleting old config file and saving new");
                FileInfo fi = new FileInfo(filename);
                if (fi.Exists)
                    fi.Delete();
                ResetValues();
            }

            // if (Username == "")
            //     return;

            if (currentConfigSavedAs == "")
                currentConfigSavedAs = filename;

            if (Username == "" && forceSave == false)
                return;

            filename = currentConfigSavedAs;
            FileInfo fis = new FileInfo(filename);

            if (!Directory.Exists(fis.FullName.Replace(fis.Name, "")))
                Directory.CreateDirectory(fis.FullName.Replace(fis.Name, ""));

            //Stream s = File.Open(filename, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            //XmlFormatter formatter = new XmlFormatter(typeof(AppConfig));
            //formatter.Serialize(s, this);
            //s.Close();
            RijndaelManaged algorithm = new RijndaelManaged();
            algorithm.BlockSize = 256;
            algorithm.KeySize = 256;
            MemoryStream ms = new MemoryStream();
            Crypt.CreateKeyIV();
            var EncDec = algorithm.CreateEncryptor(Crypt.key, Crypt.iv);
            var crStream = new CryptoStream(ms, EncDec, CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(crStream);
            formatter.Serialize(sw.BaseStream, this);
            sw.Flush();
            crStream.FlushFinalBlock();

            using (StreamWriter fsw = new StreamWriter(filename, false))
            {
                byte[] pwd_byte = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(pwd_byte, 0, (int)pwd_byte.Length);

                fsw.BaseStream.Write(pwd_byte, 0, pwd_byte.Length);
            }
            sw.Close();
            EncDec.Dispose();
            crStream.Close();
            ms.Close();
            //algorithm.Dispose();

            DebugHelper.Log("Config file saved");
        }


        /// <summary>
        /// when new fields are added to this class, they are instanced
        /// with null by default. this method iterates over all public
        /// fields and uses reflection to set them to the proper default value.
        /// </summary>
        private void SetDefaults(bool respectDNR)
        {
            Type type = this.GetType();
            FieldInfo[] fieldInfos = type.GetFields();
            DoNotResetAttribute dnr;
            bool found = false;

            foreach (FieldInfo fi in fieldInfos)
            {
                found = false;
                foreach (Attribute attr in fi.GetCustomAttributes(true))
                {
                    dnr = attr as DoNotResetAttribute;
                    if (null != dnr)
                    {
                        found = true;
                        break;
                    }
                }
                if (found && respectDNR)
                    continue;

                if (!found && respectDNR)
                {
                    AppConfig tmpConf = new AppConfig();
                    Type tmpType = tmpConf.GetType();
                    FieldInfo defaultField = tmpType.GetField(fi.Name);
                    fi.SetValue(this, defaultField.GetValue(tmpConf));
                }

                object o = fi.GetValue(this);
                int i;
                if (o == null || (int.TryParse(o.ToString(), out i) && i == 0))
                {
                    // found field with value null. setting to default.
                    AppConfig tmpConf = new AppConfig();
                    Type tmpType = tmpConf.GetType();
                    FieldInfo defaultField = tmpType.GetField(fi.Name);
                    fi.SetValue(this, defaultField.GetValue(tmpConf));
                }
            }
            // Store();
        }

    }
}
