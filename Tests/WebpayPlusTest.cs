using Xunit;
using Transbank.Webpay.WebpayPlus;

namespace Tests
{
    public class WebpayPlusTests
    {
        [Fact]
        public void CorrectDefaultOptions()
        {
            Assert.Equal("597055555532", Transaction.CommerceCode);
            Assert.Equal("597055555535", MallTransaction.CommerceCode);
            Assert.Equal("597055555540", DeferredTransaction.CommerceCode);
            Assert.Equal("597055555581", MallDeferredTransaction.CommerceCode);
            Assert.Equal("579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C", Transaction.ApiKey);
            Assert.Equal("579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C", MallTransaction.ApiKey);
            Assert.Equal("579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C", DeferredTransaction.ApiKey);
            Assert.Equal("579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C", MallDeferredTransaction.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            Assert.Equal("https://webpay3gint.transbank.cl", Transaction.IntegrationType.ApiBase);
            Assert.Equal("https://webpay3gint.transbank.cl", MallTransaction.IntegrationType.ApiBase);
            Assert.Equal("https://webpay3gint.transbank.cl", DeferredTransaction.IntegrationType.ApiBase);
            Assert.Equal("https://webpay3gint.transbank.cl", MallDeferredTransaction.IntegrationType.ApiBase);
        }
    }
}
