using Newtonsoft.Json;
using Transbank.Webpay.Common;
using System.Net.Http;

namespace Transbank.Webpay.Oneclick.Requests
{
    internal class StartRequest : BaseRequest
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("response_url")]
        public string ResponseUrl { get; set; }

        public override string ToString()
        {
            return $"\"UserName\": \"{UserName}\"\n" +
                   $"\"Email\": \"{Email}\"\n" + 
                   $"\"RsponseUrl\": \"{ResponseUrl}\"";
        }

        internal StartRequest(string userName, string email, string responseUrl)
            : base("/rswebpaytransaction/api/oneclick/v1.0/inscriptions", HttpMethod.Post)
        {
            UserName = userName;
            Email = email;
            ResponseUrl = responseUrl;
        }
    }
}
