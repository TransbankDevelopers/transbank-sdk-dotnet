using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.Webpay.TransaccionCompletaMall.Requests
{
    public class MallStatusRequest : BaseRequest
    {
        internal MallStatusRequest(string token)
            : base($"/rswebpaytransaction/api/webpay/v1.0/transactions/{token}", HttpMethod.Get){}
    }
}
