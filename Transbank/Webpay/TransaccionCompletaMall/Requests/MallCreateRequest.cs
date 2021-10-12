using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.TransaccionCompletaMall.Common;

namespace Transbank.Webpay.TransaccionCompletaMall.Requests
{
    internal class MallCreateRequest : BaseRequest
    {
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
        
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }
        
        [JsonProperty("card_expiration_date")]
        public string CardExpirationDate { get; set; }
        
        [JsonProperty("details")]
        public List<CreateDetails> Details { get; set; }

        internal MallCreateRequest(string buyOrder,
            string sessionId,
            string cardNumber,
            string cardExpirationDate,
            List<CreateDetails> details)
        : base($"{Constant.WEBPAY_METHOD}/transactions", HttpMethod.Post)
        {
            BuyOrder = buyOrder;
            SessionId = sessionId;
            CardNumber = cardNumber;
            CardExpirationDate = cardExpirationDate;
            Details = details;
        }
    }
}
