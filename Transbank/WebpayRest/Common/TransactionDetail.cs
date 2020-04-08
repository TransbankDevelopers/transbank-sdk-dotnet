using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Transbank.Exceptions;

namespace Transbank.Webpay.Common
{
    public class TransactionDetail
    {
        private decimal _amount;

        [JsonProperty("amount")]
        public decimal Amount {
            get { return this._amount; }
            set
            {
                if (value % 1 != 0)
                {
                    throw new InvalidAmountException(InvalidAmountException.HAS_DECIMALS_MESSAGE);
                }
                this._amount = value;
            }
        }
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
