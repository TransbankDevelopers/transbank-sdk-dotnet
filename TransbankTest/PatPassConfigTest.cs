using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Webpay;
using Transbank.PatPass;

namespace TransbankTest
{
    [TestClass]
    public class PatPassConfigTest
    {
        [TestMethod]
        public void TestWebpayNormalTransaccionConfig()
        {
            var config = Configuration.ForTestingPatPassByWebpayNormal("test@mail.com");

            Assert.AreEqual("597044444432", config.CommerceCode);
            Assert.AreEqual("INTEGRACION", config.Environment);
            Assert.AreEqual("test@mail.com", config.CommerceMail);
            Assert.AreEqual(PatPassByWebpayNormal.Currency.DEFAULT, config.PatPassCurrency);
            Assert.AreEqual("12345678", config.Password);
            Assert.IsTrue(config.WebpayCertPath.Contains("TransbankIntegrationPublic.pem"));
            Assert.IsTrue(config.PrivateCertPfxPath.Contains("PatPassNormalCLP.p12"));
        }
    }
}
