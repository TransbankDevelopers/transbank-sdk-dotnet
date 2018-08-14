using Newtonsoft.Json;
using Transbank.Onepay.Model;

namespace Transbank.Onepay.Net
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
