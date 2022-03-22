using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.WebpayPlus.Responses
{
    public class CreateResponse : BaseResponse
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("url")]
        public string Url { get; private set; }

        public override string ToString()
        {
            return $"Token={Token},\nUrl={Url}\n";
        }
    }
}
