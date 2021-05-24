using Transbank.Onepay.Exceptions;
using Transbank.Onepay.Model;
using Xunit;

namespace Tests
{
    public class OnepayModelTests
    {
        [Fact]
        public void ItemTest()
        {
            var item = new Item("Test Item", 4, 5000, "Item for test", 10);

            Assert.Equal("Test Item", item.Description);
            Assert.Equal(4, item.Quantity);
            Assert.Equal(5000, item.Amount);
            Assert.Equal("Item for test", item.AdditionalData);
            Assert.Equal(10, item.Expire);

            var result = "Description=Test Item ,Quantity=4, " +
                "Amount=5000, AdditionalData=Item for test, " +
                "Expire=10";

            Assert.Equal(result, item.ToString());
        }

        [Fact]
        public void OptionsTest()
        {
            var options = new Options("SuP3r-S3cr37-4P1Ky", "SuperSharedSecret");

            Assert.Equal("SuP3r-S3cr37-4P1Ky", options.ApiKey);
            Assert.Equal("SuperSharedSecret", options.SharedSecret);

            options.ApiKey = "NewApiKey-09876";

            Assert.Equal("NewApiKey-09876", options.ApiKey);
        }

        [Fact]
        public void ShopingCartAddItemsTest()
        {
            var item1 = new Item("item 1", 1, 200, null, 10);
            var item2 = new Item("item 2", 5, 500, null, 10);
            var item3 = new Item("item 3", 2, 1000, "", 10);

            var cart = new ShoppingCart();
            cart.Add(item1);
            Assert.Equal(1, cart.ItemQuantity);
            Assert.Equal(200, cart.Total);

            cart.Add(item2);
            Assert.Equal(6, cart.ItemQuantity);
            Assert.Equal(2700, cart.Total);

            cart.Add(item3);
            Assert.Equal(8, cart.ItemQuantity);
            Assert.Equal(4700, cart.Total);
        }

        [Fact]
        public void ShopingCartAddWithItemNegativeValueTest()
        {
            var item1 = new Item("item 1", 1, 200, null, 10);
            var item2 = new Item("item discount", 1, -10, "", 10);

            var cart = new ShoppingCart();
            cart.Add(item1);
            Assert.Equal(1, cart.ItemQuantity);
            Assert.Equal(200, cart.Total);

            cart.Add(item2);
            Assert.Equal(2, cart.ItemQuantity);
            Assert.Equal(190, cart.Total);
        }

        [Fact]
        public void ShopingCartAddWithItemNegativeValueGreaterThanTotalAmountTest()
        {
            var item1 = new Item("item 1", 1, 200, null, 10);
            var item2 = new Item("item discount", 1, -201, "", 10);

            var cart = new ShoppingCart();
            cart.Add(item1);
            Assert.Equal(1, cart.ItemQuantity);
            Assert.Equal(200, cart.Total);

            Assert.Throws<AmountException>(() => cart.Add(item2));
        }

        [Fact]
        public void ShopingCartRemoveItemsTest()
        {
            var item1 = new Item("item 1", 1, 200, null, 10);
            var item2 = new Item("item 2", 5, 500, null, 10);
            var item3 = new Item("item 3", 2, 1000, "", 10);

            var cart = new ShoppingCart();
            cart.Add(item1);
            cart.Add(item3);
            cart.Add(item2);

            Assert.Equal(8, cart.ItemQuantity);
            Assert.Equal(4700, cart.Total);

            cart.Remove(item1);
            Assert.Equal(7, cart.ItemQuantity);
            Assert.Equal(4500, cart.Total);

            cart.Remove(item2);
            cart.Remove(item3);
            Assert.Equal(0, cart.ItemQuantity);
            Assert.Equal(0, cart.Total);
        }
    }
}
