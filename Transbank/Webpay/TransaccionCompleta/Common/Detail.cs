using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompleta.Common
{
    public class Detail
    {
        [JsonProperty("amount")]
        internal decimal Amount { get; }
        
        [JsonProperty("commerce_code")]
        internal int CommerceCode { get; }
        
        [JsonProperty("buy_order")]
        internal string BuyOrder { get; }

        public Detail(
            decimal amount,
            int commerceCode,
            string buyOrder)
        {
            Amount = amount;
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
        }

        public override string ToString()
        {
            return $"Amount={Amount}\n" +
                   $"CommerceCode={CommerceCode}\n" +
                   $"BuyOrder={BuyOrder}\n";
        }
    }
}
