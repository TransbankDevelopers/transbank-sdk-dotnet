using System;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Patpass.Common;
using Transbank.Patpass.PatpassComercio.Requests;
using Transbank.Patpass.PatpassComercio.Responses;

namespace Transbank.Patpass.PatpassComercio
{
    public static class Inscription
    {
        private static string _commerceCode = "28299257";
        private static string _apiKey = "cxxXQgGD9vrVe4M41FIt";
        private static PatpassComercioIntegrationType _integrationType = PatpassComercioIntegrationType.Test;
        
        public static string CommerceCode
        {
            get => _commerceCode;
            set => _commerceCode = value ?? throw new ArgumentNullException(
                                       nameof(value), "Commerce Code can't be null."
            );
        }

        public static string ApiKey
        {
            get => _apiKey;
            set => _apiKey = value ?? throw new ArgumentNullException(
                                 nameof(value), "Api Key can't be null.");
        }

        public static PatpassComercioIntegrationType IntegrationType
        {
            get => _integrationType;
            set => _integrationType = value ?? throw new ArgumentNullException(
                                          nameof(value), "Integration type can't be null");
        }

        public static Options DefaultOptions()
        {
            return new Options(CommerceCode, ApiKey, IntegrationType);
        }

        public static StartResponse Start(
            string url,
            string name,
            string fLastname,
            string sLastname,
            string rut,
            string serviceId,
            string finalUrl,
            string commerceCode,
            int maxAmount,
            string phoneNumber,
            string mobileNumber,
            string patpassName,
            string personEmail,
            string commerceEmail,
            string address,
            string city
        )
        {
            return Start(url, name, fLastname, sLastname, rut, serviceId, finalUrl, commerceCode, maxAmount,
                phoneNumber, mobileNumber, patpassName, personEmail, commerceEmail, address, city, DefaultOptions());
        }

        public static StartResponse Start(
            string url,
            string name,
            string fLastname,
            string sLastname,
            string rut,
            string serviceId,
            string finalUrl,
            string commerceCode,
            int maxAmount,
            string phoneNumber,
            string mobileNumber,
            string patpassName,
            string personEmail,
            string commerceEmail,
            string address,
            string city,
            Options options
        )
        {
            var startRequest = new StartRequest(
                url, name, fLastname, sLastname, rut, serviceId, finalUrl, commerceCode, maxAmount,
                phoneNumber, mobileNumber, patpassName, personEmail, commerceEmail, address, city
                );
            var response = RequestService.Perform<InscriptionStartException>(startRequest, options);

            return JsonConvert.DeserializeObject<StartResponse>(response);
        }

        public static StatusResponse Status(string token)
        {
            return Status(token, DefaultOptions());
        }

        public static StatusResponse Status(string token, Options options)
        {
            return ExceptionHandler.Perform<StatusResponse, InscriptionStatusException>(() =>
            {
                var statusRequest = new StatusRequest(token);
                var response = RequestService.Perform<InscriptionStatusException>(
                    statusRequest, options);

                return JsonConvert.DeserializeObject<StatusResponse>(response);
            });
        }
    }
    
}
