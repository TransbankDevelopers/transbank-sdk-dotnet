namespace OnePaySDK.Model
{
    public class Item
    {
        private string Description { get; set; }
        private int Quantity { get; set; }
        private int Amount { get; set; }
        private string AdditionalData { get; set; }
        private long Expire { get; set; }

        public Item() { }

        public Item(string description, int quantity, int amount, string additionalData, long expire)
        {
            Description = description;
            Quantity = quantity;
            Amount = amount;
            AdditionalData = additionalData;
            Expire = expire;
        }
    }
}