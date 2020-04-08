using Newtonsoft.Json;
using Transbank.Exceptions;

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
            if (amount % 1 != 0)
            {
                throw new InvalidAmountException(InvalidAmountException.HAS_DECIMALS_MESSAGE);
            }
            Amount = amount;
            Period = period;
        }

        public override string ToString()
        {
            return $"Amount={Amount}\n" +
                   $"Period={Period}";
        }
    }
}
