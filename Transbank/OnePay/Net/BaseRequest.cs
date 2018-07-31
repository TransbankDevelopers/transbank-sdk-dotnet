using Newtonsoft.Json;

namespace Transbank.Onepay.Net
{
    public abstract class BaseRequest
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
        [JsonProperty("appKey")]
        public string AppKey { get; set; }
    }
}
