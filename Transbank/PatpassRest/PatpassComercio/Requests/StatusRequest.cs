using System.Net.Http;
using Transbank.Common;
using Newtonsoft.Json;

namespace Transbank.Patpass.PatpassComercio.Requests
{
    internal class StatusRequest : BaseRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }


        internal StatusRequest(
            string token
            ) : base($"restpatpass/v1/services/status",
                HttpMethod.Post)
        {
            Token = token;
        }
        
    }
}
