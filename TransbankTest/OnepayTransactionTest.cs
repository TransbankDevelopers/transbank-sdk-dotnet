using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Onepay;
using Transbank.Onepay.Model;
using Transbank.Onepay.Enums;

namespace TransbankTest
{
    [TestClass]
    public class OnepaySendTransactionTest
    {
        [TestInitialize]
        public void Setup()
        {
            // Setting comerce data
            Onepay.SharedSecret = "P4DCPS55QB2QLT56SQH6#W#LV76IAPYX";
            Onepay.ApiKey = "mUc0GxYGor6X8u-_oB3e-HWJulRG01WoC96-_tUA3Bg";
            Onepay.IntegrationType = OnepayIntegrationType.MOCK;
        }

        public ShoppingCart CreateCart()
        {
            // Setting items to the shopping cart
            var cart = new ShoppingCart();
            cart.Add(new Item("Zapatos", 1, 10000, null, -1));
            cart.Add(new Item("Pantalon", 1, 5000, null, -1));
            return cart;
        }

        [TestMethod]
        public void TestOnepaySendtransaction()
        {
            var cart = CreateCart();
            var response = Transaction.Create(cart);

            Assert.IsNotNull(response);

            Assert.AreEqual("1807983490979289", response.Occ);
            Assert.AreEqual(64181789, response.Ott);
            Assert.AreEqual("USrtuoyAU3l5qeG3Gm2fnxKRs++jQaf1wc8lwA6EZ2o=", response.Signature);
            Assert.AreEqual("f506a955-800c-4185-8818-4ef9fca97aae", response.ExternalUniqueNumber);
            Assert.AreEqual(1532103896, response.IssuedAt);

            string qrBase64 = "iVBORw0KGgoAAAANSUhEUgAAAMgAAADICAYAAACtWK6eAAADmElEQVR42u3dQW4CMRBE0bn/peEEbBCmq9rvS9lFxDP221jEfl6SPvZ4BRIgEiASIBIgEiASIBIgEiASIJIAkQCRAJEAkQCRAJEAkQCRAJEAkQSIBIgEiASIdAuQ53kqfn71XKffT9rntMwXIIAAAggggAACCCCAAAIIIIAAAsh/FlLLeKYWxunP2TpfgAACCCCAAAIIIIAAAggggAACCCDfPeDUQto6ntvmCxBAAAEEEEAAAQQQQAABBBBAAAHkTiBT4zw9HkAAAQQQQAABBBBAAAEEEEAAAQQQQG5+4S3breYLEEAAAQQQQAABBBBAAAEEEEAAASTlAZMW8FYgm9cPIIAAAggggAACCCCAAAIIIIAAAkjPcfp+3/UHgAACCCCAAAIIIIAAAggggAACyA1A2ku7tiBxIa2de68AEAECiAABBBBAAAEEEEAAuQhI+wJrv55gapynxw8IIIAAAggggAACCCCAAAIIIIAA8h8gUwvg9IJp34adGqdv8wICCCCAAAIIIIAAAggggAACCCA7gLRc4pm2UG/bZgcEEEAAAQQQQAABBBBAAAEEEEAAyQTSss3Ycl1C2vYyIIAAAggggAACCCCAAAIIIIAAAkjmwXFp1wGkPW/atvDWeQEEEEAAAQQQQAABBBBAAAEEEEAA+W4i2hd2y/O2/8szIIAAAggggAACCCCAAAIIIIAAAkjmtu3Ugkw7mK4dDiCAAAIIIIAAAggggAACCCCAAALI7m3etG3JlvfQAhYQQAABBBBAAAEEEEAAAQQQQAAB5M6D47aCmgLYcrAeIIAAAggggAACCCCAAAIIIIAAAsju2oG3XBvhy4qAAAIIIIAAAggggAgQQAQIIJnbvGk/p8ffAnPrNjIggAACCCCAAAIIIIAAAggggAACyG8numXbNm27Mu3vblg/gAACCCCAAAIIIIAAAggggAACCCBz26q3HYzWsp0OCCCAAAIIIIAAAggggAACCCCAAALIiRfe8qXKtHlJPCAOEEAAAQQQQAABBBBAAAEEEEAAAWTvNm/L52z9u4AAAggggAACCCCAAAIIIIAAAgggs0BawJ4eT/sCa4IACCCAAAIIIIAAAggggAACCCCAAOL6gy2XeG49cA8QQAABBBBAAAEEEEAAAQQQQAABROoOEAkQCRAJEAkQCRAJEAkQCRAJEEmASIBIgEiASIBIgEiASIBIgEiASAJEAkQCRAJESugNVyLVvcNSF1EAAAAASUVORK5CYII=";
            Assert.AreEqual(qrBase64, response.QrCodeAsBase64);
        }

        [TestMethod]
        public void TestOnepayCommitTransaction()
        {
            var options = new Options(
                "mUc0GxYGor6X8u-_oB3e-HWJulRG01WoC96-_tUA3Bg",
                "P4DCPS55QB2QLT56SQH6#W#LV76IAPYX"
                );

            var externalNumber = "f506a955-800c-4185-8818-4ef9fca97aae";
            var occ = "1807983490979289";

            var response = Transaction.Commit(
                occ, externalNumber, options);

            Assert.IsNotNull(response);
            Assert.AreEqual("1807983490979289", response.Occ);
            Assert.AreEqual("623245", response.AuthorizationCode);
            Assert.AreEqual(1532104549, response.IssuedAt);
            Assert.AreEqual("FfY4Ab89rC8rEf0qnpGcd0L/0mcm8SpzcWhJJMbUBK0=", response.Signature);
            Assert.AreEqual(27500, response.Amount);
            Assert.AreEqual("Venta Normal: Sin cuotas", response.TransactionDesc);
            Assert.AreEqual(27500, response.InstallmentsAmount);
            Assert.AreEqual(1, response.InstallmentsNumber);
            Assert.AreEqual("20180720122456123", response.BuyOrder);

        }

        [TestMethod]
        public void TestOnepayRefundTransaction()
        {
            var amount = 27500;
            var occ = "1807983490979289";
            var externalUniqueNumber = "f506a955-800c-4185-8818-4ef9fca97aae";
            var authorizationCode = "623245";

            var response = Refund.Create(amount, occ, 
                externalUniqueNumber, authorizationCode);

            Assert.IsNotNull(response);
            Assert.AreEqual("1807983490979289", response.Occ);
            Assert.AreEqual("f506a955-800c-4185-8818-4ef9fca97aae", response.ExternalUniqueNumber);
            Assert.AreEqual("623245", response.ReverseCode);
            Assert.AreEqual(1532104252, response.IssuedAt);
            Assert.AreEqual("52NpZBolTEs+ckNOXwGRexDetY9MOaX1QbFYkjPymf4=", response.Signature);
        }
    }
}
