using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Patpass.PatpassComercio.Responses
{
    public class StatusResponse : BaseResponse
    {
        [JsonProperty("authorized")]
        public string Status { get; set; }

        [JsonProperty("voucherUrl")]
        public string UrlVoucher { get; set; }


        public StatusResponse(string status, string urlVoucher)
        {
            Status = status;
            UrlVoucher = urlVoucher;
        }

        public override string ToString()
        {
            return $"status: {Status}\n" +
                   $"url voucher: {UrlVoucher}";
        }
    }
}
