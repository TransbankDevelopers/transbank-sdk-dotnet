using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Requests
{
    internal class DeleteRequest : BaseRequest
    {
        [JsonProperty("username")]
        internal string UserName { get; set; }

        [JsonProperty("tbk_user")]
        internal string TbkUser { get; set; }

        internal DeleteRequest(string userName, string tbkUser)
            : base("/rswebpaytransaction/api/oneclick/v1.0/inscriptions", HttpMethod.Delete)
        {
            UserName = userName;
            TbkUser = tbkUser;
        }
    }
}
