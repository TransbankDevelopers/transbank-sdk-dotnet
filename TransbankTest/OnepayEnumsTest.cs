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
            Assert.AreEqual("https://www.onepay.cl", type.ApiBase);
            Assert.AreEqual("81A33064-26DC-4267-8616-C97D252E7378", type.AppKey);

            type = OnepayIntegrationType.Test;
            Assert.AreEqual("TEST", type.Key);
            Assert.AreEqual("https://onepay.ionix.cl", type.ApiBase);
            Assert.AreEqual("297a620c-c776-4dd6-a42c-8669c6a4f2c5", type.AppKey);

            type = OnepayIntegrationType.Mock;
            Assert.AreEqual("MOCK", type.Key);
            Assert.AreEqual("https://transbank-onepay-ewallet-mock.herokuapp.com", type.ApiBase);
            Assert.AreEqual("04533c31-fe7e-43ed-bbc4-1c8ab1538afp", type.AppKey);
        }
    }
}
