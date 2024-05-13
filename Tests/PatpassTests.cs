using Xunit;
using Transbank.Common;
using Transbank.Patpass.PatpassComercio;

namespace Tests
{
    public class PatpassTests
    {
        [Fact]
        public void CorrectOptions()
        {
            Inscription inscription = Inscription.buildForIntegration(IntegrationCommerceCodes.PATPASS_COMERCIO, IntegrationApiKeys.PATPASS_COMERCIO);
            Assert.Equal(IntegrationCommerceCodes.PATPASS_COMERCIO, inscription.Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.PATPASS_COMERCIO, inscription.Options.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            Inscription inscription = Inscription.buildForIntegration(IntegrationCommerceCodes.PATPASS_COMERCIO, IntegrationApiKeys.PATPASS_COMERCIO);
            Assert.Equal("https://pagoautomaticocontarjetasint.transbank.cl", inscription.Options.IntegrationType.ApiBase);
        }
    }
}
