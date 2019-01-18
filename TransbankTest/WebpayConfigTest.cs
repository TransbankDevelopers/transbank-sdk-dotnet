using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Webpay;

namespace TransbankTest
{
    [TestClass]
    public class WebpayConfigTest
    {
        [TestMethod]
        public void TestWebpayNormalTransaccionConfig()
        {
            var config = Configuration.ForTestingWebpayPlusNormal();

            Assert.AreEqual("597020000540", config.CommerceCode);
            Assert.AreEqual("INTEGRACION", config.Environment);
            Assert.AreEqual("", config.Password);
            Assert.IsTrue(config.PublicCert.Contains(@"\Webpay\IntegrationCerts\tbk.pem"));
            Assert.IsTrue(config.WebpayCert.Contains(@"\Webpay\IntegrationCerts\WebpayPlusCLP.pfx"));
        }
    }
}
