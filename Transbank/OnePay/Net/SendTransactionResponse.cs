using System;
using Newtonsoft.Json;
using Transbank.OnePay.Model;

namespace Transbank.OnePay.Net
{
    public class SendTransactionResponse : BaseResponse
    {
        [JsonProperty("result")]
        public TransactionCreateResponse Result { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", {Result.ToString()}";
        }
    }
}
