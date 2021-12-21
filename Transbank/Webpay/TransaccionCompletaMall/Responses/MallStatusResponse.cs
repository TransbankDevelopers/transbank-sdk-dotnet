using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Transbank.Patpass.Common;
using Transbank.Webpay.Common;
using Transbank.Webpay.TransaccionCompletaMall.Common;

namespace Transbank.Webpay.TransaccionCompletaMall.Responses
{
    public class MallStatusResponse
    {
        [JsonProperty("details")]
        public List<CommitResponseDetails> Details { get; set; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
        
        [JsonProperty("card_detail")]
        public CardDetail CardDetail { get; set; }
        
        [JsonProperty("accounting_date")]
        public string AccountingDate { get; set; }
        
        [JsonProperty("transaction_date")]
        public string TransactionDate { get; set; }

        public MallStatusResponse(
            List<CommitResponseDetails> details,
            string buyOrder,
            string sessionId,
            CardDetail cardDetail,
            string accountingDate,
            string transactionDate
        )
        {
            Details = details;
            BuyOrder = buyOrder;
            SessionId = sessionId;
            CardDetail = cardDetail;
            AccountingDate = accountingDate;
            TransactionDate = transactionDate;
        }

        public override string ToString()
        {
            var properties = new List<string>();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(this);
                properties.Add($"{name}={value}");
            }
            return String.Join(",\n", properties);
        }
    }
}
