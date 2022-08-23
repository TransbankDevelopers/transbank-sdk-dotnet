using System;
using Newtonsoft.Json;
using System.ComponentModel;
using Transbank.Webpay.Common;
using System.Collections.Generic;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class MallStatusResponse : BaseResponse
    {
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        
        [JsonProperty("card_detail")]
        public CardDetail CardDetail { get; set; }
        
        [JsonProperty("accounting_date")]
        public string AccountingDate { get; set; }
        
        [JsonProperty("transaction_date")]
        public DateTime? TransactionDate { get; set; }

        [JsonProperty("details")]
        public List<PaymentResponse> Details { get; set; }

        public override string ToString()
        {
            var details = "";
            Details.ForEach(i => details += "{\n"+ i.ToString() + "\n}\n");
            return $"\"BuyOrder\": \"{BuyOrder}\"\n" +
                   $"\"AccountingDate\": \"{AccountingDate}\"\n" +
                   $"\"TransactionDate\": \"{TransactionDate}\"\n" +
                   "\"Details\":\n{\n\t" + details + "\n}\n";
        }
  
        
    }
}
