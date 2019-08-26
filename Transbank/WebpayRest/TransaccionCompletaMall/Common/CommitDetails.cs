using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Common
{
    public class CommitDetails
    {
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; }
        
        [JsonProperty("id_query_installments")]
        public int IdQueryInstallments { get; }
        
        [JsonProperty("deferred_period_index")]
        public int DeferredPeriodIndex { get; }
        
        [JsonProperty("grace_period")]
        public int GracePeriod { get; }

        public CommitDetails(
            string commerceCode,
            string buyOrder,
            int idQueryInstallments,
            int deferredPeriodIndex,
            int gracePeriod)
        {
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
            IdQueryInstallments = idQueryInstallments;
            DeferredPeriodIndex = deferredPeriodIndex;
            GracePeriod = gracePeriod;
        }
    }
}
