using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using RembyClipper2.Forms.InformationDialog.FormPlacer;
using RembyClipper2.Utils;
using RembyClipper2.Utils.Meesenger;

namespace RembyClipper2.Forms.InformationDialog
{
    public class InfoBoxDispatcher
    {

        private const int INFOBOX_DEFAULT_TIME_TOSHOW = 20;//sec
        private const bool INFOBOX_DEFAULT_SHOW_COUNT_DOWN = true;
        private static InfoBox Box
        {
            get
            {
                lock (Locker)
                {
                    if (_box == null || _box.IsDisposed)
                    {
                        _box = new InfoBox();   
                    }
                    return _box;
                }
            }
        }

        private static InfoBoxSuccess SuccessBox
        {
            get
            {
                lock (Locker)
                {
                    if (_boxSucc == null || _boxSucc.IsDisposed)
                    {
                        _boxSucc = new InfoBoxSuccess();
                    }
                    return _boxSucc;
                }
            }
        }
        
        private static InfoBoxSuccessShare SuccessBoxShare
        {
            get
            {
                lock (Locker)
                {
                    if (_boxSuccShare == null || _boxSuccShare.IsDisposed)
                    {
                        _boxSuccShare = new InfoBoxSuccessShare();
                    }
                    return _boxSuccShare;
                }
            }
        }

        private static InfoBoxFail FailBox
        {
            get
            {
                lock (Locker)
                {
                    if (_boxFail == null || _boxFail.IsDisposed)
                    {
                        _boxFail = new InfoBoxFail();
                    }
                    return _boxFail;
                }
            }
        }
        private static InfoBoxTag TagBox
        {
            get
            {
                lock (Locker)
                {
                    if (_boxTag == null || _boxTag.IsDisposed)
                    {
                        _boxTag = new InfoBoxTag();
                    }
                    return _boxTag;
                }
            }
        }
        private static InfoBoxInProcess InProcessBox
        {
            get
            {
                lock (Locker)
                {
                    if (_boxOnProcess == null || _boxOnProcess.IsDisposed)
                    {
                        _boxOnProcess = new InfoBoxInProcess();
                    }
                    return _boxOnProcess;
                }
            }
        }

        private static InfoBoxSimple SimpleBox
        {
            get
            {
                lock (Locker)
                {
                    if (_boxSimple == null || _boxSimple.IsDisposed)
                    {
                        _boxSimple = new InfoBoxSimple();
                    }
                    return _boxSimple;
                }
            }
        }

        private static readonly object Locker = new object();
        private static InfoBox _box = null;
        private static InfoBoxSuccess _boxSucc = null;
        private static InfoBoxSuccessShare _boxSuccShare = null;
        private static InfoBoxFail _boxFail = null;
        private static InfoBoxTag _boxTag = null;
        private static InfoBoxInProcess _boxOnProcess = null;
        private static InfoBoxSimple _boxSimple = null;

        private static IFormPlacer _defaultPlacer;
        private static List<Form> infoFormList;
        
        static InfoBoxDispatcher()
        {
            _defaultPlacer = new BottomRightPlacer();
        }


        /// <summary>
        /// This methos performs to create window object before using
        /// need to avoid flickering
        /// </summary>
        public static void InitAllWindows()
        {
            
            InProcessBox.Hide();
            TagBox.Hide();
            FailBox.Hide();
            SuccessBoxShare.Hide();
            SuccessBox.Hide();
            SimpleBox.Hide();

            infoFormList = new List<Form>()
                               {
                                   InProcessBox,
                                   TagBox,
                                   FailBox,
                                   SuccessBoxShare,
                                   SuccessBox,
                                   SimpleBox
                               };

            infoFormList.ForEach(form => form.VisibleChanged += FormOnVisibleChanged);

        }

        private static void FormOnVisibleChanged(object sender, EventArgs eventArgs)
        {
            Form frm = sender as Form;
            if(frm != null && !frm.Visible)
            {
                int height = frm.Height;
                var visibleForms = GetVisibleForms();

                visibleForms.ForEach(form => _defaultPlacer.SlideWindow(form, height));
            }
        }

        private static List<Form> GetVisibleForms()
        {
            var lst = (from frm in infoFormList
                     where frm.Visible
                       select frm).ToList();
            lst.Sort((frm1, frm2) => frm1.Top.CompareTo(frm2.Top));
            return lst;
        }


//        public static void ShowBox(string caption, int seconds, bool showCountDown)
//        {
//            Box.Show(caption, seconds, showCountDown);
//        }

