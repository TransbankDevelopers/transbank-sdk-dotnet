using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Common
{
    public class RequestServiceHeaders
    {
        [DefaultValue("Tbk-Api-Key-Id")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ApiKeyHeaderName { get; set; }
        
        [DefaultValue("Tbk-Api-Key-Secret")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string CommerceCodeHeaderName { get; set; }

        public RequestServiceHeaders(string apiKeyHeaderName, string commerceCodeHeaderName)
        {
            ApiKeyHeaderName = apiKeyHeaderName;
            CommerceCodeHeaderName = commerceCodeHeaderName;
        }
    }
}
