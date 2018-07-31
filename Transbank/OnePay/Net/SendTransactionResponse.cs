using System;
using Newtonsoft.Json;
using Transbank.Onepay.Model;

namespace Transbank.Onepay.Net
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
