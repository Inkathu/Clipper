using System;
using System.Collections.Generic;
using System.Text;
using Localization;

namespace Localization
{
    public enum Language
    {
        English,
        Russian,
        Swedish,
    }

    public interface ILanguageManager
    {
        List<string> GetLanguages();
        string GetTextRaw(string key);
        string GetText(Labels key);
        string GetFormattedText(Labels key, params string[] formatValues);
        string GetLabelText(Labels key);
        void SetDefaultLanguage(string language);
        void SetDefaultLanguage(Language language);
    }
}
