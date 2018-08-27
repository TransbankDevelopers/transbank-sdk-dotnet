using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Onepay.Net;
using Transbank.Onepay;

namespace TransbankTest
{
    [TestClass]
    public class OnepaySendTransactionRequestTest
    {
        [TestMethod]
        public void OnepaySendTransactionRequestDataToSign()
        {
            var a = new SendTransactionRequest(externalUniqueNumber: "1", total: 100, itemsQuantity: 3,
                issuedAt: 5, items: null, callbackUrl: "TestURL", channel: Onepay.DefaultChannel.Value);
            Assert.AreEqual("11310013157TestURL", a.GetDataToSign());
        }
    }
}
