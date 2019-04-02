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
            Onepay.IntegrationType = OnepayIntegrationType.Mock;
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
            Assert.AreEqual("dKVhq1WGt_XapIYirTXNyUKoWTDFfxaEV63-O5jcsdw", request.ApiKey);
            Assert.AreEqual("04533c31-fe7e-43ed-bbc4-1c8ab1538afp", request.AppKey);
            Assert.AreEqual("WEB", request.Channel);
            Assert.AreEqual("123-456-789-192", request.ExternalUniqueNumber);
            Assert.AreEqual(2, request.Items.Count);
            Assert.AreEqual(2, request.ItemsQuantity);
            Assert.AreEqual(15000, request.Total);
            Assert.IsNull(request.CommerceLogoUrl);
            Assert.IsNull(request.QrWidthHeight);
        }

        [TestMethod]
        public void OnepayRequestBuilderBuildSendTransactionRequestWithCommerceLogoUrlAndwidthHeight()
        {
            var cart = CreateCart();
            var number = "123-456-789-192";
            var request = OnepayRequestBuilder.Instance.BuildSendTransactionRequest(cart: cart, externalUniqueNumber: number, channel: Onepay.DefaultChannel, options: new Options(commerceLogoUrl: "http://asd.asd", qrWidthHeight: 17));
            Assert.AreEqual("http://asd.asd", request.CommerceLogoUrl);
            Assert.AreEqual(17, request.QrWidthHeight);
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
