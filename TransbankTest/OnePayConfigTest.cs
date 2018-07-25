using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.OnePay;
using Transbank.OnePay.Enums;

namespace TransbankTest
{
    [TestClass]
    public class OnePayConfigTest
    {
        [TestMethod]
        public void TestOnePaySettings()
        {
            Assert.IsNull(OnePay.ApiKey);
            Assert.IsNull(OnePay.SharedSecret);

            OnePay.ApiKey = "mUc0GxYGor6X8u-_oB3e-HWJulRG01WoC96-_tUA3Bg";
            OnePay.SharedSecret = "P4DCPS55QB2QLT56SQH6#W#LV76IAPYX";

            Assert.AreEqual(OnePayIntegrationType.TEST, OnePay.IntegrationType);
            Assert.AreEqual("mUc0GxYGor6X8u-_oB3e-HWJulRG01WoC96-_tUA3Bg", OnePay.ApiKey);
            Assert.AreEqual("P4DCPS55QB2QLT56SQH6#W#LV76IAPYX", OnePay.SharedSecret);
        }
    }
}
