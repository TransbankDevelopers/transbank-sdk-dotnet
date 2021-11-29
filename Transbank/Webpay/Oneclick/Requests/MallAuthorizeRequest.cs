using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.Common;
using System.Collections.Generic;

namespace Transbank.Webpay.Oneclick.Requests
{
    internal class MallAuthorizeRequest : BaseRequest
    {
        [JsonProperty("username")]
        internal string UserName { get; set; }

        [JsonProperty("tbk_user")]
        internal string TbkUser { get; set; }

        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }

        [JsonProperty("details")]
        internal List<PaymentRequest> Details { get; set; }

        internal MallAuthorizeRequest(string userName, string tbkUser, string buyOrder, List<PaymentRequest> details)
            : base($"{ApiConstant.ONECLICK_METHOD}/transactions", HttpMethod.Post)
        {
            UserName = userName;
            TbkUser = tbkUser;
            BuyOrder = buyOrder;
            Details = details;
        }
    }
}
