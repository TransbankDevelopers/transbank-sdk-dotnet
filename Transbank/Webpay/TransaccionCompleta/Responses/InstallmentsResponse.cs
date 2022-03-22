using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.TransaccionCompleta.Common;

namespace Transbank.Webpay.TransaccionCompleta.Responses
{
    public class InstallmentsResponse : BaseResponse
    {
        [JsonProperty("installments_amount")]
        public decimal? InstallmentsAmount { get; set; }
        
        [JsonProperty("id_query_installments")]
        public int? IdQueryInstallments { get; set; }

        [JsonProperty("deferred_periods")]
        public List<DeferredPeriods> DeferredPeriods { get; set; }
        
        public override string ToString()
        {
            string deferred = "";
            DeferredPeriods.ForEach(i => deferred += "{\n" + i.ToString() + "}\n");
            return $"\"InstallmentsAmount\":\"{InstallmentsAmount}\"\n" +
                   $"\"IdQueryInstallments\":\"{IdQueryInstallments}\"\n" +
                   "DeferredPeriods=\n{\n" + deferred + "}\n";

        }
    }
}
