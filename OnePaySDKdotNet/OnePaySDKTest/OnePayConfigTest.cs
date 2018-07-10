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
    }
}