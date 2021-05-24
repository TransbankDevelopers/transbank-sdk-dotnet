using System;

namespace Transbank.Webpay.Oneclick.Responses
{
    [Obsolete("Use MallFinishResponse instead", false)]
    public class FinishResponse : MallFinishResponse
    {
        public FinishResponse(int responseCode, string transbankUser,
            string authorizationCode, string cardType, string cardNumber) :
            base (responseCode, transbankUser, authorizationCode, cardType, cardNumber) { }
    }
}
