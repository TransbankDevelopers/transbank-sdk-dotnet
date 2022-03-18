using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.TransaccionCompletaMall.Responses
{
    public class MallCreateResponse : BaseResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        public override string ToString()
        {
            return $"Token={Token}\n";
        }
    }
}
