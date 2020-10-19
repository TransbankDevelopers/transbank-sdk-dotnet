using System;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    public class MallStatusRequest : StatusRequest
    {
        internal MallStatusRequest(string token) : base(token) { }
    }
}
