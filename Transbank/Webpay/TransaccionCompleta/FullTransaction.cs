using System;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.TransaccionCompleta.Requests;
using Transbank.Webpay.TransaccionCompleta.Responses;

namespace Transbank.Webpay.TransaccionCompleta
{
    public class FullTransaction
    {
        public Options Options { get; private set; }

        public FullTransaction() : this(
            new Options(
                IntegrationCommerceCodes.WEBPAY_PLUS,
                IntegrationApiKeys.WEBPAY,
                WebpayIntegrationType.Test
            )
        )
        { }

        public FullTransaction(Options options)
        {
            Options = options;
        }
        public CreateResponse Create(
            string buyOrder,
            string sessionId,
            int amount,
            int cvv,
            string cardNumber,
            string cardExpirationDate)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstant.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(sessionId, ApiConstant.SESSION_ID_LENGTH, "sessionId");
            ValidationUtil.hasTextWithMaxLength(cardNumber, ApiConstant.CARD_NUMBER_LENGTH, "cardNumber");
            ValidationUtil.hasTextWithMaxLength(cardExpirationDate, ApiConstant.CARD_EXPIRATION_DATE_LENGTH, "cardExpirationDate");

            return ExceptionHandler.Perform<CreateResponse, TransactionCreateException>(() =>
            {
                var createRequest = new CreateRequest(
                    buyOrder,
                    sessionId,
                    amount,
                    cvv,
                    cardNumber,
                    cardExpirationDate);
                var response = RequestService.Perform<TransactionCreateException>(createRequest, Options);

                return JsonConvert.DeserializeObject<CreateResponse>(response);

            });

        }

        public InstallmentsResponse Installments(
            string token,
            int installmentsNumber)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<InstallmentsResponse, TransactionInstallmentsException>(() =>
            {
                var installmentsRequest = new InstallmentsRequest(
                    token,
                    installmentsNumber);
                var response = RequestService.Perform<TransactionInstallmentsException>(installmentsRequest, Options);

                return JsonConvert.DeserializeObject<InstallmentsResponse>(response);

            });

        }

        public CommitResponse Commit(
            string token,
            int idQueryInstallments,
            int deferredPeriodsIndex,
            bool gracePeriods)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<CommitResponse, TransactionCommitException>(() =>
            {
                var commitRequest = new CommitRequest(
                    token,
                    idQueryInstallments,
                    deferredPeriodsIndex,
                    gracePeriods);
                var response = RequestService.Perform<TransactionCommitException>(commitRequest, Options);
                return JsonConvert.DeserializeObject<CommitResponse>(response);
            });
        }

        public StatusResponse Status(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<StatusResponse, TransactionStatusException>(() =>
            {
                var request = new StatusRequest(token);
                var response = RequestService.Perform<TransactionStatusException>(request, Options);

                return JsonConvert.DeserializeObject<StatusResponse>(response);
            });
        }

        public RefundResponse Refund(string token, int amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<RefundResponse, TransactionRefundException>(() =>
            {
                var request = new RefundRequest(token, amount);
                var response = RequestService.Perform<TransactionRefundException>(request, Options);

                return JsonConvert.DeserializeObject<RefundResponse>(response);
            });
        }

        /*
        |--------------------------------------------------------------------------
        | Environment Configuration
        |--------------------------------------------------------------------------
        */

        public void ConfigureForIntegration(String commerceCode, String apiKey)
        {
            Options = new Options(commerceCode, apiKey, WebpayIntegrationType.Test);
        }

        public void ConfigureForProduction(String commerceCode, String apiKey)
        {
            Options = new Options(commerceCode, apiKey, WebpayIntegrationType.Live);
        }

        public void ConfigureForTesting()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.TRANSACCION_COMPLETA, IntegrationApiKeys.WEBPAY);
        }

        public void ConfigureForTestingDeferred()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.TRANSACCION_COMPLETA_DEFERRED, IntegrationApiKeys.WEBPAY);
        }
    }
}
