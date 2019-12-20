using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompleta.Responses
{
    public class CreateResponse
    {
        [JsonProperty("token")]
        public string Token { get; private set; }

        public CreateResponse(string token)
        {
            Token = token;
        }

        public override string ToString()
        {
            return $"\"Token\":\"{Token}\"";
        }
    }
}
