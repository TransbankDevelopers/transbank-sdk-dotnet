using System;
using System.Globalization;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Patpass.Common;
using Transbank.Patpass.PatpassComercio.Requests;
using Transbank.Patpass.PatpassComercio.Responses;

namespace Transbank.Patpass.PatpassComercio
{
    public class Inscription
    {
        // The authentication headers for this product are different, these have
        // to be used. You can put them in the Perform method of the RequestService
        private string _apiKeyHeaderName = "Authorization";
        private string _commerceCodeHeaderName = "commerceCode";

        private RequestServiceHeaders _headers;
        public Options Options { get; private set; }

        public Inscription() : this(
            new Options(
                IntegrationCommerceCodes.PATPASS_COMERCIO,
                IntegrationApiKeys.PATPASS_COMERCIO,
                PatpassComercioIntegrationType.Test
            )
        )
        { }

        public Inscription(Options options)
        {
            Options = options;
            _headers = new RequestServiceHeaders(_apiKeyHeaderName, _commerceCodeHeaderName);
        }

        public StartResponse Start(
            string url,
            string name,
            string lastName,
            string secondLastName,
            string rut,
            string serviceId,
            string finalUrl,
            decimal maxAmount,
            string phone,
            string cellPhone,
            string patpassName,
            string personEmail,
            string commerceEmail,
            string address,
            string city
        )
        {
            // set culture to es-CL, since webpay only works with clp we are forcing to anyone to use clp currency standard.
            CultureInfo myCiIntl = new CultureInfo("es-CL", false);
            string mAmount = maxAmount <= 0 ? "" : maxAmount.ToString(myCiIntl);
            return ExceptionHandler.Perform<StartResponse, InscriptionStartException>(() =>
            {
                var request = new StartRequest(
                    url, name, lastName, secondLastName, rut, serviceId, finalUrl,
                    Options.CommerceCode, mAmount, phone, cellPhone,
                    patpassName, personEmail, commerceEmail, address, city
                );
                return RequestService.Perform<StartResponse, InscriptionStartException>(request, Options, _headers);
            });

        }

        public StatusResponse Status(string token)
        {
            return ExceptionHandler.Perform<StatusResponse, InscriptionStatusException>(() =>
            {
                var statusRequest = new StatusRequest(token);
                return RequestService.Perform<StatusResponse, InscriptionStatusException>(
                    statusRequest, Options, _headers);
            });
        }

        /*
        |--------------------------------------------------------------------------
        | Environment Configuration
        |--------------------------------------------------------------------------
        */

        public void ConfigureForIntegration(String commerceCode, String apiKey)
        {
            Options = new Options(commerceCode, apiKey, PatpassComercioIntegrationType.Test);
        }

        public void ConfigureForProduction(String commerceCode, String apiKey)
        {
            Options = new Options(commerceCode, apiKey, PatpassComercioIntegrationType.Live);
        }

        public void ConfigureForTesting()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.PATPASS_COMERCIO, IntegrationApiKeys.PATPASS_COMERCIO);
        }
    }

}
