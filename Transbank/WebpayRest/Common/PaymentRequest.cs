using Newtonsoft.Json;
using Transbank.Exceptions;

namespace Transbank.Webpay.Common
{
    public class PaymentRequest
    {
        private decimal _amount;
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; private set; }

        [JsonProperty("buy_order")]
        public string BuyOrder { get; private set; }

        [JsonProperty("amount")]
        public decimal Amount {
            get { return this._amount; }
            private set
            {
                if (value % 1 != 0)
                {
                    throw new InvalidAmountException(InvalidAmountException.HAS_DECIMALS_MESSAGE);
                }
                this._amount = value;
            }
        }

        [JsonProperty("installments_number")]
        public int InstallmentsNumber { get; private set; }

        public PaymentRequest (string commerceCode, string buyOrder, decimal amount, int installmentsNumber)
        {
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
            Amount = amount;
            InstallmentsNumber = installmentsNumber;
        }

        public override string ToString()
        {
            return $"Commerce Code= {CommerceCode}\n" +
                $"Buy Order= {BuyOrder}\n" +
                $"Amount= {Amount}\n" +
                $"InstallmentsNumber= {InstallmentsNumber}";
        }
    }
}
