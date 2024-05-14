using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.PatpassComercio.Responses
{
    public class StartResponse : BaseResponse
    {
        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("url")]
        public string Url { get; private set; }

        public StartResponse(string token, string url)
        {
            Token = token;
            Url = url;
        }

        public override string ToString()
        {
            return $"Token={Token}, Url={Url}";
        }
        
    }
}
