using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.TransaccionCompleta.Responses
{
    public class CreateResponse : BaseResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        public override string ToString()
        {
            return $"Token:{Token}\n";
        }
    }
}
