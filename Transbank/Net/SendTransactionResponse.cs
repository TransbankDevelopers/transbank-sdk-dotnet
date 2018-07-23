using System;
using Newtonsoft.Json;
using Transbank.Model;

namespace Transbank.Net
{
    class SendTransactionResponse : BaseResponse
    {
        [JsonProperty("result")]
        public TransactionCreateResponse Result { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", {Result.ToString()}";
        }
    }
}
