using Newtonsoft.Json;

namespace Transbank.Webpay.Common
{
    public class PaymentRequest
    {
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; private set; }

        [JsonProperty("buy_order")]
        public string BuyOrder { get; private set; }

        [JsonProperty("amount")]
        public decimal Amount { get; private set; }

        [JsonProperty("installments_number")]
        public int InstallmentsNumber { get; private set; }

        public PaymentRequest (string commerceCode, string buyOrder, decimal amount, int installmentsNumber)
        {
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
            Amount = amount;
            InstallmentsNumber = installmentsNumber;
        }

        public override string ToString()
        {
            return $"Commerce Code= {CommerceCode}\n" +
                $"Buy Order= {BuyOrder}\n" +
                $"Amount= {Amount}\n" +
                $"InstallmentsNumber= {InstallmentsNumber}\n";
        }
    }
}
