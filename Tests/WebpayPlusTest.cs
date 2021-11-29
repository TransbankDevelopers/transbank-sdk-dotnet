using Xunit;
using Transbank.Common;
using Transbank.Webpay.WebpayPlus;

namespace Tests
{
    public class WebpayPlusTests
    {
        [Fact]
        public void CorrectDefaultOptions()
        {
            Assert.Equal(IntegrationCommerceCodes.WEBPAY_PLUS, (new Transaction()).Options.CommerceCode);
            Assert.Equal(IntegrationCommerceCodes.WEBPAY_PLUS_MALL, (new MallTransaction()).Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY, (new Transaction()).Options.ApiKey);
            Assert.Equal(IntegrationApiKeys.WEBPAY, (new MallTransaction()).Options.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            Assert.Equal("https://webpay3gint.transbank.cl", (new Transaction()).Options.IntegrationType.ApiBase);
            Assert.Equal("https://webpay3gint.transbank.cl", (new MallTransaction()).Options.IntegrationType.ApiBase);
        }
    }
}
