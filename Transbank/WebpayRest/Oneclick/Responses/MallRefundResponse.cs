using Newtonsoft.Json;

namespace Transbank.WebpayRest.Oneclick.Responses
{
    public class MallRefundResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("balance")]
        public decimal Balance { get; set; }
        
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }
        
        [JsonProperty("authorization_date")]
        public string AuthorizationDate { get; set; }
        
        [JsonProperty("nullified_amount")]
        public decimal NullifiedAmount { get; set; }

        public MallRefundResponse(string type, decimal balance, string authorizationCode, int responseCode, string authorizationDate, decimal nullifiedAmount)
        {
            Type = type;
            Balance = balance;
            AuthorizationCode = authorizationCode;
            ResponseCode = responseCode;
            AuthorizationDate = authorizationDate;
            NullifiedAmount = nullifiedAmount;
        }
        public override string ToString()
        {
            return $"\"Type\": {Type}\"\n" +
                   $"\"Balance\": {Balance}\"\n" +
                   $"\"AuthorizationCode\": {AuthorizationCode}\"\n" +
                   $"\"ResponseCode\": {ResponseCode}\"\n" +
                   $"\"AuthorizationDate\": {AuthorizationDate}\"\n" +
                   $"\"NullifiedAmount\": {NullifiedAmount}\"\n" ;
        }
    }
}
