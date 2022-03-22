using System;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class MallCaptureResponse : BaseResponse
    {
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        
        [JsonProperty("authorization_date")]
        public DateTime? AuthorizationDate { get; set; }
        
        [JsonProperty("captured_amount")]
        public decimal? CapturedAmount { get; set; }
        
        [JsonProperty("response_code")]
        public byte? ResponseCode { get; set; }

        public MallCaptureResponse(string authorizationCode, DateTime authorizationDate, decimal capturedAmount, byte responseCode)
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
