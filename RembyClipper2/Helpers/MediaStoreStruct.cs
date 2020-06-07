using System;
using System.Collections.Generic;
using System.Text;
using Localization;

namespace RembyClipper2.Helpers
{
    [SmartAssembly.Attributes.DoNotObfuscate]
    [SmartAssembly.Attributes.DoNotObfuscateType]
    [SmartAssembly.Attributes.DoNotObfuscateControlFlow]
    public class MediaStoreResponse
    {
        public bool Status { get { if (status != null && status.ToLower() == "success") return true; else return false; } }
        public string status;
        public string error_code;
        public string file_role;
        public string content_type;
        public string source_url;
        public string url;
        public string share_url;
        public string short_url;

        public string FileType
        {
            get
            {
                if (content_type.ToLower().StartsWith("image"))
                    return Localization.LanguageMgr.LM.GetText(Labels.Image);
                else if (content_type.ToLower().StartsWith("video"))
                    return Localization.LanguageMgr.LM.GetText(Labels.Video);
                else if (content_type.ToLower().StartsWith("text"))
                    return Localization.LanguageMgr.LM.GetText(Labels.TextType);
                else
                    return Localization.LanguageMgr.LM.GetText(Labels.File);
            }
        }
    }
    /*
     * status': 'success',
'error_code': 'authentication_failed',
'error_message': 'Error during adding file to GS'
'file_role': 'screenshot',
'content_type': 'image/png',
'source_url': 'Total Commander 7.50a - Skype Technologies OÜ ',
'url':
     */

}
