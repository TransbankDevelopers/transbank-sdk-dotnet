using System;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    public static class MallInscription
    {
        public static RequestServiceHeaders Headers
        {
            get => MallTransaction.Headers;
            set => MallTransaction.Headers = value;
        }

        public static string CommerceCode
        {
            get => MallTransaction.CommerceCode;
            set => MallTransaction.CommerceCode = value;
        }

        public static string ApiKey
        {
            get => MallTransaction.ApiKey;
            set => MallTransaction.ApiKey = value;
        }

        public static WebpayIntegrationType IntegrationType
        {
            get => MallTransaction.IntegrationType;
            set => MallTransaction.IntegrationType = value;
        }

        public static Options DefaultOptions()
        {
            return new Options(CommerceCode, ApiKey, IntegrationType, Headers);
        }

        public static MallStartResponse Start(string userName, string email, string responseUrl)
        {
            return Start(userName, email, responseUrl, DefaultOptions());
        }

        public static MallStartResponse Start(string userName, string email,
            string responseUrl, Options options)
        {
            return ExceptionHandler.Perform<MallStartResponse, InscriptionStartException>(() =>
            {
                var startRequest = new MallStartRequest(userName, email, responseUrl);
                var response = RequestService.Perform<InscriptionStartException>(
                    startRequest, options);

                return JsonConvert.DeserializeObject<MallStartResponse>(response);
            });
        }

        public static MallFinishResponse Finish(string token)
        {
            return Finish(token, DefaultOptions());
        }

        public static MallFinishResponse Finish(string token, Options options)
        {
            return ExceptionHandler.Perform<MallFinishResponse, InscriptionFinishException>(() =>
            {
                var finishRequest = new MallFinishRequest(token);
                var response = RequestService.Perform<InscriptionFinishException>(finishRequest, options);

                return JsonConvert.DeserializeObject<MallFinishResponse>(response);
            });
        }

        public static void Delete(string userName, string tbkUser)
        {
            Delete(userName, tbkUser, DefaultOptions());
        }

        public static void Delete(string userName, string tbkUser, Options options)
        {
            ExceptionHandler.Perform<InscriptionDeleteException>(() =>
            {
                var deleteRequest = new MallDeleteRequest(userName, tbkUser);
                RequestService.Perform<InscriptionDeleteException>(deleteRequest, options);
            });
        }
    }
}
