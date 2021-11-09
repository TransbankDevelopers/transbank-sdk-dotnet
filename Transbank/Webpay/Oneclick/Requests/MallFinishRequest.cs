using System.Net.Http;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Requests
{
    internal class MallFinishRequest : BaseRequest
    {
        internal MallFinishRequest(string token)
            : base($"{ApiConstant.ONECLICK_METHOD}/inscriptions/{token}",
                  HttpMethod.Put){}
                  
    }
}
