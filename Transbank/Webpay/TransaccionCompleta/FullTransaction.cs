using System;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.TransaccionCompleta.Requests;
using Transbank.Webpay.TransaccionCompleta.Responses;

namespace Transbank.Webpay.TransaccionCompleta
{
    public class FullTransaction
    {
        private Options _options;

        public Options Options
        {
            get => _options;
            private set => _options = value ?? throw new ArgumentNullException(
                nameof(value), "Options can't be null."
            );
        }
        public FullTransaction(Options options)
        {
            Options = options;
        }

        public static FullTransaction buildForIntegration(string commerceCode, string apiKey)
        {
            FullTransaction fullTransaction = new FullTransaction(new Options(commerceCode, apiKey, WebpayIntegrationType.Test));

            return fullTransaction;
        }

        public static FullTransaction buildForProduction(string commerceCode, string apiKey)
        {
            FullTransaction fullTransaction = new FullTransaction(new Options(commerceCode, apiKey, WebpayIntegrationType.Live));

            return fullTransaction;
        }

        public CreateResponse Create(
            string buyOrder,
            string sessionId,
            decimal amount,
            int cvv,
            string cardNumber,
            string cardExpirationDate)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(sessionId, ApiConstants.SESSION_ID_LENGTH, "sessionId");
            ValidationUtil.hasTextWithMaxLength(cardNumber, ApiConstants.CARD_NUMBER_LENGTH, "cardNumber");
            ValidationUtil.hasTextWithMaxLength(cardExpirationDate, ApiConstants.CARD_EXPIRATION_DATE_LENGTH, "cardExpirationDate");

            return ExceptionHandler.Perform<CreateResponse, TransactionCreateException>(() =>
            {
                var createRequest = new CreateRequest(
                    buyOrder,
                    sessionId,
                    amount,
                    cvv,
                    cardNumber,
                    cardExpirationDate);
                return Options.RequestService.Perform<CreateResponse, TransactionCreateException>(createRequest, Options);
            });

        }

        public InstallmentsResponse Installments(
            string token,
            int installmentsNumber)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<InstallmentsResponse, TransactionInstallmentsException>(() =>
            {
                var installmentsRequest = new InstallmentsRequest(
                    token,
                    installmentsNumber);
                return Options.RequestService.Perform<InstallmentsResponse, TransactionInstallmentsException>(installmentsRequest, Options);
            });

        }

        public CommitResponse Commit(
            string token,
            int? idQueryInstallments,
            int? deferredPeriodsIndex,
            bool gracePeriods)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<CommitResponse, TransactionCommitException>(() =>
            {
                var commitRequest = new CommitRequest(
                    token,
                    idQueryInstallments,
                    deferredPeriodsIndex,
                    gracePeriods);
                return Options.RequestService.Perform<CommitResponse, TransactionCommitException>(commitRequest, Options);
            });
        }

        public StatusResponse Status(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<StatusResponse, TransactionStatusException>(() =>
            {
                var request = new StatusRequest(token);
                return Options.RequestService.Perform<StatusResponse, TransactionStatusException>(request, Options);
            });
        }

        public RefundResponse Refund(string token, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<RefundResponse, TransactionRefundException>(() =>
            {
                var request = new RefundRequest(token, amount);
                return Options.RequestService.Perform<RefundResponse, TransactionRefundException>(request, Options);
            });
        }

        public CaptureResponse Capture(string token, string buyOrder, string authorizationCode,
            decimal captureAmount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(authorizationCode, ApiConstants.AUTHORIZATION_CODE_LENGTH, "authorizationCode");

            return ExceptionHandler.Perform<CaptureResponse, TransactionCaptureException>(() =>
            {
                var captureRequest = new CaptureRequest(token, buyOrder,
                    authorizationCode, captureAmount);
                return Options.RequestService.Perform<CaptureResponse, TransactionCaptureException>(
                    captureRequest, Options);
            });
        }
    }
}
