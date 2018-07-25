using System;
using Newtonsoft.Json;
using Transbank.Model;

namespace Transbank.Net
{
    public class NullifyTransactionResponse : BaseResponse
    {
        [JsonProperty("result")]
        public RefundCreateResponse Result { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", {Result.ToString()}";
        }
    }
}
