using System;
using Newtonsoft.Json;
using Transbank.Onepay.Model;

namespace Transbank.Onepay.Net
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
