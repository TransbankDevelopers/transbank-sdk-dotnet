using System;
using System.Net.Http;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    public class MallCommitRequest : BaseRequest
    {
        public MallCommitRequest(string token) :
            base($"/rswebpaytransaction/api/webpay/v1.0/transactions/{token}", HttpMethod.Put) { }
    }
}
