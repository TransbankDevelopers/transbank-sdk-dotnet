using Transbank.Webpay.Common;
using Newtonsoft.Json;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class StartResponse
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("url_webpay")]
        public string Url { get; private set; }

        public StartResponse(string token, string url)
        {
            Token = token;
            Url = url;
        }

        public override string ToString()
        {
            return $"\"Token\": \"{Token}\"\n"+
                $"\"Url\": \"{Url}\"\n";
        }
    }
}
