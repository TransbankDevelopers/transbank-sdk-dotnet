using Newtonsoft.Json;
using System.Net.Http;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Requests
{
    internal class MallStartRequest : BaseRequest
    {
        [JsonProperty("username")]
        internal string UserName { get; set; }

        [JsonProperty("email")]
        internal string Email { get; set; }

        [JsonProperty("response_url")]
        internal string ResponseUrl { get; set; }

        internal MallStartRequest(string userName, string email, string responseUrl)
            : base($"{Constant.ONECLICK_METHOD}/inscriptions", HttpMethod.Post)
        {
            UserName = userName;
            Email = email;
            ResponseUrl = responseUrl;
        }
    }
}
