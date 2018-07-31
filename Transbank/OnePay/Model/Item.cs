using Newtonsoft.Json;

namespace Transbank.OnePay.Model
{
    public class Item
    {
        [JsonProperty("description")]
        public string Description { get; }
        [JsonProperty("quantity")]
        public int Quantity { get; }
        [JsonProperty("amount")]
        public int Amount { get; }
        [JsonProperty("additionalData")]
        public string AdditionalData { get; }
        [JsonProperty("expire")]
        public long Expire { get; }

        public Item() { }

        public Item(string description,int quantity, int amount, 
            string additionalData, long expire)
        {
            Description = description;
            Quantity = quantity;
            Amount = amount;
            AdditionalData = additionalData;
            Expire = expire;
        }

        public override string ToString()
        {
            return $"Description={Description} ,Quantity={Quantity}, " +
                $"Amount={Amount}, AdditionalData={AdditionalData}, " +
                $"Expire={Expire}".Trim();
        }
    }
}
