using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Requests
{
    internal class ReversePreAuthorizedAmountRequest : BaseRequest
    {
        [JsonProperty("commerce_code")]
        internal string CommerceCode { get; set; }
        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }

        [JsonProperty("authorization_code")]
        internal string AuthorizationCode { get; set; }

        [JsonProperty("amount")]
        internal decimal Amount { get; set; }
        internal ReversePreAuthorizedAmountRequest(string endpoint, string commerceCode, string buyOrder, string authorizationCode,
            decimal amount) :
            base(endpoint, HttpMethod.Put)
        {
            BuyOrder = buyOrder;
            AuthorizationCode = authorizationCode;
            Amount = amount;
            CommerceCode = commerceCode;
        }
    }
    

}
