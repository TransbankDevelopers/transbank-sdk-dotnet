using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Common
{
    public class CreateDetails
    {
        [JsonProperty("amount")]
        public decimal Amount { get; }
        
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; }

        public CreateDetails(
            decimal amount,
            string commerceCode,
            string buyOrder)
        {
            Amount = amount;
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
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
