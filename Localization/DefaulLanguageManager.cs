using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Collections;
using System.IO;

namespace Localization
{
    public class DefaulLanguageManager : ILanguageManager
    {
        private const string DEFAULT_WORD = "***";
        private const string DEFAULT_LANGUAGE = "English";
        private const string resourcePrefix = "Localization.";
        private const string resourcePostfix = ".resources";
        private static object _lock = new object();
        private static ResourceManager Manager
        {
            get 
            {
                if (_manager == null)
                {
                    lock (_lock)
                    {
                        if (_manager == null)
                        {
                            _manager = new ResourceManager("Localization", Assembly.GetExecutingAssembly());
                        }
                    }

                }
                return _manager;
            }

        }
        private static ResourceManager _manager;

        private static ResourceReader Reader
        {
            get 
            {
                lock (_lock)
                {

                    _reader = new ResourceReader(Assembly.GetCallingAssembly().GetManifestResourceStream(_defaultLanguage));
                }
                return _reader;
            }
            set 
            {
                lock (_lock)
                {
                    _reader = value;
                }
            }
        }
        private static ResourceReader _reader;

        public static string DefaultLanguage 
        {
            get
            {
                if (string.IsNullOrEmpty(_defaultLanguage))
                {
                    DefaultLanguage = DEFAULT_LANGUAGE;
                }
                return _defaultLanguage.Replace(resourcePrefix, "").Replace(resourcePostfix, "");
            }
            set
            {
                _defaultLanguage = resourcePrefix + value + resourcePostfix;
                Reader = new ResourceReader(Assembly.GetCallingAssembly().GetManifestResourceStream(_defaultLanguage));
                 ReloadDictionary();
            }
        }
        private static string _defaultLanguage;

        private static Dictionary<string, string> _dict = new Dictionary<string, string>();
        private static void ReloadDictionary()
        {
            _dict.Clear();
            IResourceReader reader = Reader;
            IDictionaryEnumerator en = reader.GetEnumerator();
            while (en.MoveNext())
            {
                if (en.Key is string && en.Value is string) 
                {
                    _dict.Add(((string)en.Key).ToLower(), (string)en.Value);
                }
            }
            reader.Close();
        }


        public string GetTextRaw(string key)
        {
            key = key.ToLower();
            if (_dict.ContainsKey(key))
            {
                return _dict[key];
            }
            return DEFAULT_WORD;
        }

        public string GetText(Labels key)
        {
            string label = Enum.GetName(typeof(Labels), key).ToLower();
            return GetTextRaw(label);
        }


        public string GetFormattedText(Labels key, params string[] formatValues)
        {
            string txt = GetText(key);
            if (!txt.Equals(DEFAULT_WORD)) 
            {
                return string.Format(txt, formatValues);
            }
            return DEFAULT_WORD;
        }

        public string GetLabelText(Labels key)
        {
            string colon = GetText(Labels.LabelDelimiter);
            return GetText(key) + colon;
        }

        public List<string> GetLanguages()
        {

            string[] resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            List<string> languages = new List<string>();
            string lng = "";
            foreach (string rName in resources)
            { 
                lng = rName.Replace(resourcePrefix, "").Replace(resourcePostfix, "");
                languages.Add(lng);
            }
            return languages;
        }

        public void SetDefaultLanguage(string language)
        {
            DefaultLanguage = language;

        }
        
        public void SetDefaultLanguage(Language language)
        {
            SetDefaultLanguage(Enum.GetName(typeof (Language), language));
        }

    }
}
