using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Common
{
    public class DeferredPeriods
    {
        [JsonProperty("amount")]
        internal decimal Amount { get; }
        
        [JsonProperty("period")]
        internal int Period { get; }

        public DeferredPeriods(decimal amount, int period)
        {
            Amount= amount;
            Period = period;
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
