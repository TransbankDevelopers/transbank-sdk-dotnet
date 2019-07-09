using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Webpay.Common
{
    public class TransactionDetail
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; set; }
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }

        public TransactionDetail(decimal amount, string commerceCode, string buyOrder)
        {
            Amount = amount;
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
        }
    }
}
