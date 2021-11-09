using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.WebpayRest.Oneclick.Requests
{
    public class MallRefundRequest : BaseRequest
    {
        [JsonProperty("commerce_code")]
        internal string CommerceCode { get; set; }
        
        [JsonProperty("detail_buy_order")]
        internal string DetailBuyOrder { get; set; }
        
        [JsonProperty("amount")]
        internal decimal Amount { get; set; }
        
        public MallRefundRequest(string buyOrder, string childCommerceCode, string childBuyOrder, decimal amount)
            : base($"{ApiConstant.ONECLICK_METHOD}/transactions/{buyOrder}/refunds", HttpMethod.Post)
        {
            CommerceCode = childCommerceCode;
            DetailBuyOrder = childBuyOrder;
            Amount = amount;
        }
    }
}
