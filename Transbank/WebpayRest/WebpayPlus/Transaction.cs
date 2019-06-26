using System;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus.Responses;
using Newtonsoft.Json;

namespace Transbank.Webpay.WebpayPlus
{
    public static class Transaction
    {
        public static CreateResponse Create(string buyOrder, string sessionId,
            decimal amount, string returnUrl)
        {
            return Create(buyOrder, sessionId, amount, returnUrl, WebpayPlus.DefaultOptions());
        }

        public static CreateResponse Create(string buyOrder, string sessionId,
            decimal amount, string returnUrl, Options options)
        {
            var createRequest = new CreateRequest(buyOrder, sessionId, amount, returnUrl);
            var response = RequestService.Perform(createRequest, options);

            return JsonConvert.DeserializeObject<CreateResponse>(response);
        }

        public static CommitResponse Commit(string token)
        {
            return Commit(token, WebpayPlus.DefaultOptions());
        }

        public static CommitResponse Commit(string token, Options options)
        {
            var commitRequest = new CommitRequest(token);
            var response = RequestService.Perform(commitRequest, options);

            return JsonConvert.DeserializeObject<CommitResponse>(response);
        }
    }
}
