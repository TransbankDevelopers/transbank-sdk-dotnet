using System.Net.Http;
using System.Net.Http.Headers;


namespace Transbank.Common
{
    public class RequestService : AbstractRequestService
    {
        private static readonly string CONTENT_TYPE = "application/json";
        private static void AddRequiredHeaders(HttpClient client, string commerceCode, string apiKey)
        {
            var header = new MediaTypeWithQualityHeaderValue(CONTENT_TYPE);
            client.DefaultRequestHeaders.Accept.Add(header);
            client.DefaultRequestHeaders.Add("Tbk-Api-Key-Id", commerceCode);
            client.DefaultRequestHeaders.Add("Tbk-Api-Key-Secret", apiKey);
        }
    }
}
