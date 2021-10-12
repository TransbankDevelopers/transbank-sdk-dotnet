using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;
using Transbank.Webpay.TransaccionCompletaMall.Common;

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
            : base($"{Constant.WEBPAY_METHOD}/transactions/{token}/installments", HttpMethod.Post)
        {
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
            InstallmentsNumber = installmentsNumber;
        }
    }
}
