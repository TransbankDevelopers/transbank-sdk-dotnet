using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Common
{
    public class CommitResponseDetails
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        
        [JsonProperty("payment_type_code")]
        public string PaymentTypeCode { get; set; }
        
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }
        
        [JsonProperty("installments_amount")]
        public decimal InstallmentsAmount { get; set; }
        
        [JsonProperty("installments_number")]
        public int InstallmentsNumber { get; set; }
        
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; set; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        [JsonProperty("balance")]
        public decimal Balance { get; set; }
        [JsonProperty("capture_expiration_date")]
        public DateTime? CaptureExpirationDate;


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
