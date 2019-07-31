using System;
using Newtonsoft.Json;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class AuthorizeMallResponse
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
        public DateTime AccountingDate { get; private set; }

        [JsonProperty("transaction_date")]
        public DateTime TransactionDate { get; private set; }

        [JsonProperty("details")]
        public PaymentResponse Details{get; private set; }

        public AuthorizeMallResponse(string buyOrder, string sessionId, string cardNumber, DateTime expirationDate,
            DateTime accountingDate, DateTime transactionDate, PaymentResponse details)
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
            return $"\"BuyOrder\": {BuyOrder}\"\n" +
                   $"\"SessionId\": {SessionId}\"\n" +
                   $"\"CardNumber\": {CardNumber}\"\n" +
                   $"\"ExpirationDate\": {ExpirationDate}\"\n" +
                   $"\"AccountingDate\": {AccountingDate}\"\n" +
                   $"\"TransactionDate\": {TransactionDate}\"\n" +
                   $"\"Details\": {Details.ToString()}\"";
        }
    }
}
