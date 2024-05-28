using System.Net.Http;
using Transbank.Common;
using Newtonsoft.Json;

namespace Transbank.PatpassComercio.Requests
{
    internal class StatusRequest : BaseRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }


        internal StatusRequest(
            string token
            ) : base($"{ApiConstants.PATPASS_COMERCIO_ENDPOINT}/status",
                HttpMethod.Post)
        {
            Token = token;
        }
        
    }
}
