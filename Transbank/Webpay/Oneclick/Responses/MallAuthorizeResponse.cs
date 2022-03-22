using System;
using Newtonsoft.Json;
using Transbank.Webpay.Common;
using System.Collections.Generic;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class MallAuthorizeResponse : BaseResponse
    {
        [JsonProperty("buy_order")]
        public string BuyOrder { get; private set; }

        [JsonProperty("card_detail")]
        public CardDetail CardDetail { get; set; }

        [JsonProperty("expiration_date")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-mm-ddd")]
        public DateTime? ExpirationDate { get; private set; }

        [JsonProperty("accounting_date")]
        public string AccountingDate { get; private set; }

        [JsonProperty("transaction_date")]
        public DateTime? TransactionDate { get; private set; }

        [JsonProperty("details")]
        public List<PaymentResponse> Details{get; private set; }

        public override string ToString()
        {
            var details = "";
            Details.ForEach(i => details += "{\n"+ i.ToString() + "\n}\n");
            return $"\"BuyOrder\": \"{BuyOrder}\"\n" +
                   $"\"CardNumber\": \"{CardDetail?.CardNumber}\"\n" +
                   $"\"ExpirationDate\": \"{ExpirationDate}\"\n" +
                   $"\"AccountingDate\": \"{AccountingDate}\"\n" +
                   $"\"TransactionDate\": \"{TransactionDate}\"\n" +
                   "\"Details\":\n[\n" + details + "\n]\n";
        }
    }
}
