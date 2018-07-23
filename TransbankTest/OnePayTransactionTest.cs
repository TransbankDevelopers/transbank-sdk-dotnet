using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank;
using Transbank.Model;
using Transbank.Net;
using Transbank.Enums;

namespace TransbankTest
{
    [TestClass]
    public class OnePaySendTransactionTest
    {
        [TestMethod]
        public void TestOnePaySendtransaction()
        {
            // Setting comerce data
            OnePay.SharedSecret = "P4DCPS55QB2QLT56SQH6#W#LV76IAPYX";
            OnePay.ApiKey = "mUc0GxYGor6X8u-_oB3e-HWJulRG01WoC96-_tUA3Bg";
            OnePay.IntegrationType = OnePayIntegrationType.MOCK;

            // Setting items to the shopping cart
            ShoppingCart cart = new ShoppingCart();
            cart.Add(new Item("Zapatos", 1, 10000, null, -1));
            cart.Add(new Item("Pantalon", 1, 5000, null, -1));

            // Send transaction to Transbank
            TransactionCreateResponse response = Transaction.Create(cart);

            Assert.IsNotNull(response);
        }
    }
}
