using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Webpay.TransaccionCompletaMall.Responses;

namespace Transbank.Webpay.TransaccionCompletaMall.Common
{
    public class MallInstallmentsDetailsResponse
    {
        [JsonProperty("details")]
        public List<MallInstallmentsResponse> Details { get; set; }

        public MallInstallmentsDetailsResponse(
            List<MallInstallmentsResponse> details
        )
        {
            Details = details;
        }
    }
}
