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
            Assert.IsTrue(config.TbkPublicCertPath.Contains(@"\TransbankIntegrationPublic.pem"));
            Assert.IsTrue(config.CommercePfxPath.Contains(@"\WebpayPlusCLP.p12"));
        }
        public void ForTestingWebpayOneClickNormal()
        {
            var config = Configuration.ForTestingWebpayPlusNormal();

            Assert.AreEqual("597044444405", config.CommerceCode);
            Assert.AreEqual("INTEGRACION", config.Environment);
            Assert.AreEqual("12345678", config.Password);
            Assert.IsTrue(config.TbkPublicCertPath.Contains(@"\TransbankIntegrationPublic.pem"));
            Assert.IsTrue(config.CommercePfxPath.Contains(@"\WebpayOneClickCLP.p12"));
        }
        public void ForTestingWebpayPlusCapture()
        {
            var config = Configuration.ForTestingWebpayPlusNormal();

            Assert.AreEqual("597044444404", config.CommerceCode);
            Assert.AreEqual("INTEGRACION", config.Environment);
            Assert.AreEqual("12345678", config.Password);
            Assert.IsTrue(config.TbkPublicCertPath.Contains(@"\TransbankIntegrationPublic.pem"));
            Assert.IsTrue(config.CommercePfxPath.Contains(@"\WebpayPlusCaptureCLP.p12"));
        }
        public void ForTestingWebpayPlusMall()
        {
            var config = Configuration.ForTestingWebpayPlusNormal();

            Assert.AreEqual("597044444401", config.CommerceCode);
            Assert.AreEqual("INTEGRACION", config.Environment);
            Assert.AreEqual("12345678", config.Password);
            Assert.IsTrue(config.TbkPublicCertPath.Contains(@"\TransbankIntegrationPublic.pem"));
            Assert.IsTrue(config.CommercePfxPath.Contains(@"\WebpayPlusMallCLP.p12"));
        }
    }
}
