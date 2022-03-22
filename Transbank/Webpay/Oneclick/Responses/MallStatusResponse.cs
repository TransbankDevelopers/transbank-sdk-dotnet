using System;
using Newtonsoft.Json;
using System.ComponentModel;
using Transbank.Webpay.Common;
using System.Collections.Generic;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class MallStatusResponse : BaseResponse
    {
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        
        [JsonProperty("card_detail")]
        public CardDetail CardDetail { get; set; }
        
        [JsonProperty("accounting_date")]
        public string AccountingDate { get; set; }
        
        [JsonProperty("transaction_date")]
        public DateTime? TransactionDate { get; set; }

        [JsonProperty("details")]
        public List<PaymentResponse> Details { get; set; }

        public override string ToString()
        {
            var details = "";
            Details.ForEach(i => details += "{\n"+ i.ToString() + "\n}\n");
            return $"\"BuyOrder\": \"{BuyOrder}\"\n" +
                   $"\"AccountingDate\": \"{AccountingDate}\"\n" +
                   $"\"TransactionDate\": \"{TransactionDate}\"\n" +
                   "\"Details\":\n{\n\t" + details + "\n}\n";
        }
  
        public class Detail
        {
            [JsonProperty("amount")]
            public decimal? Amount { get; set; }
            
            [JsonProperty("status")]
            public string Status { get; set; }
            
            [JsonProperty("authorization_code")]
            public string AuthorizationCode { get; set; }
            
            [JsonProperty("payment_type_code")]
            public string PaymentTypeCode { get; set; }
            
            [JsonProperty("response_code")]
            public int? ResponseCode { get; set; }
            
            [JsonProperty("installments_number")]
            public int? InstallmentsNumber { get; set; }
            
            [JsonProperty("commerce_code")]
            public string CommerceCode { get; set; }
            
            [JsonProperty("buy_order")]
            public string BuyOrder { get; set; }
            [JsonProperty("installments_amount")]
            public decimal? InstallmentsAmount { get; set; }
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
}
