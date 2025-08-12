using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Transbank.Common;
using Xunit;

namespace Transbank.Tests.Common
{
    public class DefaultHttpClientTests
    {
        [Fact]
        public async Task SendAsync_ShouldReturnHttpResponseMessage()
        {
            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"ok\":true}")
                });

            var httpClient = new HttpClient(mockHandler.Object);
            var client = new DefaultHttpClient(httpClient);
            var request = new HttpRequestMessage(HttpMethod.Get, "https://fake.url");

            var response = await client.SendAsync(request);

            Assert.NotNull(response);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
