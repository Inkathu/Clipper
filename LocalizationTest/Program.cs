using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Localization;

namespace LocalizationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lng = LanguageMgr.LM.GetLanguages();

            foreach (string lang in lng)
            {
                LanguageMgr.LM.SetDefaultLanguage(lang);
                foreach(string lb in Enum.GetNames(typeof(Labels)))
                {
                    Console.WriteLine("{0} : {1} = {2}", lang, lb, LanguageMgr.LM.GetText((Labels)Enum.Parse(typeof(Labels), lb)));
                }
            }

            Console.ReadKey();
            
            
        }
    }
}
