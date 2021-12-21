using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.TransaccionCompleta.Requests
{
    public class RefundRequest : BaseRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        public RefundRequest(string token, decimal amount) : base($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}/refunds", HttpMethod.Post)
        {
            Amount = amount;
        }
    }
}    
