using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transbank.Exceptions;

namespace Transbank.Common
{
    public abstract class AbstractRequestService
    {
        private static readonly string CONTENT_TYPE = "application/json";
        private static void AddRequiredHeaders(HttpClient client, string commerceCode, string apiKey) { }

        public static string Perform<T>(BaseRequest request, Options options) where T : TransbankException
        {
            var message = new HttpRequestMessage(request.Method, new Uri(options.IntegrationType.ApiBase + request.Endpoint));
            if (request.Method != HttpMethod.Get)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, CONTENT_TYPE);
            }

            using (var client = new HttpClient())
            {
                AddRequiredHeaders(client, options.CommerceCode, options.ApiKey);
                var response = client.SendAsync(message).ConfigureAwait(false).GetAwaiter().GetResult(); 
                var jsonResponse = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult(); 
                if (!response.IsSuccessStatusCode) 
                { 
                    var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonResponse); 
                    throw (T)Activator.CreateInstance(typeof(T), new Object[]
                    {
                        (int)response.StatusCode, $"Error message: {jsonObject.Value<string>("error_message")}"
                    });
                }
                return jsonResponse;
            }
        }
    }
}
