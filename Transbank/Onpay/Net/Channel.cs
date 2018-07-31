using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Transbank.Onepay.Net
{
    public abstract class Channel
    {
        public static async Task<string> RequestAsync(string uri, HttpMethod method, string query)
        {
            return await RequestAsync(uri, method, query, null);
        }
        public static async Task<string> RequestAsync(string uri, HttpMethod method,
            string query, string contenType)
        {
            if (method == null)
                method = HttpMethod.Get;
            if (contenType == null)
                contenType = "application/json";

            Client = new HttpClient();
            var header = new MediaTypeWithQualityHeaderValue(contenType);
            Client.DefaultRequestHeaders.Accept.Add(header);

            HttpRequestMessage message = new HttpRequestMessage(method, new Uri(uri))
            {
                Content = new StringContent(query, Encoding.UTF8, contenType)
            };
            try
            {
                HttpResponseMessage response;
                response = await Client.SendAsync(message);
                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }
            finally
            {
                Client.Dispose();
            }
        }

        internal static HttpClient Client { get; private set; }

        public static string PostString(string url, string RequestMethod, string Query )
        {
            return "";
        }
    }
}
