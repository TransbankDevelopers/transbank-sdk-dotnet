using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Transbank.Onepay.Model;

namespace Transbank.Onepay.Net
{
    public sealed class SendTransactionRequest : BaseRequest, ISignable
    {
        [JsonProperty("externalUniqueNumber")]
        public string ExternalUniqueNumber { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
        [JsonProperty("itemsQuantity")]
        public int ItemsQuantity { get; set; }
        [JsonProperty("issuedAt")]
        public long IssuedAt { get; set; }
        [JsonProperty("items")]
        public ReadOnlyCollection<Item> Items { get; set; }
        [JsonProperty("callbackUrl")]
        public string CallbackUrl { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("signature")]
        public string Signature { get; set; }
        [JsonProperty("generateOttQrCode")]
        private readonly bool GenerateOttQrCode = true;
        [JsonProperty("commerceLogoUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string CommerceLogoUrl { get; set; }
        [JsonProperty("widthHeight", NullValueHandling = NullValueHandling.Ignore)]
        public string QrWidthHeight { get; set; }


        public SendTransactionRequest()
        {
        }
       
        public SendTransactionRequest(string externalUniqueNumber, long total, int itemsQuantity, 
            long issuedAt, ReadOnlyCollection<Item> items, string callbackUrl, 
            string channel, string commerceLogoUrl = null, int? qrWidthHeight = null)
        {
            ExternalUniqueNumber = externalUniqueNumber;
            Total = total;
            ItemsQuantity = itemsQuantity;
            IssuedAt = issuedAt;
            Items = items;
            CallbackUrl = callbackUrl;
            Channel = channel;
            CommerceLogoUrl = commerceLogoUrl;
            if (qrWidthHeight != null) QrWidthHeight = qrWidthHeight.ToString();
        }

        public string GetDataToSign()
        {
            return ExternalUniqueNumber.Length + ExternalUniqueNumber
                + Total.ToString().Length + Total.ToString()
                + ItemsQuantity.ToString().Length + ItemsQuantity.ToString()
                + IssuedAt.ToString().Length + IssuedAt.ToString()
                + CallbackUrl.Length + CallbackUrl;
        }

        public override string ToString()
        {
            Item[] itemsArray = new Item[Items.Count];
            Items.CopyTo(itemsArray, 0);
        
            return $"ExternalUniqueNumber={ExternalUniqueNumber}, Total={Total}, " +
                $"ItemsQuantity={ItemsQuantity}, IssuedAt={IssuedAt}, " +
                $"Items={string.Join<Item>(" , ", itemsArray)}," +
                $"CallbackUrl={CallbackUrl}, Channel={Channel}," +
                $"Signature={Signature}, GenerateOttQrCore={GenerateOttQrCode}, " +
                $"CommerceLogoUrl={CommerceLogoUrl}, QrWidthHeight={QrWidthHeight}";
        }
    }
}
