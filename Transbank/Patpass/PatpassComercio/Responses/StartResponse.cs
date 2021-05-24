using Newtonsoft.Json;

namespace Transbank.Patpass.PatpassComercio.Responses
{
    public class StartResponse
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
