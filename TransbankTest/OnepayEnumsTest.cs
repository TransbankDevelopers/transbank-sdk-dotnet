using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Onepay.Enums;

namespace TransbankTest
{
    [TestClass]
    public class OnepayEnumsTest
    {
        [TestMethod]
        public void OnepayIntegrationTypeTest()
        {
            var type = OnepayIntegrationType.LIVE;
            Assert.AreEqual("LIVE", type.Key);
            Assert.AreEqual("", type.Value);

            type = OnepayIntegrationType.TEST;
            Assert.AreEqual("TEST", type.Key);
            Assert.AreEqual("https://web2desa.test.transbank.cl",type.Value);

            type = OnepayIntegrationType.MOCK;
            Assert.AreEqual("MOCK", type.Key);
            Assert.AreEqual("http://onepay.getsandbox.com", type.Value);
        }
    }
}
