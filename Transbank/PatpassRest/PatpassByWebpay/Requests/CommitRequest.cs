using System;
using System.Net.Http;
using Transbank.Common;

namespace Transbank.Patpass.PatpassByWebpay.Requests
{
    internal class CommitRequest : BaseRequest
    {
        internal CommitRequest(string token)
            : base($"/rswebpaytransaction/api/webpay/v1.0/transactions/{token}", HttpMethod.Put) {}
    }
}
