using System;
using Newtonsoft.Json;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    public static class Inscription
    {
        public static StartResponse Start(string userName, string email, string responseUrl)
        {
            return Start(userName, email, responseUrl, Oneclick.DefaultOptions());
        }

        public static StartResponse Start(string userName, string email,
            string responseUrl, Options options)
        {
            var startRequest = new StartRequest(userName, email, responseUrl);
            var response = RequestService.Perform(startRequest, options);

            return JsonConvert.DeserializeObject<StartResponse>(response);
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

        public static DeleteResponse Delete(string userName, string tbkUser)
        {
            return Delete(userName, tbkUser, Oneclick.DefaultOptions());
        }

        public static DeleteResponse Delete(string userName, string tbkUser, Options options)
        {
            var deleteRequest = new DeleteRequest(userName, tbkUser);
            var response = RequestService.Perform(deleteRequest, options);

            return JsonConvert.DeserializeObject<DeleteResponse>(response);
        }
    }
}
