using System;
using Newtonsoft.Json;
using Transbank.Model;

namespace Transbank.Net
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
