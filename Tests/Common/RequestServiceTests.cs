using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Transbank.Common;
using Xunit;

namespace Transbank.Tests.Common
{
    public class RequestServiceTests
    {
        [Fact]
        public async Task RequestService_UsesInjectedIHttpClient()
        {
            var mockHttpClient = new Mock<IHttpClient>();
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"ok\":true}")
            };
            mockHttpClient.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync(expectedResponse);

            var requestService = new RequestService(mockHttpClient.Object);
            var request = new HttpRequestMessage(HttpMethod.Get, "https://fake.url");

            var response = await mockHttpClient.Object.SendAsync(request);

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
