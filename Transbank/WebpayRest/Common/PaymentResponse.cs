using Newtonsoft.Json;

namespace Transbank.Webpay.Common
{
    public class PaymentResponse : PaymentRequest
    {
        [JsonProperty("authorization_code")]
        public int AuthorizationCode { get; private set; }

        [JsonProperty("payment_type_code")]
        public string PaymentTypeCode { get; private set; }

        [JsonProperty("response_code")]
        public int ResponseCode { get; private set; }

        [JsonProperty("installments_amount")]
        public int InstallmentsAmount { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }

        public PaymentResponse (string comerceCode, string buyOrder, int ammount, int autorizationCode,
            string paymentTypeCode, int responseCode, int installmentsAmmount, string status) : base(comerceCode, buyOrder, ammount)
        {
            AuthorizationCode = autorizationCode;
            PaymentTypeCode = paymentTypeCode;
            ResponseCode = responseCode;
            InstallmentsAmount = installmentsAmmount;
            Status = status;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                $"InstallmentsAmount= {InstallmentsAmount}\n" +
                $"AuthorizationCode= {AuthorizationCode}\n" +
                $"PaymentTypeCode= {PaymentTypeCode}\n" +
                $"ResponseCode= {ResponseCode}\n" +
                $"Status= {Status}\n";
        }
    }
}
