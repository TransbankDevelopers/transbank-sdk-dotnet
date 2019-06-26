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

        public static RefundResponse Refund(string token, decimal amount)
        {
            return Refund(token, amount, WebpayPlus.DefaultOptions());
        }

        public static RefundResponse Refund(string token, decimal amount, Options options)
        {
            var refundRequest = new RefundRequest(token, amount);
            var response = RequestService.Perform(refundRequest, options);

            return JsonConvert.DeserializeObject<RefundResponse>(response);
        }

        public static StatusResponse Status(string token)
        {
            return Status(token, WebpayPlus.DefaultOptions());
        }

        public static StatusResponse Status(string token, Options options)
        {
            var statusRequest = new StatusRequest(token);
            var response = RequestService.Perform(statusRequest, options);

            return JsonConvert.DeserializeObject<StatusResponse>(response);
        }
    }
}
