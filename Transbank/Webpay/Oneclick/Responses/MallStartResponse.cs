using Transbank.Webpay.Common;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class MallStartResponse : BaseResponse
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("url_webpay")]
        public string Url { get; private set; }

        public override string ToString()
        {
            return $"\"Token\": \"{Token}\"\n"+
                $"\"Url\": \"{Url}\"\n";
        }
    }
}
