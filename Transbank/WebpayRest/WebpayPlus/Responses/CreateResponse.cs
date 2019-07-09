using System;
using Newtonsoft.Json;

namespace Transbank.Webpay.WebpayPlus.Responses
{
    public class CreateResponse
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("url")]
        public string Url { get; private set; }

        public override string ToString()
        {
            return $"Token={Token}, Url={Url}";
        }
    }
}
