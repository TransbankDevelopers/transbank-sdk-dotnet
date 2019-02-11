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
            Assert.IsTrue(config.WebpayCertPath.Contains("TransbankIntegrationPublic.pem"));
            Assert.IsTrue(config.PrivateCertPfxPath.Contains("WebpayPlusCLP.p12"));
        }

        [TestMethod]
        public void ForTestingWebpayOneClickNormal()
        {
            var config = Configuration.ForTestingWebpayOneClickNormal();

            Assert.AreEqual("597044444405", config.CommerceCode);
            Assert.AreEqual("INTEGRACION", config.Environment);
            Assert.AreEqual("12345678", config.Password);
            Assert.IsTrue(config.WebpayCertPath.Contains("TransbankIntegrationPublic.pem"));
            Assert.IsTrue(config.PrivateCertPfxPath.Contains("WebpayOneClickCLP.p12"));
        }

        [TestMethod]
        public void ForTestingWebpayPlusCapture()
        {
            var config = Configuration.ForTestingWebpayPlusCapture();

            Assert.AreEqual("597044444404", config.CommerceCode);
            Assert.AreEqual("INTEGRACION", config.Environment);
            Assert.AreEqual("12345678", config.Password);
            Assert.IsTrue(config.WebpayCertPath.Contains("TransbankIntegrationPublic.pem"));
            Assert.IsTrue(config.PrivateCertPfxPath.Contains("WebpayPlusCaptureCLP.p12"));
        }

        [TestMethod]
        public void ForTestingWebpayPlusMall()
        {
            var config = Configuration.ForTestingWebpayPlusMall();

            Assert.AreEqual("597044444401", config.CommerceCode);
            Assert.AreEqual("INTEGRACION", config.Environment);
            Assert.AreEqual("12345678", config.Password);
            Assert.IsTrue(config.WebpayCertPath.Contains("TransbankIntegrationPublic.pem"));
            Assert.IsTrue(config.PrivateCertPfxPath.Contains("WebpayPlusMallCLP.p12"));
        }
    }
}
