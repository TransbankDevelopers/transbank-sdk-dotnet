using System;
using Newtonsoft.Json;
using Transbank.OnePay.Model;

namespace Transbank.OnePay.Net
{
    public class GetTransactionNumberResponse : BaseResponse
    {
        [JsonProperty("result")]
        public TransactionCommitResponse Result { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", {Result.ToString()}";
        }
    }
}
