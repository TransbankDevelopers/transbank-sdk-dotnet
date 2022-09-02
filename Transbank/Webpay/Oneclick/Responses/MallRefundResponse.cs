using System;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class MallRefundResponse : BaseResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("balance")]
        public decimal? Balance { get; set; }
        
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        
        [JsonProperty("response_code")]
        public int? ResponseCode { get; set; }
        
        [JsonProperty("authorization_date")]
        public DateTime? AuthorizationDate { get; set; }
        
        [JsonProperty("nullified_amount")]
        public decimal? NullifiedAmount { get; set; }
        [JsonProperty("prepaid_balance")]
        public decimal? PrepaidBalance { get; set; }

        public override string ToString()
        {
            return $"\"Type\": \"{Type}\"\n" +
                   $"\"Balance\": \"{Balance}\"\n" +
                   $"\"AuthorizationCode\": \"{AuthorizationCode}\"\n" +
                   $"\"ResponseCode\": \"{ResponseCode}\"\n" +
                   $"\"AuthorizationDate\": \"{AuthorizationDate}\"\n" +
                   $"\"PrepaidBalance\": \"{PrepaidBalance}\"\n" +
                   $"\"NullifiedAmount\": \"{NullifiedAmount}\"\n" ;
        }
    }
}
