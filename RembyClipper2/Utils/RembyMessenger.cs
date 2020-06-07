using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using RembyClipper2.Utils.Meesenger;

namespace RembyClipper2.Utils
{
    public class RembyMessenger
    {
        static Forms.NotificationsAreaForm _form = null;
        static Thread _thread = null;
        public static IntPtr Handle
        {
            get
            {
                IntPtr result = IntPtr.Zero;
                _form.Invoke((MethodInvoker)(() => { result = _form.Handle; }));
                return result;
            }
        }
        static void ShowThread()
        {
            Thread.Sleep(1000);
            _form = new Forms.NotificationsAreaForm();
            
            Application.Run(_form);
        }


        static public void Show()
        {
            if (_thread != null)
                return;

            _thread = new Thread(new ThreadStart(ShowThread)) {Name = "Messenger", IsBackground = true};
            _thread.TrySetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        static public void AddNotification(INotification notification)
        {
            if (_form == null)
            {
                var thread = new Thread(WaitMethod);
                
                thread.Start(notification);
            }
            if(_form != null)
            {
                _form.AddNotification(notification);
                _form.Invalidate();
            }
            
        }

        private static void WaitMethod(object param)
        {
            while (_form == null || !_form.IsHandleCreated) 
            {
                //wait for form creation
                Thread.Sleep(1000);
            }

            INotification notification = param as INotification;
            if(notification != null)
            {
                AddNotification(notification);    
            }
            
        }

        static public void Close()
        {
            if (_thread == null) return;
            if (_form == null) return;

            try
            {
                if (_form.IsHandleCreated)
                {
                    _form.Invoke(new MethodInvoker(_form.Close));
                }
            }
            catch (Exception)
            {
            }
            _thread = null;
            _form = null;
        }
    }


}
