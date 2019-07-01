using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Transbank.Webpay.Common
{
    public static class RequestService
    {
        private static readonly string CONTENT_TYPE = "application/json";

        private static void AddRequiredHeaders(HttpClient client, string commerceCode, string apiKey)
        {
            var header = new MediaTypeWithQualityHeaderValue(CONTENT_TYPE);
            client.DefaultRequestHeaders.Accept.Add(header);
            client.DefaultRequestHeaders.Add("Tbk-Api-Key-Id", commerceCode);
            client.DefaultRequestHeaders.Add("Tbk-Api-Key-Secret", apiKey);
        }

        public static string Perform(BaseRequest request, Options options)
        {
            var message = new HttpRequestMessage(request.Method, new Uri(options.IntegrationType.ApiBase + request.Endpoint))
            {
                Content = new StringContent(JsonConvert.SerializeObject(request),
                    Encoding.UTF8, CONTENT_TYPE)
            };

            using (var client = new HttpClient())
            {
                AddRequiredHeaders(client, options.CommerceCode, options.ApiKey);

                var response = client.SendAsync(message).ConfigureAwait(false)
                    .GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                var jsonResponse = response.Content.ReadAsStringAsync()
                    .ConfigureAwait(false).GetAwaiter().GetResult();
                return jsonResponse;
            }
        }
    }
}
