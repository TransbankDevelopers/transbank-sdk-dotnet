using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Common
{
    public class MallInstallmentsDetails
    {
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; }
        
        [JsonProperty("installments_number")]
        public int InstallmentsNumber { get; }

        public MallInstallmentsDetails(
            string commerceCode,
            string buyOrder,
            int installmentsNumber)
        {
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
            InstallmentsNumber = installmentsNumber;
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
