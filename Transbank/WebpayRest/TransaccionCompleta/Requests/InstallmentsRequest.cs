using System.Net.Http;
using Transbank.Common;

namespace Transbank.Webpay.TransaccionCompleta.Requests
{
    internal class InstallmentsRequest : BaseRequest
    {
        internal InstallmentsRequest(string token)
            : base($"/rswebpaytransaction/api/webpay/v1.0/transactions/{token}", HttpMethod.Post) {}
    }
}
