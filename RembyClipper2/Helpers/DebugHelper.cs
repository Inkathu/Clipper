using System;
using System.Collections.Generic;

using System.Text;
using RembyClipper.Forms;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Specialized;
using ThreadState = System.Diagnostics.ThreadState;
using RembyClipper2.Utils;

namespace RembyClipper.Helpers
{
    public class DebugHelper
    {

       
        public static Form ParentForm;
        public static string Filename { get; private set; }

        private static StreamWriter sw;

        public static string FormatString(string S, int places, char character)
        {
            if (S.Length >= places)
                return S;
            for (int X = S.Length; X <= places; X++)
            {
                S = character + S;
            }
            return S;
        }

        private static TimeSpan oldCPUTime = new TimeSpan(0, 0, 0);
        private static Dictionary<int, TimeSpan> oldThreadTimes = null;
        private static Dictionary<int, string> knownNames = new Dictionary<int, string>();

        public static void AddKnownThreadIDs(int id, string name)
        {
            if(!knownNames.ContainsKey(id))
                knownNames.Add(id, name);
        }


        [Conditional("LOGGING")]
        public static void LogCPU()
        {
            Process thisProc = Process.GetCurrentProcess();

            string procName = thisProc.ProcessName;
            DateTime started = thisProc.StartTime;
            int procID = thisProc.Id;
            long memory = thisProc.VirtualMemorySize64;
            long priMemory = thisProc.PrivateMemorySize64;
            long physMemory = thisProc.WorkingSet64;
            int priority = thisProc.BasePriority;
            ProcessPriorityClass priClass = thisProc.PriorityClass;
            TimeSpan cpuTime = thisProc.TotalProcessorTime;

            
            //Log(string.Format("Process: {0}, ID: {1}", procName, procID));
            //Log(string.Format("    started: {0}", started.ToString()));

            var time = cpuTime.Subtract(oldCPUTime);

           
            writeLog("CPU", string.Format("CPU time: {0}", time.ToString()));
            if (time.TotalMilliseconds > 1000 && oldCPUTime.TotalMilliseconds != 0)
            {
                writeLog("CPU", "Something took more than 1000ms");
                writeLog("CPU", "\t" + Environment.StackTrace);
            }

            oldCPUTime = cpuTime;

            foreach (ProcessThread t in thisProc.Threads)
            {
                try
                {
                    string name = t.Id.ToString();
                    if (knownNames.ContainsKey(t.Id))
                        name = knownNames[t.Id];

                    if (oldThreadTimes == null)
                    {
                        oldThreadTimes = new Dictionary<int, TimeSpan>();
                        oldThreadTimes.Add(t.Id, t.TotalProcessorTime);
                        if (t.TotalProcessorTime.TotalMilliseconds == 0)
                            continue;



                        writeLog("CPU", string.Format("{0} - CPU time: {1}", name, t.TotalProcessorTime.ToString()));
                    }
                    if (!oldThreadTimes.ContainsKey(t.Id))
                    {
                        oldThreadTimes.Add(t.Id, t.TotalProcessorTime);
                        if (t.TotalProcessorTime.TotalMilliseconds == 0)
                            continue;
                        writeLog("CPU", string.Format("{0} - CPU time: {1}", name, t.TotalProcessorTime.ToString()));
                    }
                    else
                    {
                        if (t.ThreadState == ThreadState.Running)
                        {
                            var spentTime = t.TotalProcessorTime.Subtract(oldThreadTimes[t.Id]);
                            if (spentTime.TotalMilliseconds == 0)
                                continue;
                            writeLog("CPU", string.Format("{0} - CPU time: {1}", name, spentTime.ToString()));
                            oldThreadTimes[t.Id] = t.TotalProcessorTime;
                        }
                    }
                }
                catch
                {

                }
            }
            Log("----------------------------------------------------------------------");
            //Log(string.Format("    priority class: {0}  priority: {1}", priClass, priority));
            //Log(string.Format("    virtual memory: {0}", memory));
            //Log(string.Format("    private memory: {0}", priMemory));
            //Log(string.Format("    physical memory: {0}", physMemory));

           
        }

        [Conditional("LOGGING")]
        public static void Separator()
        {
            Log("----------------------------------------------------------------------");
        }

