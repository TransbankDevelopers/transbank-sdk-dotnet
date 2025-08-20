using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Transbank.Common
{
    /// <summary>
    /// Default implementation of IHttpClient using System.Net.Http.HttpClient.
    /// Allows custom timeout or injection of an external HttpClient for testing.
    /// </summary>
    public class DefaultHttpClient : IHttpClient
    {
        private readonly HttpClient _client;
        /// <summary>
        /// Creates a DefaultHttpClient instance with a custom timeout.
        /// </summary>
        /// <param name="timeoutSeconds">Timeout in seconds for HTTP requests.</param>
        public DefaultHttpClient(int timeoutSeconds)
        {
            _client = new HttpClient { Timeout = TimeSpan.FromSeconds(timeoutSeconds) };
        }
        /// <summary>
        /// Creates a DefaultHttpClient instance using an external HttpClient (useful for testing/mocks).
        /// </summary>
        /// <param name="httpClient">HttpClient instance to use.</param>
        public DefaultHttpClient(HttpClient httpClient)
        {
            _client = httpClient;
        }
        /// <inheritdoc />
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return _client.SendAsync(request);
        }
    }
}
