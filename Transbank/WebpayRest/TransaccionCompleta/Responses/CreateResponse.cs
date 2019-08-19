using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompleta.Responses
{
    public class CreateResponse
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
  
        public override string ToString()
        {
            return $"Token={Token}";
        }
    }
}
