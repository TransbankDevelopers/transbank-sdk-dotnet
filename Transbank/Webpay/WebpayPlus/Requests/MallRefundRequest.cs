using System;
using Newtonsoft.Json;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    internal class MallRefundRequest : RefundRequest
    {
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }

        [JsonProperty("commerce_code")]
        public string CommerceCode { get; set; }

        internal MallRefundRequest(
            string token, string buyOrder, string commerceCode,
            decimal amount) : base(token, amount)
        {
            BuyOrder = buyOrder;
            CommerceCode = commerceCode;
        }

        public override string ToString()
        {
            return $"BuyOrder={BuyOrder}, CommerceCode={CommerceCode}, Amount={Amount}";
        }
    }
}
