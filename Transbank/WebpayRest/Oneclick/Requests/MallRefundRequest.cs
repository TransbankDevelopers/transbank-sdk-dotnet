using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;

namespace Transbank.WebpayRest.Oneclick.Requests
{
    public class MallRefundRequest : BaseRequest
    {
        private decimal _amount;

        [JsonProperty("commerce_code")]
        internal string CommerceCode { get; set; }
        
        [JsonProperty("detail_buy_order")]
        internal string DetailBuyOrder { get; set; }
        
        [JsonProperty("amount")]
        internal decimal Amount {
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
        
        public MallRefundRequest(string buyOrder, string childCommerceCode, string childBuyOrder, decimal amount)
            : base($"/rswebpaytransaction/api/oneclick/v1.0/transactions/{buyOrder}/refunds", HttpMethod.Post)
        {
            CommerceCode = childCommerceCode;
            DetailBuyOrder = childBuyOrder;
            Amount = amount;
        }
    }
}
