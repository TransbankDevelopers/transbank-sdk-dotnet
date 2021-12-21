using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;
using Transbank.Webpay.TransaccionCompletaMall.Common;

namespace Transbank.Webpay.TransaccionCompletaMall.Requests
{
    internal class MallCommitRequest : BaseRequest
    {
        [JsonProperty("details")]
        public List<MallCommitDetails> Details { get; set; }

        internal MallCommitRequest(
            string token,
            List<MallCommitDetails> details)
            : base($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}", HttpMethod.Put)
        {
            Details = details;
        }
    }
}
