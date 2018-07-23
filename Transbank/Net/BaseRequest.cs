using Newtonsoft.Json;

namespace Transbank.Net
{
    public abstract class BaseRequest
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
        [JsonProperty("appKey")]
        public string AppKey { get; set; }
    }
}
