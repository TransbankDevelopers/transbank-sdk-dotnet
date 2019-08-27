using Newtonsoft.Json;
using Transbank.Webpay.TransaccionCompleta.Common;

namespace Transbank.Webpay.TransaccionCompleta.Responses
{
    public class StatusResponse
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
        
        [JsonProperty("card_details")]
        public CardDetail CardDetail { get; set; }
        
        [JsonProperty("accounting_date")]
        public string AccountingDate { get; set; }
        
        [JsonProperty("transaction_date")]
        public string TransactionDate { get; set; }
        
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        
        [JsonProperty("payment_type_code")]
        public string PaymentTypeCode { get; set; }
        
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }
        
        [JsonProperty("installments_amount")]
        public int InstallmentsAmount { get; set; }
        
        [JsonProperty("installments_number")]
        public int InstallmentsNumber { get; set; }

        public StatusResponse(int amount, string status, string buyOrder, string sessionId, CardDetail cardDetail, string accountingDate, string transactionDate, string authorizationCode, string paymentTypeCode, int responseCode, int installmentsAmount, int installmentsNumber)
        {
            Amount = amount;
            Status = status;
            BuyOrder = buyOrder;
            SessionId = sessionId;
            CardDetail = cardDetail;
            AccountingDate = accountingDate;
            TransactionDate = transactionDate;
            AuthorizationCode = authorizationCode;
            PaymentTypeCode = paymentTypeCode;
            ResponseCode = responseCode;
            InstallmentsAmount = installmentsAmount;
            InstallmentsNumber = installmentsNumber;
        }

        public override string ToString()
        {
            return $"Amount={Amount}\n" +
                   $"Status={Status}\n" +
                   $"BuyOrder={BuyOrder}\n" +
                   $"SessionId={SessionId}\n" +
                   $"CardDetail={CardDetail}\n" +
                   $"AccountingDate={AccountingDate}\n" +
                   $"TransactionDate={TransactionDate}\n" +
                   $"AuthorizationCode={AuthorizationCode}\n" +
                   $"PaymentTypeCode={PaymentTypeCode}\n" +
                   $"ResponseCode={ResponseCode}\n" +
                   $"InstallmentsAmount={InstallmentsAmount}\n" +
                   $"InstallmentsAmount={InstallmentsAmount}\n";
        }
    }
}
