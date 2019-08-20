using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompleta.Common
{
    public class CardDetail
    {
        [JsonProperty("card_number")]
        internal string CardNumber { get; }

        public CardDetail(string cardNumber)
        {
            CardNumber = cardNumber;
        }
    }
}
