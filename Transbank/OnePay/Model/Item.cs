using Newtonsoft.Json;

namespace Transbank.Model
{
    public class Item
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("additionalData")]
        public string AdditionalData { get; set; }
        [JsonProperty("expire")]
        public long Expire { get; set; }

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
