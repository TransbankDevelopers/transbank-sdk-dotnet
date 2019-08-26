using Newtonsoft.Json;

namespace Transbank.Webpay.Common
{
    public class PaymentResponse
    {
        [JsonProperty("authorization_code")]
        public int AuthorizationCode { get; private set; }

        [JsonProperty("payment_type_code")]
        public string PaymentTypeCode { get; private set; }

        [JsonProperty("response_code")]
        public int ResponseCode { get; private set; }

        [JsonProperty("installments_number")]
        public int InstallmentsNumber { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }
        
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; private set; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; private set; }
        
        [JsonProperty("amount")]
        public decimal Amount { get; private set; }

        public PaymentResponse (string comerceCode, string buyOrder, int ammount, int autorizationCode,
            string paymentTypeCode, int responseCode, int installmentsAmmount, string status)
        {
            AuthorizationCode = autorizationCode;
            PaymentTypeCode = paymentTypeCode;
            ResponseCode = responseCode;
            InstallmentsNumber = installmentsAmmount;
            Status = status;
            CommerceCode = comerceCode;
            BuyOrder = buyOrder;
            Amount = ammount;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                   $"InstallmentsAmount= {InstallmentsNumber}\n" +
                   $"AuthorizationCode= {AuthorizationCode}\n" +
                   $"PaymentTypeCode= {PaymentTypeCode}\n" +
                   $"ResponseCode= {ResponseCode}\n" +
                   $"Status= {Status}\n" +
                   $"CommerceCode= {CommerceCode}\n" +
                   $"BuyOrder= {BuyOrder}\n" +
                   $"Amount= {Amount}\n";
        }
    }
}
