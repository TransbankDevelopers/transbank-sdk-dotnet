using System;
using Newtonsoft.Json;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Oneclick.Responses
{
    [Obsolete("Use MallStart Instead",false)]
    public class StartResponse : MallStartResponse {

        public StartResponse(string token, string url) : base(token, url) { }

    }
}
