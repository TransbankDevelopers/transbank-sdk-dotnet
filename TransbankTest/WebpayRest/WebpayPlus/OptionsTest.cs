using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Common;
using Transbank.Webpay.Common;

namespace TransbankTest.WebpayRest.WebpayPlus
{
    [TestClass]
    public class OptionsTest
    {
        [TestMethod]
        public void TestDefaultConfiguration()
        {
            var options = Transbank.Webpay.WebpayPlus.Transaction.DefaultOptions();
            Assert.AreEqual("597055555532", options.CommerceCode);
            Assert.AreEqual("579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C", options.ApiKey);
            Assert.AreEqual(options.IntegrationType, WebpayIntegrationType.Test);
            
            
        }
        
        private static string _commerceCodeHeaderName = "Tbk-Api-Key-Id";
        private static string _apiKeyHeaderName = "Tbk-Api-Key-Secret";

        private static RequestServiceHeaders _headers = new RequestServiceHeaders(_apiKeyHeaderName, _commerceCodeHeaderName);

        public static RequestServiceHeaders Headers
        {
            get => _headers;
            set => _headers = value ?? throw new ArgumentNullException(
                                  nameof(value), "Integration type can't be null."
                              );
        }

        [TestMethod]
        public void TestCommerceCodeNotNull() => Assert.ThrowsException<ArgumentNullException>(() => new Options(null, "someapikey", WebpayIntegrationType.Test, Headers));

        [TestMethod]
        public void TestApiKeyNotNull() => Assert.ThrowsException<ArgumentNullException>(() => new Options("somecommercecode", null, WebpayIntegrationType.Test, Headers));

        [TestMethod]
        public void TestIntegrationTypeNotNull() => Assert.ThrowsException<ArgumentNullException>(() => new Options("someapikey", "somecommercecode", null, Headers));
    }
}
