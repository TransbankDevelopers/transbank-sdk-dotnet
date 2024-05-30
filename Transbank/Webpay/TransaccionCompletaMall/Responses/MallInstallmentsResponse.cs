using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.TransaccionCompletaMall.Common;
    
namespace Transbank.Webpay.TransaccionCompletaMall.Responses
{
    public class MallInstallmentsResponse : BaseResponse
    {
        [JsonProperty("installments_amount")]
        public decimal? InstallmentsAmount { get; set; }
        
        [JsonProperty("id_query_installments")]
        public int? IdQueryInstallments { get; set; }

        [JsonProperty("deferred_periods")]
        public List<DeferredPeriods> DeferredPeriods { get; set; }
        
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
