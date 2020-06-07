using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Google.GData.Client;
using Google.GData.YouTube;
using Localization;
using Microsoft.Win32;
using RembyClipper.Forms;
using RembyClipper.Helpers;
using RembyClipper2.Config;
using RembyClipper2.Controllers;
using RembyClipper2.Forms;
using RembyClipper2.Forms.InformationDialog;
using RembyClipper2.Forms.InformationDialog.FormPlacer;
using RembyClipper2.Helpers;
using RembyClipper2.HotKeys;
using RembyClipper2.Paid;
using RembyClipper2.Properties;
using RembyClipper2.Utils;
using RembyClipper2.Utils.DragAndDrop;
using RembyClipper2.Utils.Meesenger.Uploading;
using RembyClipper2.Utils.Uploading;
using RembyClipper2.Utils.Uploading.Entities;
using RembyClipper2.Utils.Uploading.UploadingStrategies.Drupal;
using RembyClipper2.VideoEngine;
using RembyClipper2.Web;
using Status = RembyClipper2.Utils.Uploading.Entities.Status;
using Timer = System.Windows.Forms.Timer;
using RembyClipper2.Base;

namespace RembyClipper2.Base
{
    public partial class TopNav : Form
    {

        private const int SERVICE_TIMER_PERIOD = 1000; // tick every second

        private static bool screenSnapShown;

        private readonly EventHandler _cancelDelegate = delegate(object snd, EventArgs arg)
                                                            {
                                                                var item = snd as ToolStripMenuItem;
                                                                if (item != null)
                                                                {
                                                                    var entity = item.Tag as UploadEntityBase;
                                                                    if (entity != null)
                                                                    {
                                                                        UploadDispatcher.Instance.CancelItem(entity);
                                                                    }
                                                                }
                                                            };

        private readonly IconMovingController _movingController;

        private readonly Queue<DragEventArgs> _dragData = new Queue<DragEventArgs>();
        private readonly object dragQueueLocker = new object();
        private readonly Timer updateTimer;
        private readonly Dictionary<Form, ToolStripMenuItem> windowList = new Dictionary<Form, ToolStripMenuItem>();
        private ApplicationSwitchWatcher _appChangeWatcher;
        private TopWindowWatcher _topmostWatcher;
        private Dictionary<string, string> books;
        public bool canShowStripMenu = true;
        private bool isCanceled;
        private bool isDragConent;
        private int sign = -1;
        private int spentTime;
        private string surl = "";
        private string url = "";
        private string youtubeLinks = "";
        private readonly System.Threading.Timer _serviceTimer;

        public event Action ServiceTimerTick;

        public TopNav()
        {
            InitializeComponent();

            var appDataDi =
                new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                               @"RembyCollector"));
            if (!appDataDi.Exists)
                appDataDi.Create();

            if(!Settings.Default.LastLanguage.HasValue())
            {
                LanguageMgr.LM.SetDefaultLanguage(AppConfig.Instance.CurrentLanguage);    
            }
            
            Icon = NewDesign.clipper32x32;
            notifyIcon1.Icon = Icon;
            AppConfig.GetInstance();
            ApplyLanguage();

            updateTimer = new Timer();
            updateTimer.Tick += updateTimer_Tick;
            updateTimer.Interval = 1000*60*2; // every 60 minutes
//            updateTimer.Start();


            DebugHelper.ParentForm = this;
            DebugHelper.StartLogging();
            Size = new Size(32, 32);
            SetRegion();

            if (ApplicationDeployment.IsNetworkDeployed)
                checkForUpdatesToolStripMenuItem.Visible = true;

            Application.ApplicationExit += Application_ApplicationExit;

            SOLHelper.Write();
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            FormClosing += TopNav_FormClosing;

