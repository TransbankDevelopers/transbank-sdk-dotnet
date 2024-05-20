using System;
using System.Globalization;
using System.Net.Http;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.PatpassComercio.Requests;
using Transbank.PatpassComercio.Responses;

namespace Transbank.PatpassComercio
{
    public class Inscription
    {
        // The authentication headers for this product are different, these have
        // to be used. You can put them in the Perform method of the RequestService
        private readonly string _apiKeyHeaderName = "Authorization";
        private readonly string _commerceCodeHeaderName = "commerceCode";

        private readonly RequestServiceHeaders _headers;

        public Options options;
        public Inscription(Options options) {
            this.options = options;
            _headers = new RequestServiceHeaders(_apiKeyHeaderName, _commerceCodeHeaderName);
        }

        public static Inscription buildForIntegration(string commerceCode, string apiKey)
        {
            Inscription inscription = new Inscription(new Options(commerceCode, apiKey, PatpassComercioIntegrationType.Test));

            return inscription;
        }

        public static Inscription buildForProduction(string commerceCode, string apiKey)
        {
            Inscription inscription = new Inscription(new Options(commerceCode, apiKey, PatpassComercioIntegrationType.Live));

            return inscription;
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
                    options.CommerceCode, mAmount, phone, cellPhone,
                    patpassName, personEmail, commerceEmail, address, city
                );
                return options.RequestService.Perform<StartResponse, InscriptionStartException>(request, options, _headers);
            });

        }

        public StatusResponse Status(string token)
        {
            return ExceptionHandler.Perform<StatusResponse, InscriptionStatusException>(() =>
            {
                var statusRequest = new StatusRequest(token);
                return options.RequestService.Perform<StatusResponse, InscriptionStatusException>(
                    statusRequest, options, _headers);
            });
        }
    }

}
