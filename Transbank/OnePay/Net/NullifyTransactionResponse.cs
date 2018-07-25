using System;
using Newtonsoft.Json;
using Transbank.OnePay.Model;

namespace Transbank.OnePay.Net
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
