using System;
using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    internal class CaptureRequest : BaseRequest
    {
        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }

        [JsonProperty("authorization_code")]
        internal string AuthorizationCode { get; set; }

        [JsonProperty("capture_amount")]
        internal decimal CaptureAmount { get; set; }

        internal CaptureRequest(string token, string buyOrder, string authorizationCode,
            decimal captureAmount) :
            base($"{ApiConstant.WEBPAY_METHOD}/transactions/{token}/capture", HttpMethod.Put)
        {
            BuyOrder = buyOrder;
            AuthorizationCode = authorizationCode;
            CaptureAmount = captureAmount;
        }
    }
}


