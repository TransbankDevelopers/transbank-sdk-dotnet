using System;
using System.Net.Http;
using Transbank.Common;

namespace Transbank.Patpass.PatpassByWebpay.Requests
{
    internal class CommitRequest : BaseRequest
    {
        internal CommitRequest(string token)
            : base($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}", HttpMethod.Put) {}
    }
}