            UploadDispatcher.Instance.ItemProcessingBefore += Instance_ItemProcessingBefore;
            UploadDispatcher.Instance.ItemProcessingAfter += Instance_ItemProcessingAfter;
            UploadDispatcher.Instance.ItemProcessingCanceled += Instance_ItemProcessingCanceled;
            UploadDispatcher.Instance.ItemProcessingAdded += Instance_ItemProcessingAdded;
            _movingController = new IconMovingController(this);
            _movingController.IconMovedToUnproperlyPlace += movingController_IconMovedToUnproperlyPlace;
            DoubleBuffered = true;
            try
            {
                _serviceTimer = new System.Threading.Timer(ServiceTimerMethod, null, Timeout.Infinite, SERVICE_TIMER_PERIOD);
            }
            catch (Exception e)
            {
                DebugHelper.Log("[TopNav] : TopNav - An error occurred in attempt to change timer period :\r\n" + e.ToString());
            }            //CheckForUpdate();
        }

        private void ServiceTimerMethod(object state)
        {
            Action eventToRaise = ServiceTimerTick;
            if(eventToRaise != null)
            {
                eventToRaise();
            }
        }

        /// <summary>
        /// Name of the last application
        /// </summary>
        public string LastAppName
        {
            get { return _appChangeWatcher.LastAppTitle; }
        }

        /// <summary>
        /// Name of the latest process
        /// </summary>
        public string LastProcessName
        {
            get { return _appChangeWatcher.LastProcessName; }
        }

        /// <summary>
        /// Handle of the latest process
        /// </summary>
        public IntPtr LastAppHandle
        {
            get { return _appChangeWatcher.LastAppHandle; }
        }

        public string LastAppTitle
        {
            get
            {
                string res = "";
                StringBuilder builder = new StringBuilder(255);
                WIN32_API.GetWindowText(LastAppHandle, builder, 255);
                res = builder.ToString();
                return res;
            }
        }
        /// <summary>
        /// This property performs to hide window from alt+tab
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private string Tags
        {
            get { return AppConfig.Instance.LastUsedTags; }
            set
            {
                AppConfig.Instance.LastUsedTags = value;
                AppConfig.Instance.Store();
            }
        }

        public new bool TopMost
        {
            get { return base.TopMost; }
            set { base.TopMost = true; }
        }

        public bool IsIconPlacedProperly()
        {
            return _movingController.IconAtProperlyPlace;
        }

        private void movingController_IconMovedToUnproperlyPlace(object sender, EventArgs e)
        {
            if (AppConfig.Instance.MessageBoxDefaultPlace == Place.NearIcon)
            {
                AppConfig.Instance.MessageBoxDefaultPlace = Place.TopRight;
                InfoBoxDispatcher.ShowSimple(LanguageMgr.LM.GetText(Labels.NotificationsAreaWrongPlace),
                                             Resources.information);
                InfoBoxDispatcher.SetSetting(AppConfig.Instance.MessageBoxDefaultPlace);
            }
        }


        protected override void WndProc(ref Message m)
        {
            try
            {
                base.WndProc(ref m);
            }
            catch (Exception exc)
            {
                DebugHelper.Log(exc.ToString());
            }
        }


        protected override void DefWndProc(ref Message m)
        {
            try
            {
                base.DefWndProc(ref m);
            }
            catch (Exception e)
            {
                DebugHelper.Log(e.ToString());
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (AppConfig.Instance.UpdatePeriod != AppConfig.Updates.Never)
            {
                DateTime now = DateTime.Now;
                TimeSpan period = now - AppConfig.Instance.LastUpdate;
                try
                {
                    if ((AppConfig.Instance.UpdatePeriod == AppConfig.Updates.EveryHour &&
                         period >= AppConfig.Instance.PERIOD_1_HOUR)
                        ||
                        (AppConfig.Instance.UpdatePeriod == AppConfig.Updates.EveryDay &&
                         period >= AppConfig.Instance.PERIOD_1_DAY)
                        ||
                        (AppConfig.Instance.UpdatePeriod == AppConfig.Updates.EveryWeek &&
                         period >= AppConfig.Instance.PERIOD_1_WEEK))
                    {
                        CheckForUpdate();
                    }
                }
                catch (Exception exc)
                {
                    DebugHelper.Log("An error uccured in attempt to update application\r\n" + exc);
                    InfoBoxDispatcher.ShowError(LanguageMgr.LM.GetText(Labels.TopNav_UpdateErrorMessage));
                }
                finally
                {
                    AppConfig.Instance.LastUpdate = now;
                    AppConfig.Instance.Store();
                }
            }
        }

        private void CheckForUpdate()
        {
            DebugHelper.Log("Trying to check updates");
            BeginInvoke((MethodInvoker)
                        (() =>
                             {
                                 try
                                 {
                                     DebugHelper.Log("Update invocation started");
                                     var u = new UpdateHelper();
                                     DebugHelper.Log("Update helper created");
                                     u.UpdateApplication();
                                     DebugHelper.Log("Updating call finished");
                                 }
                                 catch (Exception e)
                                 {
                                     DebugHelper.Error("An error occurred in attempt to checking update. \r\n" + e);
                                 }
                             }));

            DebugHelper.Log("Update checking finished");
        }


        private void Instance_ItemProcessingAdded(object sender, EventArgs e)
        {
            var entity = e as UploadEntityBase;

            if (entity != null)
            {
                BeginInvoke((MethodInvoker) (() =>
                                                 {
                                                     var item = new ToolStripMenuItem(entity.Caption,
                                                                                      Resources.hourglass)
                                                                    {Tag = entity};
                                                     recentITemsTSMI.DropDownItems.Insert(3, item);
                                                     cancelAllToolStripMenuItem.Enabled = true;
                                                     cancelCurrentTSMI.Enabled = true;
                                                     recentUploadsSeparator.Visible = true;
                                                     recentITemsTSMI.Enabled =
                                                         recentITemsTSMI.DropDownItems.Count > 1;
                                                 }
                                            ));
            }
        }

        private void Instance_ItemProcessingCanceled(object sender, EventArgs e)
        {
            var entity = e as UploadEntityBase;

            if (entity != null)
            {
                entity.UploadStatus.Status = Status.Canceled;
                BeginInvoke((MethodInvoker) (() =>
                                                 {
                                                     if (entity.CallerForm != null && !entity.CallerForm.IsDisposed)
                                                     {
                                                         entity.CallerForm.Close();
                                                     }
                                                         
                                                     Instance_ItemProcessingAfter(sender, e);
                                                 }));
            }
        }

        private void Instance_ItemProcessingAfter(object sender, EventArgs e)
        {
            var entity = e as UploadEntityBase;

            if (entity != null)
            {
                BeginInvoke((MethodInvoker) (() =>
                                                 {
                                                     ToolStripMenuItem item =
                                                         recentITemsTSMI.DropDownItems.FindMenuItemByEntity(entity);
                                                     if (item != null)
                                                     {
                                                         item.Image = entity.UploadStatus.Status == Status.Uploaded
                                                                          ? Resources.tick1
                                                                          : Resources.cross;
                                                         item.Click -= _cancelDelegate;
                                                         item.Click +=
                                                             ((snd, arg) => BeginInvoke((MethodInvoker) (entity.Open)));
                                                         List<UploadEntityBase> entyties =
                                                             recentITemsTSMI.DropDownItems.Cast<object>().Where(
                                                                 itm => itm != null && itm is ToolStripMenuItem).Cast
                                                                 <ToolStripMenuItem>().Where(
                                                                     itm => itm.Tag != null).Select(
                                                                         itm => (UploadEntityBase) itm.Tag).ToList();
                                                         int pendingCount =
                                                             entyties.Count(
                                                                 ent =>
                                                                 ent.UploadStatus.Status == Status.Pending ||
                                                                 ent.UploadStatus.Status == Status.InProgress);

                                                         int uploadedCount =
                                                             entyties.Count(
                                                                 ent => ent.UploadStatus.Status == Status.Uploaded);
                                                         int notUploaded =
                                                             entyties.Count(
                                                                 ent =>
                                                                 (ent.UploadStatus.Status == Status.Error) ||
                                                                 (ent.UploadStatus.Status == Status.Canceled));
                                                         cancelAllToolStripMenuItem.Enabled = pendingCount > 0;
                                                         cancelCurrentTSMI.Enabled = pendingCount > 0;

                                                         //enable history items
                                                         clearListTSMI.Enabled = (uploadedCount + notUploaded) > 0;
                                                     }
                                                     else
                                                     {
                                                         DebugHelper.Log(
                                                             "[TopNav] Instance_ItemProcessingAfter : item in menu is empty");
                                                     }
                                                 }));
            }
            else
            {
                DebugHelper.Log("[TopNav] Instance_ItemProcessingAfter : entity is empty :(");
            }
        }

        private void Instance_ItemProcessingBefore(object sender, EventArgs e)
        {
            var entity = e as UploadEntityBase;

            if (entity != null)
            {
                BeginInvoke((MethodInvoker) (() =>
                                                 {
                                                     ToolStripMenuItem item =
                                                         recentITemsTSMI.DropDownItems.FindMenuItemByEntity(entity);
                                                     if (item != null)
                                                     {
                                                         item.Image = Resources.small_loader_icon;
                                                     }
                                                     recentITemsTSMI.Enabled = true;
                                                     cancelAllToolStripMenuItem.Visible = true;
                                                 }));
            }
        }


        public event EventHandler languageChanged;


        private void ApplyLanguage()
        {
            aboutToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.Tray_About);
            aboutRIconTSMI.Text = LanguageMgr.LM.GetText(Labels.Tray_About);
            optionsToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.Tray_Options);
            exitToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.Tray_Exit);

            screenCaptureToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_Capture);
            screenVideoToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_Video);
            closeToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_Close);
            historyToolStripMenuItem.Text = historyToolStripMenuItem.Enabled
                                                ? LanguageMgr.LM.GetText(Labels.TopNav_History)
                                                : LanguageMgr.LM.GetText(Labels.TopNav_HistoryRefreshing);
            //labelShare.Text = LanguageMgr.LM.GetLabelText(Labels.ShareThis);

            openWindowsToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.Windows_Open);
            textToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_Text);
            editBookToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_EditBook);
            toolStripMenuItem5.Text = LanguageMgr.LM.GetText(Labels.Tray_Options);

            gettingStartedToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.Tray_GettingStarted);

            trayScreenCaptureToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_Capture);
            trayVideoCaptureToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_Video);
            trayTextToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_Text);

            sendLogViaSkypeToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_SendLogViaSkype);
            showDebugLogToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_ShowDebugLog);
            openLogFolderToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_OpenLogFolder);
            checkForUpdatesToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_CheckForUpdates);

            gotoMyBooksToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_GoToMyBooks);
            gotoMyStuffToolStripMenuItem1.Text = LanguageMgr.LM.GetText(Labels.TopNav_GoToMyStuff);

            filesUploadTSMI.Text = LanguageMgr.LM.GetText(Labels.TopNav_Upload);
            filesUploadTSMI2.Text = LanguageMgr.LM.GetText(Labels.TopNav_Upload);

            recentITemsTSMI.Text = LanguageMgr.LM.GetText(Labels.TopNav_RecentUploadingItems);
            cancelAllToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_CancellAllUploading);
            cancelCurrentTSMI.Text = LanguageMgr.LM.GetText(Labels.TopNav_CancelCurrent);
            clearListTSMI.Text = LanguageMgr.LM.GetText(Labels.TopNav_ClearList);
        }

        private void TopNav_FormClosing(object sender, FormClosingEventArgs e)
        {
            _serviceTimer.Dispose();
            FormClosing -= TopNav_FormClosing;
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker) MakeLocationValid);
        }

        private void SetRegion()
        {
            SetRegion(this, false);
        }

        internal void SetRegion(Form obj, Size s)
        {
            obj.Region = Region.FromHrgn(CreateRoundRectRgn(obj.Bounds.Left, obj.Bounds.Top, s.Width, s.Height, 5, 5));
        }

        internal void SetRegion(Control obj, Size s)
        {
            obj.Region = Region.FromHrgn(CreateRoundRectRgn(obj.Bounds.Left, obj.Bounds.Top, s.Width, s.Height, 5, 5));
        }

        internal void SetRegion(Control obj, bool leaveRightSide)
        {
            int r = 10;
            int w = obj.Width;
            int h = obj.Height;
            var clipPath = new GraphicsPath();
            clipPath.StartFigure();
            clipPath.AddArc(-1, -1, r, r, 180, 90);
            if (!leaveRightSide)
            {
                clipPath.AddLine(r, -1, w - r, -1);
                clipPath.AddArc(w - r, -1, r, r, 270, 90);
                clipPath.AddLine(w, r, w, h - r);
                clipPath.AddArc(w - r, h - r, r, r, 0, 90);
                clipPath.AddLine(w - r, h, r, h);
            } 
            else
            {
                clipPath.AddLine(r, -1, w, -1);
                clipPath.AddLine(w, -1, w, h);
                clipPath.AddLine(w, h, r, h);
            }


            clipPath.AddArc(-1, h - r, r, r, 90, 90);
            clipPath.CloseFigure();
            obj.Region = new Region(clipPath);
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
            );

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            DebugHelper.Log("Application is exiting, and unregistering hotkeys");
            HotKeysHandler.UnregisterAllHotkeys();
        }

        private void MakeLocationValid()
        {
            int x, y;
            x = Location.X;
            y = Location.Y;
            if (x < Screen.PrimaryScreen.WorkingArea.X)
            {
                x = Screen.PrimaryScreen.WorkingArea.X;
            }
            else if (x > (Screen.PrimaryScreen.WorkingArea.Right - 32))
            {
                x = Screen.PrimaryScreen.WorkingArea.Right - 32;
            }

            if (Location.Y < Screen.PrimaryScreen.WorkingArea.Y)
            {
                y = Screen.PrimaryScreen.WorkingArea.Y;
            }
            Location = new Point(x, y);
        }

        private void TopNav_Load(object sender, EventArgs e)
        {
            try
            {
                DebugHelper.Log("TopNav form loading...");
                AppConfig.topnav = this;
                DebugHelper.Log("Message area replacing");
                InfoBoxDispatcher.SetSetting(AppConfig.Instance.MessageBoxDefaultPlace);

                //panel1.Location = new Point(0, 0);

                DebugHelper.Log("Add/Remove program icons setup");
                SetAddRemoveProgramsIcon();

                DebugHelper.Log("trying to login");
                if (!Login())
                {
                    DebugHelper.Log("login fail");
                    Application.Exit();
                }

                DebugHelper.Log("success login");
                AppConfig.AllowedToStore = true;
                Location = AppConfig.Instance.TopNavPosition;

                DebugHelper.Log("location invalidating");
                MakeLocationValid();

                DebugHelper.Log("settings storing");
                AppConfig.Instance.Store();

                //RembyServices.tempSecurityToken
                var uploader = new DrupalUploader(RembyServices.uID, RembyServices.securityID, AppConfig.Instance.LoginResponse.session);
                DebugHelper.Log("Background worker creating");
                var bw = new BackgroundWorker();
                bw.DoWork += bw_DoWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;

                DebugHelper.Log("Worker async launch");
                bw.RunWorkerAsync();
                DebugHelper.Log("worker launched");
                DebugHelper.Log("Showing greeting message");
                InfoBoxDispatcher.ShowSimple(
                    LanguageMgr.LM.GetText(Labels.TopNav_Hi) + " " + AppConfig.Instance.Username,
                    Resources.user_silhouette);
                DebugHelper.Log("greeting message shown");
#if LOGGING
                //showDebugLogToolStripMenuItem.Visible = true;
                //sendLogViaSkypeToolStripMenuItem.Visible = true;
                openLogFolderToolStripMenuItem.Visible = true;
#endif
                AllowDrop = true;
                //pictureBox5.AllowDrop = true;

                DebugHelper.Log("Check setting for showing start window");
                if (!AppConfig.Instance.GettingStartedWizardShown)
                {
                    DebugHelper.Log("Show starting window");
                    var gs = new GettingStarted();
                    gs.Show();
                }

                DebugHelper.Log("Check - should we flash the icon");
                if (ApplicationDeployment.IsNetworkDeployed
                    && ApplicationDeployment.CurrentDeployment.IsFirstRun)
                {
                    //bring user attenttion to the launched application
                    DebugHelper.Log("Trying to flash icon");
                    IconFlashing();
                    DebugHelper.Log("flashing finished");
                }
                DebugHelper.Log("Set window topmost");
                WIN32_API.MakeWindowTopMost(Handle);

                DebugHelper.Log("Checking for update");
                CheckForUpdate();
                DebugHelper.Log("Update checking finished");
            }
            catch (Exception exception)
            {
                DebugHelper.Log("An error occurred in attempt to load topnav window:\r\n" + exception);
            }
            finally
            {
                try
                {
                    _serviceTimer.Change(0, SERVICE_TIMER_PERIOD);
                    _appChangeWatcher = new ApplicationSwitchWatcher(Handle);
                    _appChangeWatcher.Start();
                    _topmostWatcher = new TopWindowWatcher(Handle, RembyMessenger.Handle);
                    _topmostWatcher.Start();
                }
                catch (Exception exc)
                {
                    DebugHelper.Log("An error occurred in attempt to start app change watcher :" + exc);
                }
            }
        }


        private void IconFlashing()
        {
            var tm = new Timer();
            tm.Interval = 50;
            tm.Tick += iconFlashTimerTick;
            tm.Tag = 8000;
            tm.Start();
        }

        private void iconFlashTimerTick(object sender, EventArgs e)
        {
            var timer = (Timer) sender;
            var time = (int) timer.Tag;
            if (time > 0)
            {
                if (Opacity == 0)
                {
                    sign = 1;
                }
                else if (Opacity == 1)
                {
                    sign = -1;
                }
                Invoke((MethodInvoker) (() => Opacity = Opacity + 0.25*sign));
                timer.Tag = time - 100;
            }
            else
            {
                timer.Stop();
                timer.Dispose();
                Invoke((MethodInvoker) (() => Opacity = 1));
            }
        }

        /// <summary>
        /// This method performs to login user
        /// </summary>
        /// <returns></returns>
        public static bool Login()
        {
            bool showLogin = false;

            if (AppConfig.Instance.Password != string.Empty)
            {
                //if (!RembyServices.newLogin(AppConfig.Instance.Username, "alexword"))
                //  showLogin = true;
                var wf = new WebLogin(false);
            }
            else
                showLogin = true;

            if (showLogin)
            {
                var wf = new WebLogin(false);
                DebugHelper.PropertyDump(AppConfig.Instance);
                if (AppConfig.Instance.Password == string.Empty)
                {
                    return false;
                }

                string tmpU = AppConfig.Instance.Username;
                string tmpP = AppConfig.Instance.Password;
                AppConfig.TryAndLoadConfig(AppConfig.Instance.Username);
                LanguageMgr.LM.SetDefaultLanguage(AppConfig.Instance.CurrentLanguage);
                AppConfig.topnav.ApplyLanguage();
                if (AppConfig.Instance.Username == "" || AppConfig.Instance.Password == "")
                {
                    AppConfig.Instance.Username = tmpU;
                    AppConfig.Instance.Password = tmpP;
                }
            }
            Settings.Default.CurrentUsedServiceUrl = Settings.Default.ServiceUrl;
            return true;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AppConfig.Instance.Store();
            historyToolStripMenuItem.Enabled = true;
            historyToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_History);
            if (books == null)
            {
                return;
            }
        }

        private void tsiAddbook_Click(object sender, EventArgs e)
        {
            var t = new Process();
            t.StartInfo.FileName = RembyConstants.RembyURL + "/myremby#opennewbook";
            t.Start();
        }

        private void tsi_Click(object sender, EventArgs e)
        {
            if (!AppConfig.IsEditorEnabled)
            {
                var t = new Process();
                t.StartInfo.FileName = RembyConstants.RembyURL + "/go/newpage?book_id=" +
                                       ((ToolStripMenuItem) sender).Tag + "&secu=" + RembyServices.securityID;
                t.Start();
            }
            else
            {
                var sr =
                    new ShareRemby(RembyConstants.RembyURL.ReplaceIfExist("https", "http") + "/go/newpage?book_id=" +
                                   ((ToolStripMenuItem) sender).Tag + "&secu=" + RembyServices.securityID);
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            DebugHelper.Log("Config file version: " + AppConfig.Instance.version);

            HotKeysHandler.RegisterAllHotkeys();

            AppConfig.subscriptions = new Subscription();
            AppConfig.subscriptions.loadXML();
            Helpers.Tags.GetTags();
            try
            {
                AtomCategoryCollection categories = YouTubeQuery.GetYouTubeCategories();
                var tmp3 = new SortedDictionary<string, string>();

                foreach (YouTubeCategory c in categories)
                {
                    if (c.Assignable && !c.Deprecated)
                    {
                        tmp3.Add(c.Label, c.Term);
                    }
                }

                //AppConfig.Instance.Terms = tmp3.Values.ToArray();
                //AppConfig.Instance.Categories = tmp3.Keys.ToArray();

                if (AppConfig.Instance.Terms == null)
                    AppConfig.Instance.Terms = new string[tmp3.Values.Count];

                if (AppConfig.Instance.Categories == null)
                    AppConfig.Instance.Categories = new string[tmp3.Keys.Count];

                tmp3.Values.CopyTo(AppConfig.Instance.Terms, 0);
                tmp3.Keys.CopyTo(AppConfig.Instance.Categories, 0);
            }
            catch (Exception ec)
            {
                DebugHelper.Error(ec.ToString());
            }


            var di = new DirectoryInfo(Environment.CurrentDirectory);
            foreach (FileInfo file in di.GetFiles())
            {
                try
                {
                    if (file.Extension.Contains("avi") || file.Extension.Contains("png") || file.Extension.Contains("mp4"))
                    {
                        file.Delete();
                    }
                }
                catch (Exception exc)
                {
                    DebugHelper.Log(exc.ToString());
                }
            }

            checkAutostartLink();

            DebugHelper.Log("Following cams are attached");

            AppConfig.IsCamConnected = CameraControl.IsCamAttached();
            if (AppConfig.IsCamConnected)
            {
                foreach (string cam in CameraControl.GetCameras())
                {
                    DebugHelper.Log(cam);
                }
            }

            DebugHelper.Separator();
            DebugHelper.PropertyDump(Environment.OSVersion);

            DebugHelper.GetLoadedModules();

            //books = RembyServices.getAllBooks(true);
            if (books == null)
            {
                books = new Dictionary<string, string>();
            }


            //commented for now. could be used in future
            //AppConfig.WebHistory = new History(false);


//            RembyEditingForm t = new RembyEditingForm();
//            t.Dispose();
        }

        private void checkAutostartLink()
        {
            if (ShortcutManager.shortcutExists(Environment.SpecialFolder.Startup))
                ShortcutManager.removeShortcut(Environment.SpecialFolder.Startup);

            if (AppConfig.Instance.AutoStart)
            {
                ShortcutManager.createShortcut(Environment.SpecialFolder.Startup);
            }
        }


        private void SetAddRemoveProgramsIcon()
        {
            //only run if deployed 
            if (ApplicationDeployment.IsNetworkDeployed
                && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                try
                {
                    DebugHelper.PropertyDump(ApplicationDeployment.CurrentDeployment);
                    DebugHelper.Log(Environment.CurrentDirectory);

                    var fi = new FileInfo("RembyUninstaller.exe");
                    DebugHelper.PropertyDump(fi);
                    DebugHelper.Log("Starting registry helper");


                    var t = new Process();
                    t.StartInfo.FileName = fi.FullName;
                    t.StartInfo.UseShellExecute = true;
                    t.StartInfo.Arguments = "registry";
                    if (!Environment.OSVersion.VersionString.Contains("5.1."))
                        t.StartInfo.Verb = "runas";
                    t.Start();
                    DebugHelper.Error("Uninstaller started");
                }
                catch (Exception ee)
                {
                    DebugHelper.Error(ee.ToString());
                }
            }
        }


        private void panel1_MouseLeave(object sender, EventArgs e)
        {
#if legacyTopNav
            this.pictureBox5.Visible = true;
            this.pictureBox5.Enabled = true;
            this.panel1.Visible = false;
            this.Size = new Size(32, 32);
#else

#endif
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
#if legacyTopNav
            this.pictureBox5.Visible = false;
            this.pictureBox5.Enabled = false;
            this.panel1.Visible = true;
            this.Size = new Size(32 + 50 + 51 + 33, 32);
            pictureBox2_MouseEnter(sender, e);
#else

            if (!canShowStripMenu)
            {
                return;
            }
            Debug.WriteLine("Showing the menu");
            if (isDragConent)
            {
                return;
            }
            if (!menuCheckerLaunched)
            {
                menuCheckerLaunched = true;
                this.ServiceTimerTick += menuChecker;
            }
            if (contextMenuStripTopNav.Height > Screen.PrimaryScreen.WorkingArea.Height - (Location.Y + 32))
            {
                //show menu above the icon
                contextMenuStripTopNav.Show(Bounds.X, Bounds.Bottom - 32 - contextMenuStripTopNav.Height);
            }
            else
            {
                //show menu below the icon
                contextMenuStripTopNav.Show(Bounds.X, Bounds.Bottom - 2);
            }
            ContextSensitiveFramework.Instance.ShowRandomMessages();
#endif
        }


        public void hideTopNavContextMenu()
        {
            if (contextMenuStripTopNav.Visible)
                contextMenuStripTopNav.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            if (AppConfig.Instance.ClearPasswordOnExit)
            {
                AppConfig.Instance.Username = "";
                AppConfig.Instance.Password = "";
            }
            AppConfig.GetInstance().Store();
            Application.Exit();
        }

        internal void pictureBoxPhoto_Click(object sender, EventArgs e)
        {
            if (screenSnapShown)
            {
                return;
            }
            canShowStripMenu = false;
            panel1_MouseLeave(sender, e);
            Image img = GrabScreen.Snap(Screen.PrimaryScreen.Bounds, false, GrabScreenSource.Screenshot);
            var cf = new CaptureForm(img);
            screenSnapShown = true;
            Thread.Sleep(300);
            cf.Focus();
            cf.ShowDialog(this);
            screenSnapShown = false;
            canShowStripMenu = true;

            if (cf.CaptureCanceled)
                return;

            Image s = null;
            try
            {
                //Cursor.Hide();
                s = GrabScreen.Snap(cf.CaptureRect, true, GrabScreenSource.Screenshot);
            }
            finally
            {
                //Cursor.Show();
            }

            if (s.Size.Width == Screen.PrimaryScreen.Bounds.Width && s.Size.Height == Screen.PrimaryScreen.Bounds.Height &&
                !AppConfig.Instance.OneClickScreenShotShown)
            {
                var form = new OneClickScreenShotWarning();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BeginInvoke((MethodInvoker) (() => pictureBoxPhoto_Click(this, EventArgs.Empty)));
                    return;
                }
            }
            var rsn = new RembyScreenshotNew();
            rsn.Image = s;
            rsn.Source = cf.Source;
            rsn.Show();
        }

        internal void pictureBoxVideo_Click(object sender, EventArgs e)
        {
            if (screenSnapShown)
            {
                return;
            }
            panel1_MouseLeave(sender, e);
            Image img = GrabScreen.Snap(CaptureForm.GetScreenBounds(), false, GrabScreenSource.Screenshot);
            var rf = new ScreenCaptureForm(img);
            screenSnapShown = true;
            rf.Focus();
            rf.ShowDialog(this);
            screenSnapShown = false;

            if (rf.CaptureCanceled)
                return;

            if (!File.Exists(rf.FileName))
                return;

            var fvp = new FormVideoPlayer();
            GC.KeepAlive(fvp);

            fvp.rembyVideo1.videoPlayer1.Filename = rf.FileName;
            fvp.rembyVideo1.videoPlayer1.ParentForm = fvp;
            fvp.rembyVideo1.videoPlayer1.Init();
            fvp.rembyVideo1.Title = rf.Source;

            //TODO : uncomment this
            //if (!AppConfig.Instance.VideoFirstTimeExperienceShown)
            // fvp.rembyVideo1.labelYT.Visible = false;

            fvp.rembyVideo1.comboBoxCategories.Items.AddRange(AppConfig.Instance.Categories);
            fvp.rembyVideo1.comboBoxCategories.SelectedIndex = 6;

            fvp.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(LanguageMgr.LM.GetText(Labels.TopNav_Exit), LanguageMgr.LM.GetText(Labels.RembyClipper),
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (AppConfig.Instance.ClearPasswordOnExit)
                {
                    AppConfig.Instance.Username = "";
                    AppConfig.Instance.Password = "";
                }
                notifyIcon1.Visible = false;
                AppConfig.GetInstance().Store();
                //Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OptionsForm of = new OptionsForm();
            //of.ShowDialog();
            var of = new Options2();
            of.Closed += OptionsFormClosed;
            of.ShowInstance();
        }

        private void OptionsFormClosed(object sender, EventArgs e)
        {
            ApplyLanguage();
            if (languageChanged != null)
            {
                languageChanged(this, EventArgs.Empty);
            }
            //if (AppConfig.Instance.UpdatePeriod == AppConfig.Updates.Never && updateTimer != null && updateTimer.Enabled)
            //{
            //    updateTimer.Stop();
            //}
            //else if (updateTimer != null && !updateTimer.Enabled)
            //{
            //    updateTimer.Start();
            //}
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateIfNotOpened<AboutForm>();
            //var af = new AboutForm();
            //af.ShowDialog();
        }

        private void showDebugLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var t = new Process();
            t.StartInfo.FileName = Environment.CurrentDirectory + @"\log\" + DebugHelper.Filename;
            t.Start();
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            
            bool cursorInContextMenu = contextMenuStripTopNav.Bounds.Contains(Cursor.Position);
            bool cursorInForm = this.Bounds.Contains(Cursor.Position);
            bool cursorInOpenWndMenu = false;
            bool cursorInEditBookMenu = false;
            bool cursorInRecentItemsMenu = false;
            if (openWindowsToolStripMenuItem.DropDown != null)
            {
                cursorInOpenWndMenu = openWindowsToolStripMenuItem.DropDown.Bounds.Contains(Cursor.Position);
            }

            if (editBookToolStripMenuItem.DropDown != null)
            {
                cursorInEditBookMenu = editBookToolStripMenuItem.DropDown.Bounds.Contains(Cursor.Position);
            }
            if (recentITemsTSMI.DropDown != null)
            {
                cursorInRecentItemsMenu = recentITemsTSMI.DropDown.Bounds.Contains(Cursor.Position);
            }

            if (!cursorInContextMenu && !cursorInForm && !cursorInOpenWndMenu && !cursorInEditBookMenu && !cursorInRecentItemsMenu)
            {
                contextMenuStripTopNav.Hide();
                if(menuCheckerLaunched)
                {
                    this.ServiceTimerTick -= menuChecker;
                    menuCheckerLaunched = false;
                }
            }
            isDragConent = false;
        }

        private bool menuCheckerLaunched = false;
        void menuChecker()
        {
            this.Invoke(() => pictureBox5_MouseLeave(this, EventArgs.Empty));
        }

        internal void UpdateHistory()
        {
            if (!historyToolStripMenuItem.Enabled)
                return;

            historyToolStripMenuItem.Enabled = false;

            historyToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_HistoryRefreshing);

            var historyBW = new BackgroundWorker();
            historyBW.DoWork += historyBW_DoWork;
            historyBW.RunWorkerCompleted += historyBW_RunWorkerCompleted;
            historyBW.RunWorkerAsync();
        }

        private void historyBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            historyToolStripMenuItem.Enabled = true;
            historyToolStripMenuItem.Text = LanguageMgr.LM.GetText(Labels.TopNav_History);
            //OpenStatus(LanguageMgr.LM.GetText(Labels.TopNav_History), false);
            InfoBoxDispatcher.ShowSuccess(LanguageMgr.LM.GetText(Labels.TopNav_History));
        }

        private void historyBW_DoWork(object sender, DoWorkEventArgs e)
        {
            DebugHelper.LogCPU();
            AppConfig.WebHistory.Dispose();
            AppConfig.WebHistory = new History(false);
            Helpers.Tags.GetTags();
            DebugHelper.LogCPU();
        }


        private void timerClose_Tick(object sender, EventArgs e)
        {
            timerClose.Enabled = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fh = new FormHistory();
            fh.Show();
        }

        public void RegisterOpenWindow(Form Window)
        {
            var tsmi = new ToolStripMenuItem();
            tsmi.Tag = Window;

            if (Window is RembyScreenshotNew)
            {
                tsmi.Image = NewDesign.icon_screenshots;
                tsmi.Text = LanguageMgr.LM.GetText(Labels.Windows_Screenshot);
            }
            else if (Window is FormVideoPlayer)
            {
                tsmi.Image = NewDesign.icon_video;
                tsmi.Text = LanguageMgr.LM.GetText(Labels.Windows_Screenvideo);
            }
            else if (Window is FormQuicktext)
            {
                tsmi.Image = Resources.text1;
                tsmi.Text = LanguageMgr.LM.GetText(Labels.RembyText_WindowTitle);
            }
            else if (Window is FormFileUpload)
            {
                tsmi.Image = Resources.files;
                tsmi.Text = LanguageMgr.LM.GetText(Labels.RembyFileUpload_WindowTitle);
            }
            else
            {
                tsmi.Text = Window.Text;
            }

            if (openWindowsToolStripMenuItem.Visible == false)
                openWindowsToolStripMenuItem.Visible = true;

            tsmi.ImageScaling = ToolStripItemImageScaling.None;
            tsmi.Click += tsmi_Click;

            openWindowsToolStripMenuItem.DropDownItems.Add(tsmi);
            windowList.Add(Window, tsmi);
        }

        public void RegisterCloseWindow(Form Window)
        {
            if (windowList.ContainsKey(Window))
            {
                ToolStripMenuItem t = windowList[Window];
                openWindowsToolStripMenuItem.DropDownItems.Remove(t);
                windowList.Remove(Window);
                if (openWindowsToolStripMenuItem.DropDownItems.Count == 0)
                    openWindowsToolStripMenuItem.Visible = false;
            }
        }

        public void CreateIfNotOpened<T>() where T : Form, new()
        {
            Form wnd = windowList.Keys.Where(form => form is T).FirstOrDefault();
            if (wnd != null)
            {
                if (wnd.Visible)
                {
                    wnd.Activate();
                }
                else
                {
                    wnd.Show(this);
                }

                return;
            }

            wnd = new T();
            RegisterOpenWindow(wnd);
            wnd.Closing += ((sender, args) => RegisterCloseWindow(wnd));
            wnd.Show(this);
        }

        private void tsmi_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                var t = (ToolStripMenuItem) sender;
                if (t.Tag != null && t.Tag is Form)
                {
                    var f = ((Form) t.Tag);
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    if (f.Visible == false)
                    {
                        f.Show();
                    }
                    f.Focus();
                }
            }
        }

        private void sendLogViaSkypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.Copy(Environment.CurrentDirectory + @"\log\" + DebugHelper.Filename,
                          Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + DebugHelper.Filename);

                MessageBox.Show(LanguageMgr.LM.GetFormattedText(Labels.TopNav_SendSkypeMessageWithParam,
                                                                DebugHelper.Filename));
                var path = (string) Registry.GetValue("HKEY_CURRENT_USER\\Software\\Skype\\Phone", "SkypePath", "");
                var t = new Process();
                t.StartInfo.FileName = path;
                //t.StartInfo.Arguments = "/sendto:\"" + Environment.CurrentDirectory + @"\log\" + DebugHelper.Filename + "\"";
                t.StartInfo.Arguments = "/uri:skype:tomi?sendfile";
                t.Start();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private Queue<UploadEntityBase> _dragQueue = new Queue<UploadEntityBase>();
        private void pictureBox5_DragEnter(object sender, DragEventArgs e)
        {
            //_dragQueue.Clear();
            isDragConent = true;
            List<UploadEntityBase> items = DragAndDropProcessor.ProcessDraggedItem(LastProcessName, e, Tags);
            if(items == null || items.Count == 0)
            {
                e.Effect = DragDropEffects.None;

                if(LastProcessName.ToLower() == "iexplore")
                {
                    InfoBoxDispatcher.ShowError(LanguageMgr.LM.GetText(Labels.IE_Not_Supported));
                }
                else
                {
                    InfoBoxDispatcher.ShowError(LanguageMgr.LM.GetText(Labels.TopNav_DragAndDropDoesntSupported));
                }
            }
            else
            {
                e.Effect = DragDropEffects.Copy;
                lock (dragQueueLocker)
                {
                    _dragQueue.Enqueue(items[0]);    
                }
                
            }
        }

       

        private void pictureBox5_DragDrop(object sender, DragEventArgs e)
        {
            isDragConent = true;

            try
            {
                spentTime = AppConfig.Instance.SecondsBeforeUpload;
            
                isCanceled = false;
                bool r = false;
                lock (dragQueueLocker)
                {
                    foreach (DragEventArgs ie in _dragData)
                    {
                        if (compareDragEventArgs(ie, e))
                        {
                            r = true;
                            break;
                        }
                    }
                    if(r)
                    {
                        _dragData.Dequeue();
                    }
                }
                if (!r)
                {
                    if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    {
                        var files = (string[]) e.Data.GetData("FileDrop");
                        if (files != null)
                        {
                            // TODO: Cope with image compression
                            //if(files.Length == 1 && isImage(files[0]))
                            //{
                            //    RembyScreenshotNew screenshotNew = new RembyScreenshotNew();
                            //    FileInfo info = new FileInfo(files[0]);
                            //    screenshotNew.Image = ImageHelper.LoadFromFile(files[0]);
                            //    screenshotNew.FileName = info.Name;
                            //    screenshotNew.IsScreenShot = false;
                            //    AppConfig.topnav.Invoke(() => screenshotNew.Show(AppConfig.topnav));
                            //    isCanceled = true;
                            //} else
                            {
                                if (!timerDragnDrop.Enabled)
                                {
                                    timerDragnDrop.Enabled = true;
                                }
                                lock (dragQueueLocker)
                                {
                                    _dragData.Enqueue(e);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!timerDragnDrop.Enabled)
                        {
                            timerDragnDrop.Enabled = true;
                        }
                        lock (dragQueueLocker)
                        {
                            _dragData.Enqueue(e);
                        }
                    }
                }
                DebugHelper.Log("Queue length: " + _dragData.Count + " " + r);
            }
            finally
            {
            }
           
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool compareDragEventArgs(DragEventArgs a, DragEventArgs b)
        {
            var diff = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
            foreach (string s in a.Data.GetFormats())
                diff[s] = 1;
            foreach (string s in b.Data.GetFormats())
            {
                int value;
                if (diff.TryGetValue(s, out value) && value != 2)
                    diff[s] = 3;
                else
                    diff[s] = 2;
            }

            foreach (var d in diff)
                if (d.Value != 3)
                    return false;

            foreach (string s in a.Data.GetFormats())
            {
                object ad = a.Data.GetData(s);
                object bd = b.Data.GetData(s);
                if (ad == null || bd == null)
                    continue;

                if (ad.Equals(bd))
                    return true;
            }
            return false;
        }

        private void UploadDraggedItems(List<UploadEntityBase> items)
        {
            if (isCanceled)
            {
                return;
            }
            //List<UploadEntityBase> items = DragAndDropProcessor.ProcessDraggedItem(LastProcessName, e, Tags);
            if(items != null && items.Count > 0)
            {
                UploadDispatcher.Instance.Upload(items);    
            } else
            {
                DebugHelper.Log("[TopNav] : Error in drag and drop algo. By some reasons drag enter and drag drop gives different results.");
            }
            
        }

        private bool isImage(string file)
        {
            bool result = false;
            try
            {
                using (Image img = ImageHelper.LoadFromFile(file))
                {
                    result = img != null;
                }
            }
            catch (Exception)
            {
            }

            return result;
        }


        private void bw_RunWorkerCompletedFiles(object sender, RunWorkerCompletedEventArgs e)
        {
            //cancelUploadToolStripMenuItem.Visible = false;
            isCanceled = false;

            var ufr = (UploadFilesResult) e.Result;

            if (ufr.Total == ufr.Uploaded)
            {
                if (ufr.Total == 1)
                {
                    string url = RembyServices.shortenURL();
                    InfoBoxDispatcher.ShowSuccessShare(
                        ufr.response.FileType + " " + LanguageMgr.LM.GetText(Labels.TopNav_Uploaded),
                        RembyConstants.RembyURL + "/go/newpage?secu=" + RembyServices.securityID + "&url=" +
                        HttpUtility.UrlEncode(url),
                        HttpUtility.UrlEncode(url));
                }
                else
                {
                    InfoBoxDispatcher.ShowSuccess(LanguageMgr.LM.GetText(Labels.TopNav_Uploaded));
                }
            }
            if (ufr.Errors > 0)
            {
                InfoBoxDispatcher.ShowError(LanguageMgr.LM.GetText(Labels.TopNav_FewFilesWerentImages));
            }
            if (ufr.Uploaded != ufr.Total)
            {
                InfoBoxDispatcher.ShowError(ufr.Uploaded + "/" + ufr.Total + " " +
                                            LanguageMgr.LM.GetText(Labels.TopNav_WereUploaded));
            }


            if (youtubeLinks != "")
                MessageBox.Show(youtubeLinks);
        }

        internal void TetToolStripMenuItemClick(object sender, EventArgs e)
        {
            var fqt = new FormQuicktext();
            fqt.Show();
        }

        private void openLogFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var t = new Process();
            t.StartInfo.FileName = Environment.CurrentDirectory + @"\log";
            //t.StartInfo.Arguments = "/sendto:\"" + Environment.CurrentDirectory + @"\log\" + DebugHelper.Filename + "\"";
            t.Start();
        }

        private void gettingStartedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var gs = new GettingStarted();
            gs.ShowDialog();
        }

        public Cursor GetCurrentCursor()
        {
            return WIN32_API.GetCurrentCursor();
        }

        private void timerDragnDrop_Tick(object sender, EventArgs e)
        {
            string lastUsedTags = AppConfig.Instance.LastUsedTags;
            UploadEntityBase item = null;
            timerDragnDrop.Enabled = false;
            List<UploadEntityBase> items = new List<UploadEntityBase> { };
            lock (dragQueueLocker)
            {
//                if(_dragData.Count > 0)
//                {
//                    item = _dragData.Dequeue();
//                }
                while(_dragQueue.Count > 0)
                {
                    item = _dragQueue.Dequeue();
                    items.Add(item);
                }
            }
            if(item != null)
            {
//                items = DragAndDropProcessor.ProcessDraggedItem(LastProcessName, item, Tags);
                items = new List<UploadEntityBase> {item};
                InfoBoxDispatcher.ShowTags(str =>
                                               {
                                                   timerDragnDrop.Enabled = false;
                                                   if (items != null && items.Count > 0)
                                                   {
                                                       items.ForEach(it => it.Tags = str);
                                                       UploadDraggedItems(items);
                                                   }
                                                   Tags = str;
                                               }
                                           , lastUsedTags);
            }
            
            timerDragnDrop.Enabled = false;
            isDragConent = false;
        }
/*  //Temporary disabled items

        private void pictureBoxFB_Click(object sender, EventArgs e)
        {
            var sf = new ShareFacebook(surl);
        }

        private void pictureBoxTwitter_Click(object sender, EventArgs e)
        {
            var st = new ShareTwitter(surl);
        }
*/

        private void cancelUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isCanceled = true;
            InfoBoxDispatcher.ShowSuccess(LanguageMgr.LM.GetText(Labels.TopNav_Canceled));
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var u = new UpdateHelper();
            u.UpdateApplication(true);
        }


        private void TopNav_SizeChanged(object sender, EventArgs e)
        {
            if (Width > 32)
            {
                SetRegion(this, true);
            }
            else
            {
                SetRegion(this, false);
            }
        }

        private void TopNav_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.LastLanguage = Enum.GetName(typeof (Language), AppConfig.Instance.CurrentLanguage);
            Settings.Default.Save();
            notifyIcon1.Visible = false;
            if (_appChangeWatcher != null)
            {
                _appChangeWatcher.Stop();
            }
            if(_topmostWatcher != null)
            {
                _topmostWatcher.Stop();
            }
        }

        private void gotoMyStuffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var t = new Process();
            t.StartInfo.FileName = RembyConstants.RembyURL + "/collector/"+RembyServices.securityID;
            t.Start();
        }

        private void gotoMyBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var t = new Process();
            t.StartInfo.FileName = RembyConstants.RembyURL + "/mybooks";
            t.Start();
        }

        private void filesUploadTSMI_Click(object sender, EventArgs e)
        {
            var frm = new FormFileUpload();
            frm.Show();
        }

        private void cancelAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadDispatcher.Instance.Cancel();
        }

        private void cancelCurrentTSMI_Click(object sender, EventArgs e)
        {
            UploadDispatcher.Instance.CancelItem();
        }

        private void clearListTSMI_Click(object sender, EventArgs e)
        {
            recentITemsTSMI.RemoveAllProcessedItems();
            clearListTSMI.Enabled = false;
            recentUploadsSeparator.Visible = false;
            UploadDispatcher.Instance.ClearHistory();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        #region Icon moving routine

        private void pictureBoxSmallR_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void pictureBoxSmallR_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        private void pictureBoxSmallR_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

       

        #endregion



        #region Nested type: UploadFilesResult

        public struct UploadFilesResult
        {
            public int Errors;
            public int Total;
            public int Uploaded;
            public MediaStoreResponse response;
            public string ErrorMessage { get; set; }
        }

        #endregion

        #region Nested type: announceFileDelegate

        private delegate void announceFileDelegate(int c, int t);

        #endregion

        private void panel3_DragLeave(object sender, EventArgs e)
        {
            _dragQueue.Clear();
        }

        //        проверить строки связанные с обновлением на локализацию.
    }
}