        public static void ShowError(string message)
        {
            //AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            //                                             {
            //                                                 _defaultPlacer.VisibleForms = GetVisibleForms();
            //                                                 _defaultPlacer.Place(FailBox);
            //                                                 FailBox.Show(caption, message, seconds,
            //                                                              showCountDown);
            //                                             }));
            RembyMessenger.AddNotification(new FailNotification()
            {
                Text = message,
            });
        }
        public static void ShowNotificationWithDonShowAgain(string message, Action<bool> action)
        {
            RembyMessenger.AddNotification(new InfoWithDontShowNotification(action){Text = message});
        }
        public static void ShowSuccess(string message)
        {
            //AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            //                                             {
            //                                                 _defaultPlacer.VisibleForms = GetVisibleForms();
            //                                                 _defaultPlacer.Place(SuccessBox);
            //                                                 SuccessBox.Show(caption, message, seconds, showCountDown);
            //                                             }));
            RembyMessenger.AddNotification(new NotificationBase()
            {
                Text = message,
                Image = RembyClipper2.Properties.Resources.tick1
            });
        }
       
        public static void ShowSuccessShare(string message, string shareUrl, string encodedUrl)
        {
            //AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            //                                             {
            //                                                 _defaultPlacer.VisibleForms = GetVisibleForms();
            //                                                 _defaultPlacer.Place(SuccessBoxShare);
            //                                                 SuccessBoxShare.Show(caption, message, shareUrl, encodedUrl, seconds, showCountDown);
            //                                             }));

            RembyMessenger.AddNotification(new SuccessShareNotification(encodedUrl)
                                               {
                                                   Text = message,
                                                   ShareUrl = shareUrl,
                                               });
        }

        public static void ShowTags(Action<string> onUploadAction, string caption, string tags, int seconds, bool showCountDown)
        {
            //AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            //                                             {
            //                                                 _defaultPlacer.VisibleForms = GetVisibleForms();
            //                                                 _defaultPlacer.Place(TagBox);
            //                                                 TagBox.Show(onUploadAction, caption, seconds, showCountDown);
            //                                             }));
            RembyMessenger.AddNotification(new TagsNotification()
            {
                Action = onUploadAction
            });
        }

        public static void ShowTags(Action<string> onUploadAction, string tags)
        {
            ShowTags(onUploadAction, AppConfig.Instance.Username, tags, INFOBOX_DEFAULT_TIME_TOSHOW,
                             INFOBOX_DEFAULT_SHOW_COUNT_DOWN);
        }


        public static void ShowInProcess(string message)
        {
            //AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            //                                             {
            //                                                 _defaultPlacer.VisibleForms = GetVisibleForms();
            //                                                 _defaultPlacer.Place(InProcessBox);
            //                                                 InProcessBox.Show(caption, message, seconds, showCountDown);
            //                                             }));
            RembyMessenger.AddNotification(new InprocessNotification()
            {
                Text = message,
            });


        }

        public static void ShowSimple(string message, Image img = null)
        {
            //AppConfig.topnav.BeginInvoke((MethodInvoker)(() =>
            //                                             {
            //                                                 _defaultPlacer.VisibleForms = GetVisibleForms();
            //                                                 _defaultPlacer.Place(SimpleBox);
            //                                                 SimpleBox.Show(caption, message, seconds, showCountDown);
            //                                             }));
            RembyMessenger.AddNotification(new NotificationBase()
                                               {
                                                   Text = message,
                                                   Image = img,
                                               });
        }
        
        
        public static List<PlaceCombobxItem> GetPossiblePlaceComboValues()
        {
            List<PlaceCombobxItem> items = new List<PlaceCombobxItem>()
                                               {
                                                   new PlaceCombobxItem(Place.BottomRight, LanguageMgr.LM.GetText(Labels.Place_BottomRight)),
                                                   new PlaceCombobxItem(Place.TopRight,    LanguageMgr.LM.GetText(Labels.Place_TopRight)),
                                               };
            if(AppConfig.topnav.IsIconPlacedProperly())
            {
                items.Add(new PlaceCombobxItem(Place.NearIcon, LanguageMgr.LM.GetText(Labels.Place_NearIcon)));
            }
            
            return items;
        }

        public static void SetSetting(Place place)
        {
            switch (place)
            {
                case Place.TopRight:
                    _defaultPlacer = new TopRightPlacer();
                    break;
                case Place.BottomRight:
                    _defaultPlacer = new BottomRightPlacer();
                    break;
                case Place.NearIcon:
                    _defaultPlacer = new NearIconPlacer();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
