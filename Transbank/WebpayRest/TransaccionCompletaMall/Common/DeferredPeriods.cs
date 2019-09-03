using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Common
{
    public class DeferredPeriods
    {
        [JsonProperty("amount")]
        internal int Amount { get; }
        
        [JsonProperty("period")]
        internal int Period { get; }

        public DeferredPeriods(int amount, int period)
        {
            Amount= amount;
            Period = period;
        }
    }
}
