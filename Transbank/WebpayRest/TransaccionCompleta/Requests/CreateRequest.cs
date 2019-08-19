using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.Webpay.TransaccionCompleta.Requests
{
    public class CreateRequest : BaseRequest
    {
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
        
        [JsonProperty("amount")]
        public int Amount { get; set; }
        
        [JsonProperty("cvv")]
        public int Cvv { get; set; }
        
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }
        
        [JsonProperty("card_expiration_date")]
        public string CardExpirationDate { get; set; }
    
        internal CreateRequest(
            string buyOrder,
            string sessionId,
            int amount,
            int cvv,
            string cardNumber,
            string cardExpirationDate)
            : base(" /rswebpaytransaction/api/webpay/v1.0/transactions", HttpMethod.Post)
        {
            BuyOrder = buyOrder;
            SessionId = sessionId;
            Amount = amount;
            Cvv = cvv;
            CardNumber = cardNumber;
            CardExpirationDate = cardExpirationDate;
        }
    }
}
