using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.TransaccionCompleta.Requests
{
    internal class InstallmentsRequest : BaseRequest
    {
        [JsonProperty("installments_number")]
        public int InstallmentsNumber { get; set; }

        internal InstallmentsRequest(
            string token, 
            int installmentsNumber)
            : base($"/rswebpaytransaction/api/webpay/v1.0/transactions/{token}", HttpMethod.Post)
        {
            InstallmentsNumber = installmentsNumber;
        }

        public override string ToString()
        {
            return $"Installments Number={InstallmentsNumber}";
        }
    }
}
