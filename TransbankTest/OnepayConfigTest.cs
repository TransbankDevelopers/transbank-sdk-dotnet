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
            Assert.IsNull(Onepay.ApiKey);
            Assert.IsNull(Onepay.SharedSecret);

            Onepay.ApiKey = "mUc0GxYGor6X8u-_oB3e-HWJulRG01WoC96-_tUA3Bg";
            Onepay.SharedSecret = "P4DCPS55QB2QLT56SQH6#W#LV76IAPYX";

            Assert.AreEqual(OnepayIntegrationType.TEST, Onepay.IntegrationType);
            Assert.AreEqual("mUc0GxYGor6X8u-_oB3e-HWJulRG01WoC96-_tUA3Bg", Onepay.ApiKey);
            Assert.AreEqual("P4DCPS55QB2QLT56SQH6#W#LV76IAPYX", Onepay.SharedSecret);
        }
    }
}
