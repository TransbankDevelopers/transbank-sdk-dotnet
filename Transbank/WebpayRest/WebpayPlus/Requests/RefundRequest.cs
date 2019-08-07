using System;
using Transbank.Common;
using Newtonsoft.Json;
using System.Net.Http;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    internal class RefundRequest : BaseRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

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
