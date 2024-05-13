using Xunit;
using Transbank.Common;
using Transbank.Webpay.Oneclick;

namespace Tests
{
    public class OneclickTests
    {
        [Fact]
        public void CorrectOptions()
        {
            MallTransaction mallTransaction = MallTransaction.buildForIntegration(IntegrationCommerceCodes.ONECLICK_MALL, IntegrationApiKeys.WEBPAY);
            MallInscription mallInscription = MallInscription.buildForIntegration(IntegrationCommerceCodes.ONECLICK_MALL, IntegrationApiKeys.WEBPAY);
            Assert.Equal(IntegrationCommerceCodes.ONECLICK_MALL,
                mallInscription.Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY,
                mallInscription.Options.ApiKey);
            Assert.Equal(IntegrationCommerceCodes.ONECLICK_MALL,
                mallTransaction.Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY,
                mallTransaction.Options.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            MallTransaction mallTransaction = MallTransaction.buildForIntegration(IntegrationCommerceCodes.ONECLICK_MALL, IntegrationApiKeys.WEBPAY);
            MallInscription mallInscription = MallInscription.buildForIntegration(IntegrationCommerceCodes.ONECLICK_MALL, IntegrationApiKeys.WEBPAY);
            Assert.Equal("https://webpay3gint.transbank.cl", 
                mallTransaction.Options.IntegrationType.ApiBase);
            Assert.Equal("https://webpay3gint.transbank.cl",
                mallInscription.Options.IntegrationType.ApiBase);
        }
    }
}
