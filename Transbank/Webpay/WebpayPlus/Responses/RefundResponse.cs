using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Webpay.WebpayPlus.Responses
{
    public class RefundResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        [JsonProperty("authorization_date")]
        public DateTime AuthorizationDate { get; set; }
        [JsonProperty("nullified_amount")]
        public decimal NullifiedAmount { get; set; }
        [JsonProperty("balance")]
        public decimal Balance { get; set; }
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }

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
