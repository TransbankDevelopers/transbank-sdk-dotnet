using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Requests
{
    internal class IncreaseAuthorizationDateRequest : BaseRequest
    {
        [JsonProperty("commerce_code")]
        internal string CommerceCode { get; set; }
        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }
        [JsonProperty("authorization_code")]
        internal string AuthorizationCode { get; set; }
        internal IncreaseAuthorizationDateRequest(string endpoint, string commerceCode, string buyOrder, string authorizationCode) :
            base(endpoint, HttpMethod.Put)
        {
            BuyOrder = buyOrder;
            AuthorizationCode = authorizationCode;
            CommerceCode = commerceCode;
        }
    }
}

