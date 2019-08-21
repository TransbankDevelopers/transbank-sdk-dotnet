using System;

namespace Transbank.Onepay.Model
{
    public class TransactionCommitResponse : ISignable
    {
        public string Occ { get; set; }
        public string AuthorizationCode { get; set; }
        public string Signature { get; set; }
        public string TransactionDesc { get; set; }
        public string BuyOrder { get; set; }
        public long IssuedAt { get; set; }
        public long Amount { get; set; }
        public long InstallmentsAmount { get; set; }
        public int InstallmentsNumber { get; set; }

        public string GetDataToSign()
        {
            string ret = Occ.Length + Occ
                    + AuthorizationCode.Length + AuthorizationCode
                    + IssuedAt.ToString().Length + IssuedAt.ToString()
                    + Amount.ToString().Length + Amount.ToString()
                    + InstallmentsAmount.ToString().Length + InstallmentsAmount.ToString()
                    + InstallmentsNumber.ToString().Length + InstallmentsNumber.ToString()
                    + BuyOrder.Length + BuyOrder;
            return ret;
        }

        public override string ToString()
        {
            return base.ToString() + 
                       $"Occ={Occ}, " +
                       $"AuthorizationCode={AuthorizationCode}, " +
                       $"Signature={Signature}, " +
                       $"TransactionDesc{TransactionDesc}, " +
                       $"BuyOrder{BuyOrder}, " +
                       $"IssuedAt={IssuedAt}, " +
                       $"Amount{Amount}, " +
                       $"InstallmentsAmount{InstallmentsAmount}, " +
                       $"InstallmentsNumber{InstallmentsNumber}";
        }
    }
}
