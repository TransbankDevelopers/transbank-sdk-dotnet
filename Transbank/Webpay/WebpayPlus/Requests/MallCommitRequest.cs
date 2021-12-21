using System;
using System.Net.Http;
using Transbank.Common;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    public class MallCommitRequest : BaseRequest
    {
        public MallCommitRequest(string token) :
            base($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}", HttpMethod.Put) { }
    }
}
