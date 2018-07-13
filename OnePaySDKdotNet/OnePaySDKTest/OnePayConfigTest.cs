using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank;
using Transbank.Enums;

namespace OnePayTest
{
    [TestClass]
    public class OnePayConfigTest
    {
        [TestCleanup]
        public void BaseTestCleanup()
        {
            OnePay.IntegrationType = OnePayIntegrationType.TEST;
        }

        [TestMethod]
        public void TestOnePayIntegrationType()
        {
            Assert.IsTrue(OnePay.IntegrationType.Key.Equals(
                OnePayIntegrationType.TEST.Key));
            OnePay.IntegrationType = OnePayIntegrationType.LIVE;
            Assert.IsTrue(OnePay.IntegrationType.Key.Equals(
                OnePayIntegrationType.LIVE.Key));
        }

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