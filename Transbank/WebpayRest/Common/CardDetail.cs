using System;
using Newtonsoft.Json;

namespace Transbank.Webpay.Common
{
    public class CardDetail
    {
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        public override string ToString()
        {
            return $"CardNumber={CardNumber}";
        }
    }
}
