using Transbank.Webpay.Common;
using Newtonsoft.Json;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class FinishResponse
    {
        [JsonProperty("response_code")]
        public int ResponseCode { get; private set; }
        [JsonProperty("tbk_user")]
        public string TransbankUser { get; private set; }
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; private set; }
        [JsonProperty("credit_card_type")]
        public string CreditCardType { get; private set; }
        [JsonProperty("last_four_card_digits")]
        public string LastFourCardDigits { get; private set; }

        public FinishResponse(int responseCode, string transbankUser,
            string authorizationCode, string creditCardType, string lastFourCardDigits)
        {
            ResponseCode = responseCode;
            TransbankUser = transbankUser;
            AuthorizationCode = authorizationCode;
            CreditCardType = creditCardType;
            LastFourCardDigits = lastFourCardDigits;
        }

        public override string ToString()
        {
            return $"Response Code = {ResponseCode}\n" + 
                   $"Transbank User = {TransbankUser}\n" +
                   $"Authorization Code = {AuthorizationCode}\n" +
                   $"Credit Card Type = {CreditCardType}\n" +
                   $"Last Four Card Digits = {LastFourCardDigits}";
        }
    }
}
