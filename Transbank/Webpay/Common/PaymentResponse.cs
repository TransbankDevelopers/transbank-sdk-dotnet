using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Webpay.Common
{
    public class PaymentResponse
    {
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; private set; }

        [JsonProperty("payment_type_code")]
        public string PaymentTypeCode { get; private set; }

        [JsonProperty("response_code")]
        public int? ResponseCode { get; private set; }

        [JsonProperty("installments_number")]
        public int? InstallmentsNumber { get; private set; }

        [JsonProperty("installments_amount")]
        public decimal? InstallmentsAmount { get; private set; }
      
        [JsonProperty("status")]
        public string Status { get; private set; }
        
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; private set; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; private set; }
        
        [JsonProperty("amount")]
        public decimal? Amount { get; private set; }

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
