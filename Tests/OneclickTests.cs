using Xunit;
using Transbank.Webpay.Oneclick;

namespace Tests
{
    public class OneclickTests
    {
        [Fact]
        public void CorrectDefaultOptions()
        {
            Assert.Equal("597055555541", MallTransaction.CommerceCode);
            Assert.Equal("579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C", MallTransaction.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            Assert.Equal("https://webpay3gint.transbank.cl", MallTransaction.IntegrationType.ApiBase);
        }
    }
}
