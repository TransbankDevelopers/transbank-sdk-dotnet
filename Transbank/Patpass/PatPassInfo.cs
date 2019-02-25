using System;

namespace Transbank.PatPass
{
    public class PatPassInfo
    {
        public string ServiceId { get; set; } 
        public string CardHolderId { get; set; }
        public string CardHolderName { get; set; }
        public string CardHolderLastName1 { get; set; }
        public string CardHolderLastName2 { get; set; }
        public string CardHolderMail { get; set; }
        public string CellPhoneNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
