using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    internal class CreateRequest : BaseRequest
    {
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }

        public override string ToString()
        {
            return $"BuyOrder={BuyOrder}, SessionId={SessionId}, " +
                $"Amount={Amount}, ReturnUrl={ReturnUrl}";
        }

        internal CreateRequest(string buyOrder, string sessionId, decimal amount, string returnUrl)
            : base($"{Constant.WEBPAY_METHOD}/transactions", HttpMethod.Post)
        {
            BuyOrder = buyOrder;
            SessionId = sessionId;
            Amount = amount;
            ReturnUrl = returnUrl;
        }
    }
}
