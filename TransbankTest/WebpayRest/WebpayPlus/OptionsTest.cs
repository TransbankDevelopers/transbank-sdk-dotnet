using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Webpay.Common;

namespace TransbankTest.WebpayRest.WebpayPlus
{
    [TestClass]
    public class OptionsTest
    {
        [TestMethod]
        public void TestDefaultConfiguration()
        {
            var options = Transbank.Webpay.WebpayPlus.WebpayPlus.DefaultOptions();
            Assert.AreEqual("597055555532", options.CommerceCode);
            Assert.AreEqual("579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C", options.ApiKey);
            Assert.AreEqual(options.IntegrationType, WebpayIntegrationType.Live);
        }

        [TestMethod]
        public void TestApiKeyNotNull() => Assert.ThrowsException<ArgumentNullException>(() => new Options(null, "somecommercecode", WebpayIntegrationType.Live));

        [TestMethod]
        public void TestCommerceCodeNotNull() => Assert.ThrowsException<ArgumentNullException>(() => new Options("someapikey", null, WebpayIntegrationType.Live));

        [TestMethod]
        public void TestIntegrationTypeNotNull() => Assert.ThrowsException<ArgumentNullException>(() => new Options("someapikey", "somecommercecode", null));
    }
}
