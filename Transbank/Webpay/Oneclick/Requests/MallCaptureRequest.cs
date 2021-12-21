using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Requests
{
    public class MallCaptureRequest : BaseRequest
    {
        [JsonProperty("commerce_code")]
        internal long CommerceCode { get; set; }

        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }

        [JsonProperty("capture_amount")]
        internal decimal Amount { get; set; }

        [JsonProperty("authorization_code")]
        internal string AuthorizationCode { get; set; }

        public MallCaptureRequest(long comerceCode, string buyOrder, decimal amount, string authorizationCode)
            : base($"{ApiConstants.ONECLICK_METHOD}/transactions/capture", HttpMethod.Put)
        {
            CommerceCode = comerceCode;
            BuyOrder = buyOrder;
            Amount = amount;
            AuthorizationCode = authorizationCode;
        }
    }
}
