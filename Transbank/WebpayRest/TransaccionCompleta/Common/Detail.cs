using Newtonsoft.Json;
using Transbank.Exceptions;

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
            if (amount % 1 != 0)
            {
                throw new InvalidAmountException(InvalidAmountException.HAS_DECIMALS_MESSAGE);
            }
            Amount = amount;
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
        }

        public override string ToString()
        {
            return $"Amount={Amount}\n" +
                   $"CommerceCode={CommerceCode}\n" +
                   $"BuyOrder={BuyOrder}";
        }
    }
}
