using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Common
{
    public class MallInstallmentsDetailsResponse
    {
        [JsonProperty("installments_amount")]
        public int InstallmentsAmount { get; set; }
        
        [JsonProperty("id_query_installments")]
        public int IdQueryInstallments { get; set; }

        [JsonProperty("deferred_periods")]
        public List<DeferredPeriods> DeferredPeriods { get; set; }

        public MallInstallmentsDetailsResponse(
            int installmentsAmount,
            int idQueryInstallments,
            List<DeferredPeriods> deferredPeriods
        )
        {
            InstallmentsAmount = installmentsAmount;
            IdQueryInstallments = idQueryInstallments;
            DeferredPeriods = deferredPeriods;
        }
    }
}
