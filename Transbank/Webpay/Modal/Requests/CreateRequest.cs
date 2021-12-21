using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.Webpay.Modal.Requests
{
    internal class CreateRequest : BaseRequest
    {
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return $"BuyOrder={BuyOrder}, SessionId={SessionId}, " +
                $"Amount={Amount}";
        }

        internal CreateRequest(string buyOrder, string sessionId, decimal amount)
            : base($"{ApiConstants.WEBPAY_METHOD}/transactions", HttpMethod.Post)
        {
            BuyOrder = buyOrder;
            SessionId = sessionId;
            Amount = amount;
        }
    }
}
