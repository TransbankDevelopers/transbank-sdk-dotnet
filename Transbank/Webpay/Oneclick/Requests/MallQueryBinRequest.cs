using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Requests
{
    public class MallQueryBinRequest : BaseRequest
    {
        [JsonProperty("tbk_user")]
        internal string TbkUser { get; set; }

        internal MallQueryBinRequest(string tbkUser)
            : base($"{ApiConstants.ONECLICK_METHOD}/bin_info", HttpMethod.Post)
        {
            TbkUser = tbkUser;
        }
    }
}
