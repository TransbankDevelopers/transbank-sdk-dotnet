using System;
using System.Net.Http;

namespace Transbank.Webpay.Oneclick.Requests
{
    [Obsolete("Use MallStartRequest instead", false)]
    internal class StartRequest : MallStartRequest
    {

        internal StartRequest(string userName, string email, string responseUrl)
            : base(userName, email, responseUrl) { }
    }
}
