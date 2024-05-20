using Xunit;
using Transbank.Common;
using Transbank.Webpay.WebpayPlus;
using Transbank.Webpay.Common;

namespace Tests
{
    public class WebpayPlusTests
    {
        [Fact]
        public void CorrectOptions()
        {
            Transaction transaction = Transaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY);
            Assert.Equal(IntegrationCommerceCodes.WEBPAY_PLUS, transaction.options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY, transaction.options.ApiKey);
            Assert.Equal("https://webpay3gint.transbank.cl", transaction.options.IntegrationType.ApiBase);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            Transaction transaction = Transaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY);
            var response = transaction.Create("buy123", "sess123", 1900, "https://www.test.cl");
            Assert.Contains(WebpayIntegrationType.Test.ApiBase, response.Url);
        }
    }
}
