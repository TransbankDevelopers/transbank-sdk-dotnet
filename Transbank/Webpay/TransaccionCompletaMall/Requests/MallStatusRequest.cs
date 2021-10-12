using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.Webpay.TransaccionCompletaMall.Requests
{
    public class MallStatusRequest : BaseRequest
    {
        internal MallStatusRequest(string token)
            : base($"{Constant.WEBPAY_METHOD}/transactions/{token}", HttpMethod.Get){}
    }
}
