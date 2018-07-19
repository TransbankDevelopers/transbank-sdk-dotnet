using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Enums;

namespace TransbankTest
{
    [TestClass]
    public class TransbankEnumTest
    {
        [TestMethod]
        public void OnePayIntegrationTypeTest()
        {
            var type = OnePayIntegrationType.LIVE;
            Assert.AreEqual("LIVE", type.Key);
            Assert.AreEqual("", type.Value);

            type = OnePayIntegrationType.TEST;
            Assert.AreEqual("TEST", type.Key);
            Assert.AreEqual("https://web2desa.test.transbank.cl",type.Value);

            type = OnePayIntegrationType.MOCK;
            Assert.AreEqual("MOCK", type.Key);
            Assert.AreEqual("http://onepay.getsandbox.com", type.Value);
        }
    }
}
