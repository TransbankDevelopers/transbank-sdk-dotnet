using System.Net.Http;
using System.Net.Http.Headers;
using Transbank.Common;

namespace Transbank.Patpass.Common
{
    public class PatpassComercioRequestService : AbstractRequestService
    {
        private static readonly string CONTENT_TYPE = "application/json";
        private void AddRequiredHeaders(HttpClient client, string commerceCode, string apiKey)
        {
            var header = new MediaTypeWithQualityHeaderValue(CONTENT_TYPE);
            client.DefaultRequestHeaders.Accept.Add(header);
            client.DefaultRequestHeaders.Add("commerceCode", commerceCode);
            client.DefaultRequestHeaders.Add("Authorization", apiKey);
        }
    }
}
