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
            try
            {
                var startRequest = new StartRequest(userName, email, responseUrl);
                var response = RequestService.Perform(startRequest, options);

                return JsonConvert.DeserializeObject<StartResponse>(response);
            }
            catch (Exception e)
            {
                int code = e.GetType().Equals(typeof(TransbankException)) ?
                    ((TransbankException)e).Code : -1;
                throw new InscriptionStartException(code, e.Message, e);
            }
        }

        public static FinishResponse Finish(string token)
        {
            return Finish(token, Oneclick.DefaultOptions());
        }

        public static FinishResponse Finish(string token, Options options)
        {
            try
            {
                var finishRequest = new FinishRequest(token);
                var response = RequestService.Perform(finishRequest, options);

                return JsonConvert.DeserializeObject<FinishResponse>(response);
            }
            catch (Exception e)
            {
                int code = e.GetType().Equals(typeof(TransbankException)) ?
                    ((TransbankException)e).Code : -1;
                throw new InscriptionFinishException(code, e.Message, e);
            }
        }

        public static void Delete(string userName, string tbkUser)
        {
            Delete(userName, tbkUser, Oneclick.DefaultOptions());
        }

        public static void Delete(string userName, string tbkUser, Options options)
        {
            try
            {
                var deleteRequest = new DeleteRequest(userName, tbkUser);
                RequestService.Perform(deleteRequest, options);
            }
            catch (Exception e)
            {
                int code = e.GetType().Equals(typeof(TransbankException)) ?
                    ((TransbankException)e).Code : -1;
                throw new InscriptionDeleteException(code, e.Message, e);
            }
        }
    }
}
