using System;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.TransaccionCompleta.Common;

namespace Transbank.Webpay.TransaccionCompleta.Responses
{
    public class StatusResponse : BaseResponse
    {
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }
        
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
        public DateTime? TransactionDate { get; set; }
        
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        
        [JsonProperty("payment_type_code")]
        public string PaymentTypeCode { get; set; }
        
        [JsonProperty("response_code")]
        public int? ResponseCode { get; set; }
        
        [JsonProperty("installments_amount")]
        public decimal? InstallmentsAmount { get; set; }
        
        [JsonProperty("installments_number")]
        public int? InstallmentsNumber { get; set; }
        [JsonProperty("balance")]
        public decimal? Balance { get; set; }

        public override string ToString()
        {
            return $"\"Amount\":\"{Amount}\"\n" +
                   $"\"Status\":\"{Status}\"\n" +
                   $"\"BuyOrder\":\"{BuyOrder}\"\n" +
                   $"\"SessionId\":\"{SessionId}\"\n" +
                   $"\"CardDetail\":\"{CardDetail}\"\n" +
                   $"\"AccountingDate\":\"{AccountingDate}\"\n" +
                   $"\"TransactionDate\":\"{TransactionDate}\"\n" +
                   $"\"AuthorizationCode\":\"{AuthorizationCode}\"\n" +
                   $"\"PaymentTypeCode\":\"{PaymentTypeCode}\"\n" +
                   $"\"ResponseCode\":\"{ResponseCode}\"\n" +
                   $"\"InstallmentsAmount\":\"{InstallmentsAmount}\"\n" +
                   $"\"InstallmentsAmount\":\"{InstallmentsAmount}\"\n";
        }
    }
}
