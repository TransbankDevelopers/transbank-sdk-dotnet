using Microsoft.Web.Services3.Addressing;
using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Responses
{
    public class MallCreateResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        public MallCreateResponse(
            string token)
        {
            Token = token;
        }
    }
}
