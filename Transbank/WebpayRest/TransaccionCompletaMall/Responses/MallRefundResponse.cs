using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Responses
{
    public class MallRefundResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        
        [JsonProperty("authorization_date")]
        public string AuthorizationDate { get; set; }
        
        [JsonProperty("nullified_amount")]
        public double NullifiedAmount { get; set; }
        
        [JsonProperty("balance")]
        public double Balance { get; set; }
        
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }

        public MallRefundResponse(
            string type,
            string authorizationCode,
            string authorizationDate,
            double nullifiedAmount,
            double balance,
            int responseCode)
        {
            Type = type;
            AuthorizationCode = authorizationCode;
            AuthorizationDate = authorizationDate;
            NullifiedAmount = nullifiedAmount;
            Balance = balance;
            ResponseCode = responseCode;
        }

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
