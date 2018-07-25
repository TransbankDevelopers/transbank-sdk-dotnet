using System;
using Newtonsoft.Json;

namespace Transbank.Net
{
    public class NullifyTransactionRequest : BaseRequest
    {
        private string occ;
        private string externalUniqueNumber;
        private string authorizationCode;

        [JsonProperty("nullifyAmmount")]
        public long NullifyAmount { get; set; }

        [JsonProperty("issuedAt")]
        public long IssuedAt { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("occ")]
        public string Occ
        {
            get => occ;
            set => occ = value ?? throw new ArgumentNullException(nameof(occ));
        }

        [JsonProperty("externalUniqueNumber")]
        public string ExternalUniqueNumber
        {
            get => externalUniqueNumber;
            set => externalUniqueNumber = value ?? throw
                new ArgumentNullException(nameof(externalUniqueNumber));
        }

        [JsonProperty("authorizationCode")]
        public string AuthorizationCode
        {
            get => authorizationCode;
            set => authorizationCode = value ?? throw
                new ArgumentNullException(nameof(authorizationCode));
        }

        public NullifyTransactionRequest() { }

        public NullifyTransactionRequest(string occ, string externalUniqueNumber, 
            string authorizationCode, long nullifyAmount, long issuedAt)
        {
            Occ = occ;
            ExternalUniqueNumber = externalUniqueNumber;
            AuthorizationCode = authorizationCode;
            NullifyAmount = nullifyAmount;
            IssuedAt = issuedAt;
        }

        public override string ToString()
        {
            return base.ToString() + $"Occ{Occ}, NullifyAmount{NullifyAmount}" +
                       $"ExternalUniqueNumber={ExternalUniqueNumber}, " +
                       $"AuthorizationCode={AuthorizationCode}, " +
                       $"IssueadAt={IssuedAt}, Signature{Signature}";
        }
    }
}
