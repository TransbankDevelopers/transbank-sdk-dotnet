using System;
using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    internal class CaptureRequest : BaseRequest
    {
        private decimal _captureAmount;

        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }

        [JsonProperty("authorization_code")]
        internal string AuthorizationCode { get; set; }

        [JsonProperty("capture_amount")]
        internal decimal CaptureAmount {
            get { return this._captureAmount; }
            set
            {
                if (value % 1 != 0)
                {
                    throw new InvalidAmountException(InvalidAmountException.HAS_DECIMALS_MESSAGE);
                }
                this._captureAmount = value;
            }
        }

        [JsonProperty("commerce_code", NullValueHandling = NullValueHandling.Ignore)]
        internal string CommerceCode { get; set; }

        internal CaptureRequest(string token, string buyOrder, string authorizationCode,
            decimal captureAmount, string commerceCode = null) :
            base($"/rswebpaytransaction/api/webpay/v1.0/transactions/{token}/capture", HttpMethod.Put)
        {
            BuyOrder = buyOrder;
            AuthorizationCode = authorizationCode;
            CaptureAmount = captureAmount;
            CommerceCode = commerceCode;
        }
    }
}


