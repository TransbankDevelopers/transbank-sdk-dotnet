using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Oneclick.Requests
{
    internal class DeleteRequest : BaseRequest
    {

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("tbk_user")]
        public string TBKUser { get; set; }

        public override string ToString()
        {
            return $"\"UserName\": \"{UserName}\"\n" +
                   $"\"TbkUser\": \"{TBKUser}\"";
        }

        internal DeleteRequest(string userName, string tbkUser)
            : base("/rswebpaytransaction/api/oneclick/v1.0/transactions", HttpMethod.Delete)
        {
            UserName = userName;
            TBKUser = tbkUser;
        }
    }
}
