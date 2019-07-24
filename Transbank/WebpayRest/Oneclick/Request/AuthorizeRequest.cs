using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Oneclick.Requests
{
    internal class AuthorizeRequest : BaseRequest
    {

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("tbk_user")]
        public string TBKUser { get; set; }

        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }

        [JsonProperty("details")]
        public List<PaymentRequest> Details { get; set; }

        public override string ToString()
        {
            return $"UserName= {UserName}\n" +
                   $"TbkUser= {TBKUser}\n" +
                   $"BuyOrder= {BuyOrder}\n" +
                   $"Details= {Details.ToString()}\n";
        }

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
