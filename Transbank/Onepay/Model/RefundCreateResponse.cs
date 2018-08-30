namespace Transbank.Onepay.Model
{
    public class RefundCreateResponse : ISignable
    {
        public string Occ { get; set; }
        public string ExternalUniqueNumber { get; set; }
        public string ReverseCode { get; set; }
        public long IssuedAt { get; set; }
        public string Signature { get; set; }

        public string GetDataToSign()
        {
            return Occ.Length + Occ
                    + ExternalUniqueNumber.Length + ExternalUniqueNumber
                    + ReverseCode.Length + ReverseCode
                    + IssuedAt.ToString().Length + IssuedAt.ToString();
        }

        public override string ToString()
        {
            return base.ToString() + $"Occ={Occ}, " +
                $"ExternalUniqueNumber={ExternalUniqueNumber}, " +
                $"ReverseCode={ReverseCode}, IssuedAt={IssuedAt}, " +
                $"Signature={Signature}";
        }
    }
}
