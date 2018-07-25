using System;
using System.Collections.Generic;
using System.Text;

namespace Transbank.OnePay.Model
{
    public class RefundCreateResponse
    {
        public string Occ { get; set; }
        public string ExternalUniqueNumber { get; set; }
        public string ReverseCode { get; set; }
        public long IssuedAt { get; set; }
        public string Signature { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Occ={Occ}, " +
                $"ExternalUniqueNumber={ExternalUniqueNumber}, " +
                $"ReverseCode={ReverseCode}, IssueadAt={IssuedAt}, " +
                $"Signature={Signature}";
        }
    }
}
