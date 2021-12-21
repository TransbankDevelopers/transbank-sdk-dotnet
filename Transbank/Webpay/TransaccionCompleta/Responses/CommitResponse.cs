using Newtonsoft.Json;
using Transbank.Webpay.TransaccionCompleta.Common;

namespace Transbank.Webpay.TransaccionCompleta.Responses
{
    public class CommitResponse
    {
        [JsonProperty("amount")]
        public int Amount { get; private set; }
        
        [JsonProperty("status")]
        public string Status { get; private set; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; private set; }
        
        [JsonProperty("session_id")]
        public string SessionId { get; private set; }
        
        [JsonProperty("card_detail")]
        public CardDetail CardDetail { get; private set; }
        
        [JsonProperty("accounting_date")]
        public string AccountingDate { get; private set; }
        
        [JsonProperty("transaction_date")]
        public string TransactionDate { get; private set; }
        
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; private set; }
        
        [JsonProperty("payment_type_code")]
        public string PaymentTypeCode { get; private set; }
        
        [JsonProperty("response_code")]
        public int ResponseCode { get; private set; }
        
        [JsonProperty("installments_amount")]
        public int InstallmentsAmount { get; private set; }
        
        [JsonProperty("installments_number")]
        public int InstallmentsNumber { get; private set; }
        [JsonProperty("prepaid_balance")]
        public decimal prepaidBalance { get; set; }

        public CommitResponse(int amount, string status, string buyOrder, string sessionId, CardDetail cardDetail, string accountingDate, string transactionDate, string authorizationCode, string paymentTypeCode, int responseCode, int installmentsAmount, int installmentsNumber)
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
        }

        public override string ToString()
        {
            return $"\"Amount\":\"{Amount}\"\n" +
                   $"\"Status\":\"{Status}\"\n" +
                   $"\"BuyOrder\":\"{BuyOrder}\"\n" +
                   $"\"SessionId\":\"{SessionId}\"\n" +
                   "Card Detail=\n{\n" + CardDetail.ToString() + "}\n" +
                   $"\"AccountingDate\":\"{AccountingDate}\"\n" +
                   $"\"TransactionDate\":\"{TransactionDate}\"\n" +
                   $"\"AuthorizationCode\":\"{AuthorizationCode}\"\n" +
                   $"\"PaymentTypeCode:\"{PaymentTypeCode}\"\n" +
                   $"\"ResponseCode\":\"{ResponseCode}\"\n" +
                   $"\"InstallmentsAmount\":\"{InstallmentsAmount}\"\n" +
                   $"\"InstallmentsNumber\":\"{InstallmentsNumber}\"\n";
        }

    }
}
