using System;
using Newtonsoft.Json;
using Transbank.Exceptions;
using Transbank.Onepay.Model;

namespace Transbank.Onepay.Net
{
    public class NullifyTransactionRequest : BaseRequest, ISignable
    {
        private string occ;
        private string externalUniqueNumber;
        private string authorizationCode;
        private long _nullifyAmount;

        [JsonProperty("nullifyAmount")]
        public long NullifyAmount {
            get { return this._nullifyAmount; }
            set
            {
                if (value % 1 != 0)
                {
                    throw new InvalidAmountException(InvalidAmountException.HAS_DECIMALS_MESSAGE);
                }
                this._nullifyAmount = value;
            }
        }

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

        public string GetDataToSign()
        {
            return Occ.Length + Occ
                + ExternalUniqueNumber.Length + ExternalUniqueNumber
                + AuthorizationCode.Length + AuthorizationCode
                + IssuedAt.ToString().Length + IssuedAt.ToString()
                + NullifyAmount.ToString().Length + NullifyAmount.ToString();
        }

        public override string ToString()
        {
            return base.ToString() + $"Occ{Occ}, NullifyAmount{NullifyAmount}" +
                       $"ExternalUniqueNumber={ExternalUniqueNumber}, " +
                       $"AuthorizationCode={AuthorizationCode}, " +
                       $"IssuedAt={IssuedAt}, Signature{Signature}";
        }
    }
}
