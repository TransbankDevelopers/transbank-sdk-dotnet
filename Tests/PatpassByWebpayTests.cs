using Xunit;
using Transbank.Common;
using Transbank.Patpass.PatpassByWebpay;

namespace Tests
{
    public class PatpassByWebpayTests
    {
        [Fact]
        public void CorrectOptions()
        {
            Transaction transaction = Transaction.buildForIntegration(IntegrationCommerceCodes.PATPASS_BY_WEBPAY, IntegrationApiKeys.WEBPAY);
            Assert.Equal(IntegrationCommerceCodes.PATPASS_BY_WEBPAY, transaction.Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY, transaction.Options.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            Transaction transaction = Transaction.buildForIntegration(IntegrationCommerceCodes.PATPASS_COMERCIO, IntegrationApiKeys.PATPASS_COMERCIO);
            Assert.Equal("https://webpay3gint.transbank.cl", transaction.Options.IntegrationType.ApiBase);
        }
    }
}
