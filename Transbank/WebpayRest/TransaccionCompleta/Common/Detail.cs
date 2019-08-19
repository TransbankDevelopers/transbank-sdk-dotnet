using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompleta.Common
{
    public class Detail
    {
        [JsonProperty("amount")]
        internal int Amount { get; }
        
        [JsonProperty("commerce_code")]
        internal int CommerceCode { get; }
        
        [JsonProperty("buy_order")]
        internal string BuyOrder { get; }

        public Detail(
            int amount,
            int commerceCode,
            string buyOrder)
        {
            Amount = amount;
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
        }
    }
}
