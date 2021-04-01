using System;
using Transbank.Webpay.Common;
using Newtonsoft.Json;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class MallFinishResponse
    {
        [JsonProperty("response_code")]
        public int ResponseCode { get; private set; }
        [JsonProperty("tbk_user")]
        public string TbkUser { get; private set; }
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; private set; }
        [JsonProperty("card_type")]
        public string CardType { get; private set; }
        [JsonProperty("card_number")]
        public string CardNumber { get; private set; }

        public MallFinishResponse(int responseCode, string transbankUser,
            string authorizationCode, string cardType, string cardNumber)
        {
            ResponseCode = responseCode;
            TbkUser = transbankUser;
            AuthorizationCode = authorizationCode;
            CardType = cardType;
            CardNumber = cardNumber;
        }

        public override string ToString()
        {
            return $"\"ResponseCode\": \"{ResponseCode}\"\n" + 
                   $"\"TransbankUser\": \"{TbkUser}\"\n" +
                   $"\"AuthorizationCode\": \"{AuthorizationCode}\"\n" +
                   $"\"CardType\": \"{CardType}\"\n" +
                   $"\"CardNumber\": \"{CardNumber}\"";
        }
    }
}
