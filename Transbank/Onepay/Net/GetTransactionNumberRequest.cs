using System;
using Newtonsoft.Json;
using Transbank.Onepay.Model;

namespace Transbank.Onepay.Net
{
    public sealed class GetTransactionNumberRequest : BaseRequest, ISignable
    {
        private string occ;
        private string externalUniqueNumber;
        [JsonProperty("issuedAt")]
        public long IssuedAt { get; set; }
        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("occ")]
        public string Occ
        {
            get => occ;
            set => occ = value ?? throw
                new ArgumentNullException(nameof(occ));
        }

        [JsonProperty("externalUniqueNumber")]
        public string ExternalUniqueNumber
        {
            get => externalUniqueNumber;
            set => externalUniqueNumber = value ?? throw
                new ArgumentNullException(nameof(externalUniqueNumber));
        }

        public GetTransactionNumberRequest()
        {
        }

        public GetTransactionNumberRequest(string occ, 
                                           string externalUniqueNumber, long issuedAt)
        {
            Occ = occ;
            ExternalUniqueNumber = externalUniqueNumber;
            IssuedAt = issuedAt;
        }

        public string GetDataToSign()
        {
            return Occ.Length + Occ
                + ExternalUniqueNumber.Length + ExternalUniqueNumber
                + IssuedAt.ToString().Length + IssuedAt.ToString();
        }

        public override string ToString()
        {
            return base.ToString() + $"Occ{Occ}, " +
                       $"ExternalUniqueNumber={ExternalUniqueNumber}, " +
                       $"IssuedAt={IssuedAt}, Signature{Signature}";
        }
    }
}
