using System;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.TransaccionCompleta.Requests;
using Transbank.Webpay.TransaccionCompleta.Responses;

namespace Transbank.Webpay.TransaccionCompleta
{
    public static class FullTransaction
    {
        private static string _commerceCode = "597055555530";
        private static string _apiKey = "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C";

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
        public static CreateResponse Create(
            string buyOrder,
            string sessionId,
            int amount,
            int cvv,
            string cardNumber,
            string cardExpirationDate)
        {
            return Create(buyOrder, sessionId, amount, cvv, cardNumber, cardExpirationDate, DefaultOptions());
        }

        public static CreateResponse Create(
            string buyOrder,
            string sessionId,
            int amount,
            int cvv,
            string cardNumber,
            string cardExpirationDate,
            Options options)
        {
            return ExceptionHandler.Perform<CreateResponse, TransactionCreateException>(() =>
            {
                var createRequest = new CreateRequest(
                    buyOrder,
                    sessionId,
                    amount,
                    cvv,
                    cardNumber,
                    cardExpirationDate);
                var response = RequestService.Perform<TransactionCreateException>(createRequest, options);

                return JsonConvert.DeserializeObject<CreateResponse>(response);

            });

        }
    }
}
