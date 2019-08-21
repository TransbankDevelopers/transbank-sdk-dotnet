using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Transbank.Common;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;
using Transbank.Webpay.Oneclick.Exceptions;

namespace Transbank.Webpay.Oneclick
{
    public static class MallTransaction
    {
        private static string _commerceCode = "597055555541";
        private static string _apiKey = "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C";
        private static string[] _storeCodes = { "597055555542", "597055555543" };

        private static WebpayIntegrationType _integrationType = WebpayIntegrationType.Test;

        public static string CommerceCode
        {
            get => _commerceCode;
            set => _commerceCode = value ?? throw new ArgumentNullException(
                                       nameof(value), "Commerce code can't be null."
                                   );
        }

        public static string ApiKey
        {
            get => _apiKey;
            set => _apiKey = value ?? throw new ArgumentNullException(
                                 nameof(value), "Api Key can't be null."
                             );
        }

        public static WebpayIntegrationType IntegrationType
        {
            get => _integrationType;
            set => _integrationType = value ?? throw new ArgumentNullException(
                                          nameof(value), "Integration type can't be null."
                                      );
        }

        public static Options DefaultOptions()
        {
            return new Options(CommerceCode, ApiKey, IntegrationType);
        }
        
        public static AuthorizeMallResponse Authorize(string userName, string tbkUser,
            string buyOrder, List<PaymentRequest> details)
        {
            return Authorize(userName, tbkUser, buyOrder, details, DefaultOptions());
        }

        public static AuthorizeMallResponse Authorize(string userName, string tbkUser, string buyOrder,
            List<PaymentRequest> details, Options options)
        {
            return ExceptionHandler.Perform<AuthorizeMallResponse, MallTransactionAuthorizeException>(() =>
            {
                var authorizeRequest = new AuthorizeMallRequest(userName, tbkUser, buyOrder,
                    details);
                var response = RequestService.Perform<MallTransactionAuthorizeException>(authorizeRequest, options);

                return JsonConvert.DeserializeObject<AuthorizeMallResponse>(response);
            });
        }
    }
}
