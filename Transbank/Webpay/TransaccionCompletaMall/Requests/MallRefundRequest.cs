using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.Webpay.TransaccionCompletaMall.Requests
{
    internal class MallRefundRequest : BaseRequest
    {
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; set; }
        
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        internal MallRefundRequest(
            string token,
            string buyOrder,
            string commerceCode,
            decimal amount)
            : base($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}/refunds", HttpMethod.Post)
        {
            BuyOrder = buyOrder;
            CommerceCode = commerceCode;
            Amount = amount;
        }

    }
}
