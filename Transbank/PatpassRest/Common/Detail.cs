using System;
using Newtonsoft.Json;

namespace Transbank.PatpassRest.Common
{
    internal class Detail
    {
        [JsonProperty("service_id")]
        internal string ServiceId { get; }

        [JsonProperty("card_holder_id")]
        internal string CardHolderId { get; }

        [JsonProperty("card_holder_name")]
        internal string CardHolderName { get; }

        [JsonProperty("card_holder_last_name1")]
        internal string CardHolderLastName1 { get; }

        [JsonProperty("card_holder_last_name2")]
        internal string CardHolderLastName2 { get; }

        [JsonProperty("card_holder_mail")]
        internal string CardHolderMail { get; }

        [JsonProperty("cellphone_number")]
        internal string CellphoneNumber { get; }

        [JsonProperty("expiration_date")]
        internal string ExpirationDate { get; }

        [JsonProperty("commerce_mail")]
        internal string CommerceMail { get; }

        [JsonProperty("uf_flag")]
        internal bool UfFlag { get; }

        public Detail(string serviceId, string cardHolderId, string cardHolderName,
            string cardHolderLastName1, string cardHolderLastName2, string cardHolderMail,
            string cellphoneNumber, string expirationDate, string commerceMail, bool ufFlag)
        {
            ServiceId = serviceId;
            CardHolderId = cardHolderId;
            CardHolderName = cardHolderName;
            CardHolderLastName1 = cardHolderLastName1;
            CardHolderLastName2 = cardHolderLastName2;
            CardHolderMail = cardHolderMail;
            CellphoneNumber = cellphoneNumber;
            ExpirationDate = expirationDate;
            CommerceMail = commerceMail;
            UfFlag = ufFlag;
        }
    }
}
