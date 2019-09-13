using System.Net.Http;
using Transbank.Common;

namespace Transbank.WebpayRest.Oneclick.Requests
{
    public class MallStatusRequest : BaseRequest
    {
        public MallStatusRequest(string buyOrder)
            : base($"/rswebpaytransaction/api/oneclick/v1.0/transactions/{buyOrder}", HttpMethod.Get)
        {

        }
    }
}