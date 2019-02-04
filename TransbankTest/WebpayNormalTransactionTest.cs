using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Webpay;

namespace TransbankTest
{
    [TestClass]
    public class WebpayNormalTransactionTest
    {        
        [TestMethod]
        public void TestWebpayNormaltransaction()
        {
            var transaction = new Webpay(Configuration.ForTestingWebpayPlusNormal()).NormalTransaction;

            Assert.IsNotNull(transaction);

            var initResult = transaction.initTransaction(
                    1000, new Random().Next(100000, 999999999).ToString(), 
                        "mi-id-de-sesion", "https://callback/resultado/de/transaccion",
                            "https://callback/final/post/comprobante/webpay");

            Assert.AreEqual("https://webpay3gint.transbank.cl/webpayserver/initTransaction", initResult.url);
        }
    }
}
