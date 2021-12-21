using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.Webpay.TransaccionCompleta.Requests
{
    internal class CommitRequest : BaseRequest
    {
        [JsonProperty("id_query_installments")]
        public int IdQueryInstallments { get; set; }
        
        [JsonProperty("deferred_period_index")]
        public int DeferredPeriodIndex { get; set; }
        
        [JsonProperty("grace_period")]
        public bool GracePeriod { get; set; }

        internal CommitRequest(string token,
            int idQueryInstallments,
            int deferredPeriodIndex,
            bool gracePeriod)
            : base($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}", HttpMethod.Put)
        {
            IdQueryInstallments = idQueryInstallments;
            DeferredPeriodIndex = deferredPeriodIndex;
            GracePeriod = gracePeriod;
        }
    }
}
