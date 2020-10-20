using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompleta.Common
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

        public override string ToString()
        {
            return $"Amount={Amount}\n" +
                   $"Period={Period}\n";
        }
    }
}
