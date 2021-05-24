using System;
using Xunit;
using Transbank.Patpass.PatpassComercio;

namespace Tests
{
    public class PatpassTests
    {
        [Fact]
        public void CorrectDefaultOptions()
        {
            Assert.Equal("28299257", Inscription.CommerceCode);
            Assert.Equal("cxxXQgGD9vrVe4M41FIt", Inscription.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            Assert.Equal("https://pagoautomaticocontarjetasint.transbank.cl/", Inscription.IntegrationType.ApiBase);
        }
    }
}
