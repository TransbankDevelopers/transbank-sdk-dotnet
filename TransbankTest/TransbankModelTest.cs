using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Model;

namespace TransbankTest
{
    [TestClass]
    public class TransbankModelTest
    {
        [TestMethod]
        public void ItemTest()
        {
            var item = new Item("Test Item", 4, 5000, "Item for test", 10);

            Assert.AreEqual("Test Item", item.Description);
            Assert.AreEqual(4, item.Quantity);

            Assert.AreEqual(5000, item.Amount);
            item.Amount = 10000;
            Assert.AreEqual(10000, item.Amount);

            Assert.AreEqual("Item for test", item.AdditionalData);
            Assert.AreEqual(10, item.Expire);

            var result = "Description=Test Item ,Quantity=4, " +
                "Amount=10000, AdditionalData=Item for test, " +
                "Expire=10";

            Assert.AreEqual(result, item.ToString());
        }

        [TestMethod]
        public void OptionsTest()
        {
            var options = new Options("SuP3r-S3cr37-4P1Ky", "SuperSharedSecret");

            Assert.AreEqual("SuP3r-S3cr37-4P1Ky", options.ApiKey);
            Assert.AreEqual("SuperSharedSecret", options.SharedSecret);

            options.ApiKey = "NewApiKey-09876";

            Assert.AreEqual("NewApiKey-09876", options.ApiKey);
        }

        [TestMethod]
        public void ShopingCartAddItemsTest()
        {
            var item1 = new Item("item 1", 1, 200, null, 10);
            var item2 = new Item("item 2", 5, 500, null, 10);
            var item3 = new Item("item 3", 2, 1000, "", 10);

            var cart = new ShoppingCart();
            cart.Add(item1);
            Assert.AreEqual(1, cart.ItemQuantity);
            Assert.AreEqual(200, cart.Total);

            cart.Add(item2);
            Assert.AreEqual(2, cart.ItemQuantity);
            Assert.AreEqual(2700, cart.Total);

            cart.Add(item3);
            Assert.AreEqual(3, cart.ItemQuantity);
            Assert.AreEqual(4700, cart.Total);
        }

        [TestMethod]
        public void ShopingCartRemoveItemsTest()
        {
            var item1 = new Item("item 1", 1, 200, null, 10);
            var item2 = new Item("item 2", 5, 500, null, 10);
            var item3 = new Item("item 3", 2, 1000, "", 10);

            var cart = new ShoppingCart();
            cart.Add(item1);
            cart.Add(item3);
            cart.Add(item2);

            Assert.AreEqual(3, cart.ItemQuantity);
            Assert.AreEqual(4700, cart.Total);

            cart.Remove(item1);
            Assert.AreEqual(2, cart.ItemQuantity);
            Assert.AreEqual(4500, cart.Total);

            cart.Remove(item2);
            cart.Remove(item3);
            Assert.AreEqual(0, cart.ItemQuantity);
            Assert.AreEqual(0, cart.Total);
        }
    }
}
