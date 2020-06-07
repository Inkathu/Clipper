using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using RembyClipper.Helpers;
using System.Net;
using RembyClipper2.Config;
using RembyClipper2.Helpers;
using RembyClipper2.Utils;

namespace RembyClipper2.Paid
{
    internal sealed class Subscription
    {
        private XmlDocument xml = new XmlDocument();

        private List<string> accountTypes = new List<string>();
        private Dictionary<string, string> accountRestrictions = new Dictionary<string, string>();


        public Subscription()
        {

        }

        internal void loadXML()
        {
            CookieAwareWebClient wc = new CookieAwareWebClient(RembyServices.LoginCookieContainer);
            wc.Encoding = Encoding.UTF8;
            string _xml = wc.DownloadString(RembyConstants.RembyURL + "/user-config-ex?secu=" + RembyServices.securityID);
            /*string _xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<subscription>
	<user>tamashenning</user>
	<account type=""plus"" />
	<account type=""premium_storage"" />
	<account type=""unlimited_video"" />
	<default>
		<restriction variable=""watermark_screenshot"" value=""true"" />
		<restriction variable=""watermark_screenvideo"" value=""true"" />
		<restriction variable=""watermark_pdf"" value=""true"" />
		<restriction variable=""max_page_per_month"" value=""500"" />
		<restriction variable=""max_page_size"" value=""512000"" />
		<restriction variable=""max_video_length"" value=""900"" />
		<restriction variable=""max_size_storage_default"" value=""512000"" />
		<restriction variable=""max_number_storage_default"" value=""100"" />
		<restriction variable=""max_number_storage_video"" value=""0"" />
		<restriction variable=""max_number_storage_text"" value=""-1"" />
		<restriction variable=""max_number_storage_image"" value=""-1"" />
		<restriction variable=""sell_book"" value=""false"" />
		<restriction variable=""show_ads"" value=""true"" />
		<restriction variable=""phone_support"" value=""false"" />
		<restriction variable=""can_print"" value=""true"" />
	</default>
	<plus>
		<restriction variable=""watermark_screenshot"" value=""false"" />
		<restriction variable=""watermark_screenvideo"" value=""false"" />
		<restriction variable=""watermark_pdf"" value=""false"" />
		<restriction variable=""max_number_storage_video"" value=""10"" />	
	</plus>
	<premium_storage>
		<restriction variable=""max_number_storage_default"" value=""5000"" />
		<restriction variable=""max_number_storage_video"" value=""50"" />
	</premium_storage>
	<unlimited_video>
		<restriction variable=""max_video_length"" value=""-1"" />
	</unlimited_video>
</subscription>";*/

            this.xml.LoadXml(_xml);

            XmlNodeList t = xml.GetElementsByTagName("subscription");
            if (t.Count != 1)
            {
                DebugHelper.Error("Something is wrong with the account XML");
                return;
            }
            
            /*
            t[0].SelectNodes("account")[0].Attributes[0].Value	"plus"	string
		    t[0].SelectNodes("plus/restriction").Count	4	int
            */

            foreach (XmlNode node in t[0].SelectNodes("default/restriction"))
                accountRestrictions.Add(node.Attributes[0].Value, node.Attributes[1].Value);


            foreach (XmlNode accountNode in t[0].SelectNodes("account"))
            {
                accountTypes.Add(accountNode.Attributes[0].Value);
                foreach (XmlNode restrictionNode in t[0].SelectNodes(accountNode.Attributes[0].Value + "/restriction"))
                    accountRestrictions[restrictionNode.Attributes[0].Value] = restrictionNode.Attributes[1].Value;
            }

            foreach (string s in accountTypes)
                DebugHelper.Log(s);

            foreach (string s in accountRestrictions.Keys)
                DebugHelper.Log(s + " " + accountRestrictions[s]);

            if(accountTypes.Count > 0)
            {
                AppConfig.accountType = accountTypes[0];
            }
            AppConfig.Instance.subscriptionRestrictions = accountRestrictions;
            
            AppConfig.Instance.Store();
        }

        public string this[string index]
        {
            get
            {
                if (index.Equals("watermark_screenshot") && !AppConfig.Instance.subscriptionRestrictions.ContainsKey("watermark_screenshot"))
                {
                    return "1";
                }
                if (index.Equals("watermark_screenvideo") && !AppConfig.Instance.subscriptionRestrictions.ContainsKey("watermark_screenvideo"))
                {
                    return "1";
                }
                return AppConfig.Instance.subscriptionRestrictions[index];
            }
        }
    }
}
/*<?xml version="1.0" encoding="UTF-8"?><subscription>
  <user>tzador</user> 
  <account type="basic" />
<default>
	<restriction variable="watermark_screenshot" value="1" /> 
	<restriction variable="watermark_screenvideo" value="1" /> 
	<restriction variable="watermark_pdf" value="1" /> 
	<restriction variable="max_page_per_month" value="100" /> 
	<restriction variable="max_page_size" value="3072000" /> 
	<restriction variable="max_video_length" value="900" /> 
	<restriction variable="max_size_storage_default" value="512000" /> 
	<restriction variable="max_number_storage_default" value="100" /> 
	<restriction variable="max_number_storage_video" value="0" /> 
	<restriction variable="max_number_storage_text" value="-1" /> 
	<restriction variable="max_number_storage_image" value="-1" /> 
	<restriction variable="sell_book" value="0" /> 
	<restriction variable="show_ads" value="1" /> 
	<restriction variable="phone_support" value="0" /> 
	<restriction variable="can_print" value="1" /> 
</default>
<basic>
	<restriction variable="watermark_screenshot" value="0" /> 
	<restriction variable="watermark_screenvideo" value="0" /> 
	<restriction variable="watermark_pdf" value="0" /> 
	<restriction variable="max_page_per_month" value="1000" /> 
	<restriction variable="max_page_size" value="5120000" /> 
	<restriction variable="max_number_storage_video" value="10" /> 
	<restriction variable="sell_book" value="1" /> 
	<restriction variable="show_ads" value="0" /> 
</basic>
</subscription>*/