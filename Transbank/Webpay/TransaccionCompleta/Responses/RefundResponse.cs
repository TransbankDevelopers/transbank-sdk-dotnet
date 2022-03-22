using System;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.TransaccionCompleta.Common;

namespace Transbank.Webpay.TransaccionCompleta.Responses
{
    public class RefundResponse : BaseResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        
        [JsonProperty("authorization_date")]
        public DateTime? AuthorizationDate { get; set; }
        
        [JsonProperty("nullified_amount")]
        public decimal? NullifiedAmount { get; set; }
        
        [JsonProperty("balance")]
        public decimal? Balance { get; set; }
        
        [JsonProperty("response_code")]
        public int? ResponseCode { get; set; }
        [JsonProperty("prepaid_balance")]
        public decimal? PrepaidBalance { get; set; }

        public override string ToString()
        {
            return $"\"Type\":\"{Type}\"\n" +
                   $"\"AuthorizationCode\":\"{AuthorizationCode}\"\n" +
                   $"\"AuthorizationDate\":\"{AuthorizationDate}\"\n" +
                   $"\"NullifiedAmount\":\"{NullifiedAmount}\"\n" +
                   $"\"Balance\":\"{Balance}\"\n" +
                   $"\"ResponseCode\":\"{ResponseCode}\"\n";
        }
    }
}
