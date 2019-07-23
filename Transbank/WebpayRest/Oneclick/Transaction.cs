using System;
using Newtonsoft.Json;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    public static class Transaction
    {
        public static AuthorizeResponse Authorize(string userName, string email, string responseUrl)
        {
            return Authorize(userName, email, responseUrl, Oneclick.DefaultOptions());
        }

        public static AuthorizeResponse Authorize(string userName, string email,
            string responseUrl, Options options)
        {
            var startRequest = new StartRequest(userName, email, responseUrl);
            var response = RequestService.Perform(startRequest, options);

            return JsonConvert.DeserializeObject<AuthorizeResponse>(response);
        }

        public static FinishResponse Finish(string token)
        {
            return Finish(token, Oneclick.DefaultOptions());
        }

        public static FinishResponse Finish(string token, Options options)
        {
            var finishRequest = new FinishRequest(token);
            var response = RequestService.Perform(finishRequest, options);

            return JsonConvert.DeserializeObject<FinishResponse>(response);
        }
    }
}
