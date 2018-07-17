using System;
using System.Collections.Generic;
using System.Text;

namespace Transbank.Model
{
    public class TransactionCreateResponse
    {
        public string Occ { get; set; }
        public long Ott { get; set; }
        public string ExternalUniqueNumber { get; set; }
        public long IssuedAt { get; set; }
        public string QrCodeAsBase64 { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Occ={Occ}, Ott={Ott}, " +
                $"ExternalUniqueNumber={ExternalUniqueNumber}, " +
                $"QrCodeAsBase64={QrCodeAsBase64}";
        }
    }

}
