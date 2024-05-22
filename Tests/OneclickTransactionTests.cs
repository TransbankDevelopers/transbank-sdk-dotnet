using Xunit;
using Transbank.Common;
using Transbank.Webpay.Oneclick;

namespace Tests
{
    public class OneclickTransactionTests
    {
        [Fact]
        public void CorrectOptions()
        {
            MallTransaction mallTransaction = MallTransaction.buildForIntegration(IntegrationCommerceCodes.ONECLICK_MALL, IntegrationApiKeys.WEBPAY);
            Assert.Equal(IntegrationCommerceCodes.ONECLICK_MALL,
                mallTransaction.Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY,
                mallTransaction.Options.ApiKey);
            Assert.Equal("https://webpay3gint.transbank.cl",
                mallTransaction.Options.IntegrationType.ApiBase);
        }
    }
}
