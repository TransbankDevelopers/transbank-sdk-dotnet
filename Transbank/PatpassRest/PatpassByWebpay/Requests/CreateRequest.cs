using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;
using Transbank.Patpass.Common;
using Transbank.Exceptions;

namespace Transbank.Patpass.PatpassByWebpay.Requests
{
    internal class CreateRequest : BaseRequest
    {
        private decimal _amount;

        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount {
            get { return this._amount; }
            set
            {
                if (value % 1 != 0)
                {
                    throw new InvalidAmountException(InvalidAmountException.HAS_DECIMALS_MESSAGE);
                }
                this._amount = value;
            }
        }

        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }

        [JsonProperty("wpm_detail")]
        public Detail Details { get; set; }

        internal CreateRequest(string buyOrder, string sessionId, decimal amount, string returnUrl, string serviceId, string cardHolderId,
                string cardHolderName, string cardHolderLastName1, string cardHolderLastName2, string cardHolderMail, string cellphoneNumber,
                string expirationDate, string commerceMail, bool ufFlag)
            : base("/rswebpaytransaction/api/webpay/v1.0/transactions", HttpMethod.Post)
        {
            BuyOrder = buyOrder;
            SessionId = sessionId;
            Amount = amount;
            ReturnUrl = returnUrl;
            Details = new Detail(serviceId, cardHolderId, cardHolderName,
                cardHolderLastName1, cardHolderLastName2, cardHolderMail,
                cellphoneNumber, expirationDate, commerceMail, ufFlag
                );
        }
    }
}
