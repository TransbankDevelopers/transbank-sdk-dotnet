using System;
using Xunit;
using Transbank.Common;
using Transbank.Patpass.PatpassComercio;

namespace Tests
{
    public class PatpassTests
    {
        [Fact]
        public void CorrectDefaultOptions()
        {
            Assert.Equal(IntegrationCommerceCodes.PATPASS_COMERCIO, (new Inscription()).Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.PATPASS_COMERCIO, (new Inscription()).Options.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            Assert.Equal("https://pagoautomaticocontarjetasint.transbank.cl", (new Inscription()).Options.IntegrationType.ApiBase);
        }
    }
}
