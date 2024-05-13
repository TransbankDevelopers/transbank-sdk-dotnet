using Xunit;
using Transbank.Common;
using Transbank.Webpay.WebpayPlus;

namespace Tests
{
    public class WebpayPlusTests
    {
        [Fact]
        public void CorrectOptions()
        {
            Transaction transaction = Transaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY);
            MallTransaction mallTransaction = MallTransaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MALL, IntegrationApiKeys.WEBPAY);
            Assert.Equal(IntegrationCommerceCodes.WEBPAY_PLUS, transaction.Options.CommerceCode);
            Assert.Equal(IntegrationCommerceCodes.WEBPAY_PLUS_MALL, mallTransaction.Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY, transaction.Options.ApiKey);
            Assert.Equal(IntegrationApiKeys.WEBPAY, mallTransaction.Options.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            Transaction transaction = Transaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY);
            MallTransaction mallTransaction = MallTransaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MALL, IntegrationApiKeys.WEBPAY);
            Assert.Equal("https://webpay3gint.transbank.cl", transaction.Options.IntegrationType.ApiBase);
            Assert.Equal("https://webpay3gint.transbank.cl", mallTransaction.Options.IntegrationType.ApiBase);
        }
    }
}
