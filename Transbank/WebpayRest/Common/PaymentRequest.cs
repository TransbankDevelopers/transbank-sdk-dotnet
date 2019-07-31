using Newtonsoft.Json;

namespace Transbank.Webpay.Common
{
    public class PaymentRequest
    {
        [JsonProperty("commerce_code")]
        public string ComerceCode { get; private set; }

        [JsonProperty("buy_order")]
        public string BuyOrder { get; private set; }

        [JsonProperty("amount")]
        public int Amount { get; private set; }

        [JsonProperty("installments_number")]
        public int Installments { get; private set; }

        public PaymentRequest (string comerceCode, string buyOrder, int amount)
        {
            ComerceCode = comerceCode;
            BuyOrder = buyOrder;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"Comerce Code= {ComerceCode}\n" +
                $"Buy Order= {BuyOrder}\n" +
                $"Amount= {Amount}\n" +
                $"Installments= {Installments}";
        }
    }
}