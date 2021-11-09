using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.WebpayRest.WebpayPlus.Requests
{
    public class MallCaptureRequest : BaseRequest
    {
        [JsonProperty("commerce_code")]
        private string CommerceCode { get; set; }
        
        [JsonProperty("buy_order")]
        private string BuyOrder { get; set; }
        
        [JsonProperty("authorization_code")]
        private string AuthorizationCode { get; set; }
        
        [JsonProperty("capture_amount")]
        private decimal CaptureAmount { get; set; }
        
        public MallCaptureRequest(string token, string commerceCode, string buyOrder, string authorizationCode,
            decimal captureAmount)
            : base($"{ApiConstant.WEBPAY_METHOD}/transactions/{token}/capture", HttpMethod.Put)
        {
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
            AuthorizationCode = authorizationCode;
            CaptureAmount = captureAmount;
        }

        public override string ToString()
        {
            return
                $"{nameof(CommerceCode)}: {CommerceCode}, {nameof(BuyOrder)}: {BuyOrder}, {nameof(AuthorizationCode)}: {AuthorizationCode}, {nameof(CaptureAmount)}: {CaptureAmount}";
        }
    }
}
