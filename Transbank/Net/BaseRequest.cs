using Newtonsoft.Json;

namespace Transbank.Model
{
    public abstract class BaseRequest
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
        [JsonProperty("appKey")]
        public string AppKey { get; set; }
    }
}