using System;
using System.Collections.Generic;
using System.Text;
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
