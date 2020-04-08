using System;
using Transbank.Common;
using Newtonsoft.Json;
using System.Net.Http;
using Transbank.Exceptions;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    internal class RefundRequest : BaseRequest
    {
        private decimal _amount;

        [JsonProperty("amount")]
        public decimal Amount {
            get { return this._amount; }
            set
            {
                if (value % 1 != 0)
                {
                    throw new InvalidAmountException(InvalidAmountException.HAS_DECIMALS_MESSAGE);
                }
                this._amount = value;
            }
        }

        public override string ToString()
        {
            return $"Amount={Amount}";
        }

        internal RefundRequest(string token, decimal amount)
            : base($"/rswebpaytransaction/api/webpay/v1.0/transactions/{token}/refunds", HttpMethod.Post)
        {
            Amount = amount;
        }
    }
}
