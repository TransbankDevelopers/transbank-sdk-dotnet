using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    internal class MallCreateRequest : BaseRequest
    {
        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }
        [JsonProperty("session_id")]
        internal string SessionId { get; set; }
        [JsonProperty("return_url")]
        internal string ReturnUrl { get; set; }
        [JsonProperty("details", ItemReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        internal List<TransactionDetail> Transactions { get; set; }

        internal MallCreateRequest(string buyOrder, string sessionId, string returnUrl,
            List<TransactionDetail> transactions) : base(
                $"{Constant.WEBPAY_METHOD}/transactions", HttpMethod.Post)
        {
            BuyOrder = buyOrder;
            SessionId = sessionId;
            ReturnUrl = returnUrl;
            Transactions = transactions;
        }
    }
}
