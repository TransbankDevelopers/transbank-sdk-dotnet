using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Oneclick.Requests
{
    internal class AuthorizeRequest : BaseRequest
    {

        [JsonProperty("username")]
        internal string UserName { get; set; }

        [JsonProperty("tbk_user")]
        internal string TBKUser { get; set; }

        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }

        [JsonProperty("details")]
        internal List<PaymentRequest> Details { get; set; }

        internal AuthorizeRequest(string userName, string tbkUser, string buyOrder, List<PaymentRequest> details)
            : base("/rswebpaytransaction/api/oneclick/v1.0/transactions", HttpMethod.Post)
        {
            UserName = userName;
            TBKUser = tbkUser;
            BuyOrder = buyOrder;
            Details = details;
        }
    }
}
