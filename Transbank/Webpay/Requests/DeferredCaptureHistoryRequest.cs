using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Requests
{
    internal class DeferredCaptureHistoryRequest : BaseRequest
    {
        [JsonProperty("commerce_code")]
        internal string CommerceCode { get; set; }
        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }
        [JsonProperty("authorization_code", NullValueHandling = NullValueHandling.Ignore)]
        internal string AuthorizationCode { get; set; }
        internal DeferredCaptureHistoryRequest(string endpoint, string commerceCode, string buyOrder, string authorizationCode = null) :
            base(endpoint, HttpMethod.Post)
        {
            BuyOrder = buyOrder;
            AuthorizationCode = authorizationCode;
            CommerceCode = commerceCode;
        }
        internal DeferredCaptureHistoryRequest(string endpoint)
                    : base(endpoint, HttpMethod.Get) { }

    }
}
