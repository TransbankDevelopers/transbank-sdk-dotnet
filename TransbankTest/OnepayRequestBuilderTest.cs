using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Onepay.Utils;
using Transbank.Onepay.Model;
using Transbank.Onepay.Enums;
using Transbank.Onepay;

namespace TransbankTest
{
    [TestClass]
    public class OnepayRequestBuilderTest
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
            ShoppingCart cart = new ShoppingCart();
            cart.Add(new Item("Zapatos", 1, 10000, null, -1));
            cart.Add(new Item("Pantalon", 1, 5000, null, -1));
            return cart;
        }

        [TestMethod]
        public void OnepayRequestBuilderBuildSendTransactionRequest()
        {
            var cart = CreateCart();
            var number = "123-456-789-192";
            var request = OnepayRequestBuilder.Instance.BuildSendTransactionRequest(cart: cart, externalUniqueNumber: number, channel: Onepay.DefaultChannel, options: new Options());
            Assert.AreEqual("mUc0GxYGor6X8u-_oB3e-HWJulRG01WoC96-_tUA3Bg", request.ApiKey);
            Assert.AreEqual("04533c31-fe7e-43ed-bbc4-1c8ab1538afp", request.AppKey);
            Assert.AreEqual("http://no.callback.has/been.set", request.CallbackUrl);
            Assert.AreEqual("WEB", request.Channel);
            Assert.AreEqual("123-456-789-192", request.ExternalUniqueNumber);
            Assert.AreEqual(2, request.Items.Count);
            Assert.AreEqual(2, request.ItemsQuantity);
            Assert.AreEqual(15000, request.Total);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OnepayRequestBuilderBuildSendTransactionRequestNullExternalUniqueNumber()
        {
            var cart = CreateCart();
            OnepayRequestBuilder.Instance.BuildSendTransactionRequest(cart: cart, externalUniqueNumber: null, channel: Onepay.DefaultChannel, options: new Options());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OnepayRequestBuilderSendTransactionRequestNullOptions()
        {
            var cart = CreateCart();
            OnepayRequestBuilder.Instance.BuildSendTransactionRequest(cart: cart, externalUniqueNumber: "1", channel: Onepay.DefaultChannel, options: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OnepayRequestBuilderSendTransactionRequestNullCart()
        {
           OnepayRequestBuilder.Instance.BuildSendTransactionRequest(cart: null, externalUniqueNumber: "1", channel: Onepay.DefaultChannel, options: new Options());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OnepayRequestBuilderSendTransactionRequestNullChannel()
        {
            var cart = CreateCart();
           OnepayRequestBuilder.Instance.BuildSendTransactionRequest(cart: cart, externalUniqueNumber: "1", channel: null, options: new Options());
        }

    }
}