        [Conditional("LOGGING")]
        public static void StartLogging()
        {
            DirectoryInfo di = new DirectoryInfo("log");
            if (!di.Exists)
                di.Create();

            Filename = "Debug-" + DateTime.Now.Year.ToString() + FormatString(DateTime.Now.Month.ToString(), 2, '0') +
                                                    FormatString(DateTime.Now.Day.ToString(), 2, '0') + "-" +
                                                    FormatString(DateTime.Now.Hour.ToString(), 2, '0') +
                                                    FormatString(DateTime.Now.Minute.ToString(), 2, '0') +
                                                    FormatString(DateTime.Now.Second.ToString(), 2, '0') + ".log";
            sw = new StreamWriter("log/"+Filename, true);

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.ThreadExit += new EventHandler(Application_ThreadExit);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(CurrentDomain_AssemblyLoad);
           // AppDomain.CurrentDomain.FirstChanceException += new EventHandler<System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs>(CurrentDomain_FirstChanceException);
        }

        /*static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            writeLog("WARNING", e.Exception.ToString());
        }*/


        static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Log("Loaded assembly: " + args.LoadedAssembly.FullName);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log("Uncaught exception");
            Error(e.ToString());
            if (e.ExceptionObject is Exception)
                Error(((Exception)e.ExceptionObject).ToString());
        }

        static void Application_ThreadExit(object sender, EventArgs e)
        {
            Log("Thread is closing");
            Log(e.ToString());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log("Thread killed by exception");
            Error(e.Exception.ToString());
        }

        public delegate void debugCallback(string prefix, string text);

        [Conditional("LOGGING")]
        public static void Log(string text)
        {
            writeLog("LOG", text);
        }

        [Conditional("LOGGING")]
        public static void Error(string text)
        {
            writeLog("ERROR", text);
        }

        [Conditional("LOGGING")]
        public static void MemoryUsage()
        {
            writeLog("MEMORY", "Current memory usage: "+ GC.GetTotalMemory(true).ToString());
        }

        [Conditional("LOGGING")]
        public static void NVCDump(NameValueCollection info)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\r\n{0,-18} {1}\r\n", "Name", "Value");
            foreach(string k in info.AllKeys)
                sb.AppendFormat("{0,-18} {1}\r\n", k, info[k]);

            DebugHelper.Log(sb.ToString());
        }

        [Conditional("LOGGING")]
        public static void PropertyDump(object info)
        {
            StringBuilder sb = new StringBuilder();

            Type t = info.GetType();
            PropertyInfo[] props = t.GetProperties();
            var fields = t.GetFields();
            sb.AppendFormat("\r\n{0,-18} {1}\r\n", "Name", "Value");
            try
            {
                foreach (PropertyInfo prop in props)
                {
                    object val;
                    try
                    {
                        val = prop.GetValue(info, null);
                    }
                    catch
                    {
                        continue;
                    }
                    string tmp = "";
                    if (val != null)
                        tmp = val.ToString();
                    sb.AppendFormat("{0,-18} {1}\r\n", prop.Name, tmp);
                }
            }
            catch (Exception e)
            {
                Error(e.ToString());
            }

            try
            {
                foreach (var field in fields)
                {
                    object val;
                    try
                    {
                        val = field.GetValue(info);
                    }
                    catch
                    {
                        continue;
                    }
                    string tmp = "";
                    if (val != null)
                        tmp = val.ToString();
                    sb.AppendFormat("{0,-18} {1}\r\n", field.Name, tmp);
                }
            }
            catch (Exception e)
            {
                Error(e.ToString());
            }
            writeLog("DUMP", sb.ToString());

            
        }

        [Conditional("LOGGING")]
        public static void GetLoadedModules()
        {
            var modules = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly m in modules)
            {
                DebugHelper.Log(m.ToString());
            }
        }


        private static void writeLog(string prefix, string text)
        {

            if (ParentForm != null && ParentForm.InvokeRequired && !ParentForm.IsDisposed)
            {
                try
                {


                    lock (ParentForm)
                    {
                        debugCallback d = new debugCallback(writeLog);
                        text = "T[" + Thread.CurrentThread.Name + "]: " + Thread.CurrentThread.ThreadState.ToString() +
                               " | " + text;
                        ParentForm.BeginInvoke(d, prefix, text);
                    }
                }
                catch(Exception e)
                {
                    Debug.WriteLine("DebugHelper.cs : ln307 exception " + e.ToString());
                }
            }
            else
            {
                if (sw == null)
                    return;
                text = "T[" + Thread.CurrentThread.Name + "]: " + Thread.CurrentThread.ThreadState.ToString() + " | " + text;
                sw.WriteLine(DateTime.Now.ToString(@"ddMMMyyyy HH:mm:ss") + " [" + prefix + "] - " + text);
                sw.Flush();
            }
        }

        [Conditional("LOGGING")]
        public static void StopLogging()
        {
            sw.Close();
            
        }
    }
}
