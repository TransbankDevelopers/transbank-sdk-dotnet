using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Transbank.Onepay.Net
{
    public abstract class Channel
    {
        public static string Request(string uri, HttpMethod method, string query)
        {
            return Request(uri, method, query, null);
        }

        public static string Request(string uri, HttpMethod method,
            string query, string contenType)
        {
            if (method == null)
                method = HttpMethod.Get;
            if (contenType == null)
                contenType = "application/json";

            var message = new HttpRequestMessage(method, new Uri(uri))
            {
                Content = new StringContent(query, Encoding.UTF8, contenType)
            };

            using (var client = new HttpClient())
            {
                    var header = new MediaTypeWithQualityHeaderValue(contenType);                    
                    client.DefaultRequestHeaders.Accept.Add(header);

                    var response = client.SendAsync(message).ConfigureAwait(false).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    var jsonResponse = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                    return jsonResponse;
            }            
        }

        
        public static string PostString(string url, string RequestMethod, string Query)
        {
            return "";
        }
    }
}
