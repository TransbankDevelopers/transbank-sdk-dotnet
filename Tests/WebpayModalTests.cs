using Xunit;
using Transbank.Common;
using Transbank.Webpay.Modal;

namespace Tests
{
    public class WebpayModalTests
    {
        [Fact]
        public void CorrectOptions()
        {
            Transaction transaction = Transaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MODAL, IntegrationApiKeys.WEBPAY);
            Assert.Equal(IntegrationCommerceCodes.WEBPAY_PLUS_MODAL, transaction.Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY, transaction.Options.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            Transaction transaction = Transaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MODAL, IntegrationApiKeys.WEBPAY);
            Assert.Equal("https://webpay3gint.transbank.cl", transaction.Options.IntegrationType.ApiBase);
        }
    }
}
