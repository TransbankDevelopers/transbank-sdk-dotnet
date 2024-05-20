using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.TransaccionCompleta.Requests;
using Transbank.Webpay.TransaccionCompleta.Responses;

namespace Transbank.Webpay.TransaccionCompleta
{
    public class FullTransaction
    {
        public Options options;
        public FullTransaction(Options options)
        {
            this.options = options;
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
                return options.RequestService.Perform<CreateResponse, TransactionCreateException>(createRequest, options);
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
                return options.RequestService.Perform<InstallmentsResponse, TransactionInstallmentsException>(installmentsRequest, options);
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
                return options.RequestService.Perform<CommitResponse, TransactionCommitException>(commitRequest, options);
            });
        }

        public StatusResponse Status(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<StatusResponse, TransactionStatusException>(() =>
            {
                var request = new StatusRequest(token);
                return options.RequestService.Perform<StatusResponse, TransactionStatusException>(request, options);
            });
        }

        public RefundResponse Refund(string token, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<RefundResponse, TransactionRefundException>(() =>
            {
                var request = new RefundRequest(token, amount);
                return options.RequestService.Perform<RefundResponse, TransactionRefundException>(request, options);
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
                return options.RequestService.Perform<CaptureResponse, TransactionCaptureException>(
                    captureRequest, options);
            });
        }
    }
}
