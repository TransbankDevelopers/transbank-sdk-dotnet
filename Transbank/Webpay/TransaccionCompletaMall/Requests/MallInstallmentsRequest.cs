using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.Webpay.TransaccionCompletaMall.Requests
{
    internal class MallInstallmentsRequest : BaseRequest
    {
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; set; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        
        [JsonProperty("installments_number")]
        public int InstallmentsNumber { get; set; }
        
        internal MallInstallmentsRequest(
            string token,
            string commerceCode,
            string buyOrder,
            int installmentsNumber)
            : base($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}/installments", HttpMethod.Post)
        {
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
            InstallmentsNumber = installmentsNumber;
        }
    }
}
