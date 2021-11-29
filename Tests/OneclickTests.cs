using Xunit;
using Transbank.Common;
using Transbank.Webpay.Oneclick;

namespace Tests
{
    public class OneclickTests
    {
        [Fact]
        public void CorrectDefaultOptions()
        {
            Assert.Equal(IntegrationCommerceCodes.ONECLICK_MALL, (new MallTransaction()).Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY, (new MallTransaction()).Options.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            Assert.Equal("https://webpay3gint.transbank.cl", (new MallTransaction()).Options.IntegrationType.ApiBase);
        }
    }
}
