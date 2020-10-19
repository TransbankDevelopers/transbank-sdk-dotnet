using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Common
{
    public class CreateDetails
    {
        [JsonProperty("amount")]
        public int Amount { get; }
        
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; }

        public CreateDetails(
            int amount,
            string commerceCode,
            string buyOrder)
        {
            Amount = amount;
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
        }
    }
}
