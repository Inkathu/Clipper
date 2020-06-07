using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RembyClipper2.Web
{
    [Serializable]
    public class LoginResponse
    {
        public string username { get; set; }
        public int storagesizelimit { get; set; }
        public string subscription_name { get; set; }
        public string session { get; set; }
        public string name { get; set; }
        public int filesizelimit { get; set; }
        public int userid { get; set; }
        public string email { get; set; }
        public string subscription { get; set; }
    }
}
