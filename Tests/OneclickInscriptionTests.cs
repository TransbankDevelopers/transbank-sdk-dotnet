using Xunit;
using Transbank.Common;
using Transbank.Webpay.Oneclick;
using Transbank.Webpay.Common;

namespace Tests
{
    public class OneclickInscriptionTests
    {
        [Fact]
        public void CorrectOptions()
        {
            MallInscription mallInscription = MallInscription.buildForIntegration(IntegrationCommerceCodes.ONECLICK_MALL, IntegrationApiKeys.WEBPAY);
            Assert.Equal(IntegrationCommerceCodes.ONECLICK_MALL,
                mallInscription.Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY,
                mallInscription.Options.ApiKey);
            Assert.Equal("https://webpay3gint.transbank.cl",
                mallInscription.Options.IntegrationType.ApiBase);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            MallInscription mallInscription = MallInscription.buildForIntegration(IntegrationCommerceCodes.ONECLICK_MALL, IntegrationApiKeys.WEBPAY);
            var inscriptionResponse = mallInscription.Start("UserTest", "user@test.cl", "https://test/cl");
            Assert.Contains(WebpayIntegrationType.Test.ApiBase, inscriptionResponse.Url);
        }
    }
}
