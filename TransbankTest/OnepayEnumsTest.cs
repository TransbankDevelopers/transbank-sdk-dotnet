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
            var type = OnepayIntegrationType.Live;
            Assert.AreEqual("LIVE", type.Key);
            Assert.AreEqual("", type.Value);

            type = OnepayIntegrationType.Test;
            Assert.AreEqual("TEST", type.Key);
            Assert.AreEqual("https://web2desa.test.transbank.cl",type.Value);

            type = OnepayIntegrationType.Mock;
            Assert.AreEqual("MOCK", type.Key);
            Assert.AreEqual("http://onepay.getsandbox.com", type.Value);
        }
    }
}
