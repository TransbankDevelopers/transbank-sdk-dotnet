using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Xunit;

namespace Transbank.Tests.Common
{
    public class RequestServiceTests
    {
        [Fact]
        public void RequestService_UsesInjectedIHttpClient()
        {
            var mockHttpClient = new Mock<IHttpClient>();
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"field\":\"value\"}")
            };
            mockHttpClient.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync(expectedResponse)
                .Verifiable();

            var requestService = new RequestService(mockHttpClient.Object);
            var request = new DummyRequest();
            var options = new DummyOptions();

            var result = requestService.Perform<DummyResponse, DummyException>(request, options);

            Assert.NotNull(result);
            Assert.Equal("value", result.Field);
            mockHttpClient.Verify(x => x.SendAsync(It.IsAny<HttpRequestMessage>()), Times.Once);
        }

        [Fact]
        public void Perform_ShouldReturnDeserializedResponse_WhenHttpIsSuccessful()
        {
            var mockHttpClient = new Mock<IHttpClient>();
            var responseJson = "{\"field\":\"value\"}";
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseJson)
            };
            mockHttpClient.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync(httpResponse);

            var service = new RequestService(mockHttpClient.Object);
            var request = new DummyRequest();
            var options = new DummyOptions();

            var result = service.Perform<DummyResponse, DummyException>(request, options);

            Assert.NotNull(result);
            Assert.Equal("value", result.Field);
        }

        [Fact]
        public void Perform_ShouldThrowException_WhenHttpFails()
        {
            var mockHttpClient = new Mock<IHttpClient>();
            var httpResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("{ \"error_message\": \"fail\" }")
            };
            mockHttpClient.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync(httpResponse);

            var service = new RequestService(mockHttpClient.Object);
            var request = new DummyRequest();
            var options = new DummyOptions();

            Assert.Throws<DummyException>(() => service.Perform<DummyResponse, DummyException>(request, options));
        }

        public class DummyIntegrationType : IIntegrationType
        {
            public string ApiBase => "https://dummy.api";
            public string Key => "dummy";
        }
        public class DummyRequest : BaseRequest
        {
            public DummyRequest() : base("/dummy", HttpMethod.Post) { }
        }
        public class DummyResponse : BaseResponse
        {
            public string Field { get; set; }
        }
        public class DummyException : TransbankException
        {
            public DummyException(int code, string message) : base(code, message) { }
        }
        public class DummyOptions : Options
        {
            public DummyOptions() : base("code", "key", new DummyIntegrationType(), 10, null) { }
        }
    }
}
