using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;
using Transbank.Webpay.TransaccionCompletaMall.Common;
using Transbank.Webpay.WebpayPlus.Responses;

namespace Transbank.Webpay.TransaccionCompletaMall.Requests
{
    internal class MallCommitRequest : BaseRequest
    {
        [JsonProperty("details")]
        public List<CommitDetails> Details { get; set; }

        internal MallCommitRequest(
            string token,
            List<CommitDetails> details)
            : base($"/rswebpaytransaction/api/webpay/v1.0/transactions/{token}", HttpMethod.Put)
        {
            Details = details;
        }
    }
}
