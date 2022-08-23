using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Responses
{
    public class IncreaseAuthorizationDateResponse : BaseResponse
    {
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        [JsonProperty("authorization_date")]
        public DateTime AuthorizationDate { get; set; }
        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }
        [JsonProperty("expiration_date")]
        public DateTime ExpirationDate { get; set; }
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
