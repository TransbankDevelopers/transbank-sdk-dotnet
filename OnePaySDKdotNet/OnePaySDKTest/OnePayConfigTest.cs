using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnePaySDK;

namespace OnePaySDKTest
{
    [TestClass]
    public class OnePayConfigTest
    {
        [TestMethod]
        public void TestOnePayIntegrationType()
        {
            Assert.IsTrue(OnePay.IntegrationType.CompareTo(IntegrationType.TEST) == 0);
            OnePay.IntegrationType = IntegrationType.LIVE;
            Assert.IsTrue(OnePay.IntegrationType.CompareTo(IntegrationType.LIVE) == 0);
        }

        [TestMethod]
        public void TestOnePaySettings()
        {
            Assert.IsNull(OnePay.ApiKey);
            Assert.IsNull(OnePay.AppKey);
            Assert.IsNull(OnePay.CallbackUrl);
            Assert.IsNull(OnePay.SharedSecret);

            OnePay.ApiKey = "mUc0GxYGor6X8u-_oB3e-HWJulRG01WoC96-_tUA3Bg";
            OnePay.AppKey = "04533c31-fe7e-43ed-bbc4-1c8ab1538afp";
            OnePay.CallbackUrl = "http://localhost:8080/ewallet-endpoints";
            OnePay.SharedSecret = "P4DCPS55QB2QLT56SQH6#W#LV76IAPYX";

            Assert.AreEqual(OnePay.IntegrationType, IntegrationType.TEST);
            Assert.AreEqual(OnePay.ApiKey, "mUc0GxYGor6X8u-_oB3e-HWJulRG01WoC96-_tUA3Bg");
            Assert.AreEqual(OnePay.AppKey, "04533c31-fe7e-43ed-bbc4-1c8ab1538afp");
            Assert.AreEqual(OnePay.CallbackUrl, "http://localhost:8080/ewallet-endpoints");
            Assert.AreEqual(OnePay.SharedSecret, "P4DCPS55QB2QLT56SQH6#W#LV76IAPYX");
        }
    }
}