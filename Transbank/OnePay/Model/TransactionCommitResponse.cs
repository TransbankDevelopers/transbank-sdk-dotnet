using System;

namespace Transbank.OnePay.Model
{
    public class TransactionCommitResponse
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
