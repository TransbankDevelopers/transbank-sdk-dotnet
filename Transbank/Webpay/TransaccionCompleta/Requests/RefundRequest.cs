using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.TransaccionCompleta.Requests
{
    public class RefundRequest : BaseRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        public RefundRequest(string token, int amount) : base($"{ApiConstant.WEBPAY_METHOD}/transactions/{token}/refunds", HttpMethod.Post)
        {
            Amount = amount;
        }
    }
}    
