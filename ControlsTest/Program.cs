using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Localization;

namespace ControlsTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new PropertyEditor());
            Localization.LanguageMgr.LM.SetDefaultLanguage(Language.Russian);
            Application.Run(new Form1());
        }
    }
}
