using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Onepay;
using Transbank.Onepay.Enums;

namespace TransbankTest
{
    [TestClass]
    public class OnepayConfigTest
    {
        [TestMethod]
        public void TestOnepaySettings()
        {
            Assert.AreEqual(OnepayIntegrationType.Test, Onepay.IntegrationType);
            Assert.AreEqual("dKVhq1WGt_XapIYirTXNyUKoWTDFfxaEV63-O5jcsdw", Onepay.ApiKey);
            Assert.AreEqual("?XW#WOLG##FBAGEAYSNQ5APD#JF@$AYZ", Onepay.SharedSecret);
        }
    }
}
