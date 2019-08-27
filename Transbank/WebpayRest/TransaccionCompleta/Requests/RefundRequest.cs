using System.Net.Http;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.TransaccionCompleta.Requests
{
    public class RefundRequest : BaseRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        public RefundRequest(string token, int amount) : base($"/rswebpaytransaction/api/webpay/v1.0/transactions/{token}/refunds", HttpMethod.Post)
        {
            Amount = amount;
        }
    }
}
