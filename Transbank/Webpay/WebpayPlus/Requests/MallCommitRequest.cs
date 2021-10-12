using System;
using System.Net.Http;
using Transbank.Common;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    public class MallCommitRequest : BaseRequest
    {
        public MallCommitRequest(string token) :
            base($"{Constant.WEBPAY_METHOD}/transactions/{token}", HttpMethod.Put) { }
    }
}
