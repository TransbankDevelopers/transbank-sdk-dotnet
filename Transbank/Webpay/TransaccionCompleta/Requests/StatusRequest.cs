using Transbank.Common;
using System.Net.Http;

namespace Transbank.Webpay.TransaccionCompleta.Requests
{
    public class StatusRequest : BaseRequest
    {
        public StatusRequest(string token)
            : base($"{ApiConstant.WEBPAY_METHOD}/transactions/{token}", HttpMethod.Get){}

    }
}
