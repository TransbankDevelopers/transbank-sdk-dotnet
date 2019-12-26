using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Webpay.TransaccionCompleta.Common;

namespace Transbank.Webpay.TransaccionCompleta.Responses
{
    public class InstallmentsResponse
    {
        [JsonProperty("installments_amount")]
        public int InstallmentsAmount { get; set; }
        
        [JsonProperty("id_query_installments")]
        public int IdQueryInstallments { get; set; }

        [JsonProperty("deferred_periods")]
        public List<DeferredPeriods> DeferredPeriods { get; set; }

        public InstallmentsResponse(int installmentsAmount, int idQueryInstallments, List<DeferredPeriods> deferredPeriods)
        {
            InstallmentsAmount = installmentsAmount;
            IdQueryInstallments = idQueryInstallments;
            DeferredPeriods = deferredPeriods;
        }
        
        public override string ToString()
        {
            return $"\"InstallmentsAmount\":\"{InstallmentsAmount}\"\n" +
                   $"\"IdQueryInstallments\":\"{IdQueryInstallments}\"\n" +
                   $"\"DeferredPeriods\":\"{DeferredPeriods.ToString()}\"";
        }
    }
}
