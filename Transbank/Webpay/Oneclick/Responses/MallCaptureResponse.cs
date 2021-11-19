using Newtonsoft.Json;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class MallCaptureResponse
    {
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        
        [JsonProperty("authorization_date")]
        public string AuthorizationDate { get; set; }
        
        [JsonProperty("captured_amount")]
        public double CapturedAmount { get; set; }
        
        [JsonProperty("response_code")]
        public byte ResponseCode { get; set; }

        public MallCaptureResponse(string authorizationCode, string authorizationDate, double capturedAmount, byte responseCode)
        {
            AuthorizationCode = authorizationCode;
            AuthorizationDate = authorizationDate;
            CapturedAmount = capturedAmount;
            ResponseCode = responseCode;
        }

        public override string ToString()
        {
            return $"\"AuthorizationCode\": \"{AuthorizationCode}\"\n" +
                   $"\"AuthorizationDate\": \"{AuthorizationDate}\"\n" +
                   $"\"CapturedAmount\": \"{CapturedAmount}\"\n" +
                   $"\"ResponseCode\":\"{ResponseCode}\"";
        }
    }
}
