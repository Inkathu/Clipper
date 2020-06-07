using System;
using System.Collections.Generic;
using System.Text;

namespace RembyClipper2.Helpers
{
    [SmartAssembly.Attributes.DoNotObfuscate]
    [SmartAssembly.Attributes.DoNotObfuscateType]
    [SmartAssembly.Attributes.DoNotObfuscateControlFlow]
    internal class GoogleShortResponse
    {
        //{ "kind": "urlshortener#url", "id": "http://goo.gl/WNAr5", "longUrl": "http://remby .commondatastorage.googleapis.com/tmp/tamashenning/media/screenshot/image/png/2011/01/000018524_557_436_ahFyZW1ieS1tZWRpYS1zdG9yZXIMCxIERmlsZRjipSUM.png"}
        public string kind = "";
        public string id = "";
        public string longUrl = "";
    }
}
