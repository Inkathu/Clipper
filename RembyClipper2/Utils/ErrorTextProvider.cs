using Localization;

namespace RembyClipper2.Utils
{
    public class ErrorTextProvider
    {
        public static string GetText(string error)
        {
            string res = "";
            if (error.ToLower() == "unsupported_media_type")
            {
                res = LanguageMgr.LM.GetText(Labels.unsupported_media_type);
            }            
            if (error.ToLower() == "not_authorized")
            {
                res = LanguageMgr.LM.GetText(Labels.not_authorized);
            }
            return res;
        }
    }
}