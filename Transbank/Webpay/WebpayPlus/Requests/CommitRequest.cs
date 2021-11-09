using System;
using System.Net.Http;
using Transbank.Common;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    internal class CommitRequest : BaseRequest
    {
        internal CommitRequest(string token)
            : base($"{ApiConstant.WEBPAY_METHOD}/transactions/{token}", HttpMethod.Put) {}
    }
}
