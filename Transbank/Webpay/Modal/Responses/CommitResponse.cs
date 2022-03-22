using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Modal.Responses
{
    public class CommitResponse : BaseResponse
    {
        [JsonProperty("vci")]
        public string Vci { get; set; }
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
        [JsonProperty("card_detail")]
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
            var properties = new List<string>();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(this);
                properties.Add($"{name}={value}");
            }
            return String.Join(",\n", properties);
        }
    }
}
