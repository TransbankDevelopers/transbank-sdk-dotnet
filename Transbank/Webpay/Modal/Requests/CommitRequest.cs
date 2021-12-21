using System.Net.Http;
using Transbank.Common;

namespace Transbank.Webpay.Modal.Requests
{
    internal class CommitRequest : BaseRequest
    {
        internal CommitRequest(string token)
            : base($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}", HttpMethod.Put) {}
    }
}
