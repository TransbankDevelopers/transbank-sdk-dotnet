using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;
using Xunit;

namespace Transbank.Tests.Webpay.Oneclick
{
    public class MallInfoBinTests
    {
        [Fact]
        public void Constructor_ShouldSetOptions_WhenValidOptionsProvided()
        {
            var options = new Options("123", "abc", WebpayIntegrationType.Test);
            var mallInfoBin = new MallInfoBin(options);

            Assert.Equal(options, mallInfoBin.Options);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_WhenOptionsIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new MallInfoBin(null));
        }

        [Fact]
        public void BuildForIntegration_ShouldReturnMallInfoBinWithTestEnvironment()
        {
            var instance = MallInfoBin.buildForIntegration("123", "abc");

            Assert.NotNull(instance);
            Assert.Equal(WebpayIntegrationType.Test, instance.Options.IntegrationType);
            Assert.Equal("123", instance.Options.CommerceCode);
            Assert.Equal("abc", instance.Options.ApiKey);
        }

        [Fact]
        public void BuildForProduction_ShouldReturnMallInfoBinWithLiveEnvironment()
        {
            var instance = MallInfoBin.buildForProduction("456", "def");

            Assert.NotNull(instance);
            Assert.Equal(WebpayIntegrationType.Live, instance.Options.IntegrationType);
            Assert.Equal("456", instance.Options.CommerceCode);
            Assert.Equal("def", instance.Options.ApiKey);
        }

        [Fact]
        public void QueryBin_ShouldThrowArgumentException_WhenTbkUserIsEmpty()
        {
            var options = new Options("123", "abc", WebpayIntegrationType.Test);
            var instance = new MallInfoBin(options);

            var ex = Assert.Throws<ArgumentNullException>(() => instance.queryBin(""));
            Assert.Contains("tbkUser", ex.Message);
        }

        [Fact]
        public void QueryBin_ShouldThrowArgumentException_WhenTbkUserIsInvalid()
        {
            string fakeTbkUser = "fakeTbkUser";
            var options = new Options(
                IntegrationCommerceCodes.ONECLICK_MALL,
                IntegrationApiKeys.WEBPAY,
                WebpayIntegrationType.Test
            );
            var instance = new MallInfoBin(options);

            var ex = Assert.Throws<MallQueryBinException>(() => instance.queryBin("fakeTbkUser"));
            Assert.Contains($"User {fakeTbkUser} not found", ex.Message);
        }

        [Fact]
        public void QueryBin_ShouldThrowMallQueryBinException_WhenHttpFails()
        {
            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent("{ \"error\": \"internal error\" }")
                });

            var httpClient = new HttpClient(mockHandler.Object)
            {
                BaseAddress = new Uri("https://webpay3gint.transbank.cl")
            };

            var options = new Options("999", "secret", WebpayIntegrationType.Test, 600, httpClient);
            var instance = new MallInfoBin(options);

            Assert.Throws<MallQueryBinException>(() => instance.queryBin("userWithError"));
        }

        [Fact]
        public void QueryBin_ShouldReturnExpectedFieldsInResponse()
        {
            var expectedJson = @"{
                ""bin_issuer"": ""BANCO TEST"",
                ""bin_payment_type"": ""Crédito"",
                ""bin_brand"": ""VISA""
            }";

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedJson)
                });

            var httpClient = new HttpClient(mockHandler.Object)
            {
                BaseAddress = new Uri("https://webpay3gint.transbank.cl")
            };

            var options = new Options("999", "secret", WebpayIntegrationType.Test, 600, httpClient);
            var instance = new MallInfoBin(options);
            var response = instance.queryBin("tbkUser123");

            Assert.NotNull(response);
            Assert.Equal("BANCO TEST", response.BinIssuer);
            Assert.Equal("Crédito", response.BinPaymentType);
            Assert.Equal("VISA", response.BinBrand);
        }

        [Fact]
        public void MallQueryBinResponse_ToString_ShouldReturnFormattedString()
        {
            var response = new MallQueryBinResponse
            {
                BinIssuer = "BANCO TEST",
                BinPaymentType = "Crédito",
                BinBrand = "VISA"
            };

            var expected = "\"BinIssuer\": \"BANCO TEST\"\n" +
                           "\"BinPaymentType\": \"Crédito\"\n" +
                           "\"BinBrand\": \"VISA\"\n";

            Assert.Equal(expected, response.ToString());
        }
    }
}
