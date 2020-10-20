using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class MallAuthorizeResponse
    {
        [JsonProperty("buy_order")]
        public string BuyOrder { get; private set; }

        [JsonProperty("session_id")]
        public string SessionId { get; private set; }

        [JsonProperty("card_number")]
        public string CardNumber { get; private set; }

        [JsonProperty("expiration_date")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-mm-ddd")]
        public DateTime ExpirationDate { get; private set; }

        [JsonProperty("accounting_date")]
        public string AccountingDate { get; private set; }

        [JsonProperty("transaction_date")]
        public DateTime TransactionDate { get; private set; }

        [JsonProperty("details")]
        public List<PaymentResponse> Details{get; private set; }

        public MallAuthorizeResponse(string buyOrder, string sessionId, string cardNumber, DateTime expirationDate,
            string accountingDate, DateTime transactionDate, List<PaymentResponse> details)
        {
            BuyOrder = buyOrder;
            SessionId = sessionId;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            AccountingDate = accountingDate;
            TransactionDate = transactionDate;
            Details = details;
        }

        public override string ToString()
        {
            var details = "";
            Details.ForEach(i => details += "{\n"+ i.ToString() + "\n}\n");
            return $"\"BuyOrder\": \"{BuyOrder}\"\n" +
                   $"\"SessionId\": \"{SessionId}\"\n" +
                   $"\"CardNumber\": \"{CardNumber}\"\n" +
                   $"\"ExpirationDate\": \"{ExpirationDate}\"\n" +
                   $"\"AccountingDate\": \"{AccountingDate}\"\n" +
                   $"\"TransactionDate\": \"{TransactionDate}\"\n" +
                   "\"Details\":\n{\n\t" + details + "\n}\n";
        }
    }
}
