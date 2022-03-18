using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Common
{
    public class MallCommitDetails
    {
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; set; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        
        [JsonProperty("id_query_installments")]
        public int IdQueryInstallments { get; set; }
        
        [JsonProperty("deferred_period_index")]
        public int DeferredPeriodIndex { get; set; }
        
        [JsonProperty("grace_period")]
        public bool GracePeriod { get; set; }

        public MallCommitDetails(
            string commerceCode,
            string buyOrder,
            int idQueryInstallments,
            int deferredPeriodIndex,
            bool gracePeriod)
        {
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
            IdQueryInstallments = idQueryInstallments;
            DeferredPeriodIndex = deferredPeriodIndex;
            GracePeriod = gracePeriod;
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
