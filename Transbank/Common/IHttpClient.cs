using System.Net.Http;
using System.Threading.Tasks;

namespace Transbank.Common
{
    /// <summary>
    /// Interface to abstract the HTTP client used by the SDK.
    /// Enables custom implementations and improves testability.
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Sends an HTTP request and returns the response.
        /// </summary>
        /// <param name="request">The HTTP request to send.</param>
        /// <returns>The HTTP response.</returns>
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
