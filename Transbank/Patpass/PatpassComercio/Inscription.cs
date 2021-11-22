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
                IntegrationCommerceCodes.WEBPAY_PLUS,
                IntegrationApiKeys.WEBPAY,
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
            string fLastname,
            string sLastname,
            string rut,
            string serviceId,
            string finalUrl,
            decimal maxAmount,
            string phoneNumber,
            string mobileNumber,
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
                    url, name, fLastname, sLastname, rut, serviceId, finalUrl,
                    Options.CommerceCode, mAmount, phoneNumber, mobileNumber,
                    patpassName, personEmail, commerceEmail, address, city
                );
                var response = RequestService.Perform<InscriptionStartException>(request, Options, _headers);

                return JsonConvert.DeserializeObject<StartResponse>(response);
            });

        }

        public StatusResponse Status(string token)
        {
            return ExceptionHandler.Perform<StatusResponse, InscriptionStatusException>(() =>
            {
                var statusRequest = new StatusRequest(token);
                var response = RequestService.Perform<InscriptionStatusException>(
                    statusRequest, Options, _headers);

                return JsonConvert.DeserializeObject<StatusResponse>(response);
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
