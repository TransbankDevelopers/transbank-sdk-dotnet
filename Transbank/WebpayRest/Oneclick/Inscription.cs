using System;
using Newtonsoft.Json;
using Transbank.Webpay.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;
using Transbank.Webpay.Oneclick.Exceptions;

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
            return ExceptionHandler.Perform<StartResponse, InscriptionStartException>(() =>
            {
                var startRequest = new StartRequest(userName, email, responseUrl);
                var response = RequestService.Perform<InscriptionStartException>(
                    startRequest, options);

                return JsonConvert.DeserializeObject<StartResponse>(response);
            });
        }

        public static FinishResponse Finish(string token)
        {
            return Finish(token, Oneclick.DefaultOptions());
        }

        public static FinishResponse Finish(string token, Options options)
        {
            return ExceptionHandler.Perform<FinishResponse, InscriptionFinishException>(() =>
            {
                var finishRequest = new FinishRequest(token);
                var response = RequestService.Perform<InscriptionFinishException>(finishRequest, options);

                return JsonConvert.DeserializeObject<FinishResponse>(response);
            });
        }

        public static void Delete(string userName, string tbkUser)
        {
            Delete(userName, tbkUser, Oneclick.DefaultOptions());
        }

        public static void Delete(string userName, string tbkUser, Options options)
        {
            ExceptionHandler.Perform<InscriptionDeleteException>(() =>
            {
                var deleteRequest = new DeleteRequest(userName, tbkUser);
                RequestService.Perform<InscriptionDeleteException>(deleteRequest, options);
            });
        }
    }
}
