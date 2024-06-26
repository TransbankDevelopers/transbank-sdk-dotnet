using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Common;
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

        public override string ToString()
        {
            string details = "";
            Details.ForEach(i => details += "{\n" + i.ToString() + "\n}\n");
            return details;
        }
    }
}
