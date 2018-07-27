using System;
using System.Collections.Generic;
using System.Text;

namespace Transbank.OnePay.Model
{
    public class TransactionCreateResponse : ISignable
    {
        public string Occ { get; set; }
        public long Ott { get; set; }
        public string ExternalUniqueNumber { get; set; }
        public long IssuedAt { get; set; }
        public string QrCodeAsBase64 { get; set; }
        public string Signature { get; set; }

        public string GetDataToSign()
        {
            return Occ.Length + Occ
                    + ExternalUniqueNumber.Length + ExternalUniqueNumber
                    + IssuedAt.ToString().Length + IssuedAt.ToString();
        }

        public override string ToString()
        {
            return base.ToString() + $"Occ={Occ}, Ott={Ott}, " +
                $"ExternalUniqueNumber={ExternalUniqueNumber}, " +
                $"QrCodeAsBase64={QrCodeAsBase64}";
        }
    }

}
