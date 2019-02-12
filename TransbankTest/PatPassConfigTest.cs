using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.PatPass;

namespace TransbankTest
{
    [TestClass]
    public class PatPassConfigTest
    {
        [TestMethod]
        public void TestWebpayNormalTransaccionConfig()
        {
            var config = Configuration.ForTestingPatPassByWebpayNormal();

            Assert.AreEqual("597044444432", config.CommerceCode);
            Assert.AreEqual("INTEGRACION", config.Environment);
            Assert.AreEqual("user@domain.com", config.CommerceMail);
            Assert.IsFalse(config.UfFlag);
            Assert.AreEqual("12345678", config.Password);
            Assert.IsTrue(config.WebpayCertPath.Contains("TransbankIntegrationPublic.pem"));
            Assert.IsTrue(config.PrivateCertPfxPath.Contains("PatPassNormalCLP.p12"));
        }
    }
}
