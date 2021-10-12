using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Requests
{
    internal class MallDeleteRequest : BaseRequest
    {
        [JsonProperty("username")]
        internal string UserName { get; set; }

        [JsonProperty("tbk_user")]
        internal string TbkUser { get; set; }

        internal MallDeleteRequest(string userName, string tbkUser)
            : base($"{Constant.ONECLICK_METHOD}/inscriptions", HttpMethod.Delete)
        {
            UserName = userName;
            TbkUser = tbkUser;
        }
    }
}
