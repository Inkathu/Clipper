using System;
using System.Collections.Generic;
using System.Text;

namespace Localization
{
    public static class LanguageMgr
    {

        private static object _lock = new object();
        public static ILanguageManager LM
        {
            get 
            {
                if (_lm == null)
                {
                    lock (_lock)
                    {
                        if (_lm == null)
                        {
                            _lm = new DefaulLanguageManager();
                        }
                    }
                }
                return _lm;
            }
        }
        private static ILanguageManager _lm;

        public static string GetLanguageDescription(Language lang)
        {
            return LM.GetTextRaw(Enum.GetName(typeof(Language), lang) + "Language");
        }
    }
}
