using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompleta.Responses
{
    public class CaptureResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        [JsonProperty("authorization_date")]
        public DateTime AuthorizationDate { get; set; }
        [JsonProperty("captured_amount")]
        public decimal CapturedAmount { get; set; }
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
