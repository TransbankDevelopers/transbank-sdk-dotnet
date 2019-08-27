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

        public static InstallmentsResponse Installments(
            string token,
            int installmentsNumber)
        {
            return Installments(token, installmentsNumber, DefaultOptions());
        }

        public static InstallmentsResponse Installments(
            string token,
            int installmentsNumber,
            Options options)
        {
            return ExceptionHandler.Perform<InstallmentsResponse, TransactionInstallmentsException>(() =>
            {
                var installmentsRequest = new InstallmentsRequest(
                    token, 
                    installmentsNumber);
                var response = RequestService.Perform<TransactionInstallmentsException>(installmentsRequest, options);

                return JsonConvert.DeserializeObject<InstallmentsResponse>(response);

            });
            
        }
        
        public static CommitResponse Commit(
            string token,
            int idQueryInstallments,
            int deferredPeriods,
            bool gracePeriod)
        {
            return Commit(
                token, 
                idQueryInstallments, 
                deferredPeriods, 
                gracePeriod, 
                DefaultOptions());
        }

        public static CommitResponse Commit(
            string token,
            int idQueryInstallments,
            int deferredPeriodsIndex,
            bool gracePeriods,
            Options options)
        {
            return ExceptionHandler.Perform<CommitResponse, TransactionCommitException>(() =>
            {
                var commitRequest = new CommitRequest(
                    token, 
                    idQueryInstallments, 
                    deferredPeriodsIndex, 
                    gracePeriods);
                var response = RequestService.Perform<TransactionCommitException>(commitRequest, options);
                return JsonConvert.DeserializeObject<CommitResponse>(response);
            });
        }

        public static StatusResponse Status(
            string token)
        {
            return Status(token, DefaultOptions());
        }

        public static StatusResponse Status(
            string token,
            Options options)
        {
            return ExceptionHandler.Perform<StatusResponse, TransactionStatusException>(() =>
            {
                var request = new StatusRequest(token);
                var response = RequestService.Perform<TransactionStatusException>(request, options);

                return JsonConvert.DeserializeObject<StatusResponse>(response);
            });
        }

        public static RefundResponse Refund(
            string token,
            int amount)
        {
            return Refund(token, amount, DefaultOptions());
        }

        public static RefundResponse Refund(
            string token, int amount, Options options)
        {
            return ExceptionHandler.Perform<RefundResponse, TransactionRefundException>(() =>
            {
                var request = new RefundRequest(token, amount);
                var response = RequestService.Perform<TransactionRefundException>(request, options);

                return JsonConvert.DeserializeObject<RefundResponse>(response);
            });
        }
    }
}
