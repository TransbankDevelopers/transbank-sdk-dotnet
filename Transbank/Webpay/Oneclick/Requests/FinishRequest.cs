using System;

namespace Transbank.Webpay.Oneclick.Requests
{
    [Obsolete("Use MallFinishRequest instead", false)]
    internal class FinishRequest : MallFinishRequest
    {
        internal FinishRequest(string token)
            : base(token) { }
    }
}
