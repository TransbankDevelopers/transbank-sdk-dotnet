using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.WebpayPlus.Responses;

namespace Transbank.Webpay.WebpayPlus
{
    public class Transaction
    {
        public Options options;
        public Transaction(Options options) 
        {
            this.options = options;
        }

        public static Transaction buildForIntegration(string commerceCode, string apiKey)
        {
            Transaction transaction = new Transaction(new Options(commerceCode, apiKey, WebpayIntegrationType.Test));

            return transaction;
        }

        public static Transaction buildForProduction(string commerceCode, string apiKey)
        {
            Transaction transaction = new Transaction(new Options(commerceCode, apiKey, WebpayIntegrationType.Live));

            return transaction;
        }

        public CreateResponse Create(string buyOrder, string sessionId,
            decimal amount, string returnUrl)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(sessionId, ApiConstants.SESSION_ID_LENGTH, "sessionId");
            ValidationUtil.hasTextWithMaxLength(returnUrl, ApiConstants.RETURN_URL_LENGTH, "returnUrl");

            return ExceptionHandler.Perform<CreateResponse, TransactionCreateException>(() =>
            {
                var createRequest = new CreateRequest(buyOrder, sessionId, amount, returnUrl);
                return options.RequestService.Perform<CreateResponse, TransactionCreateException>(
                    createRequest, options);
            });
        }

        public CommitResponse Commit(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<CommitResponse, TransactionCommitException>(() =>
            {
                var commitRequest = new CommitRequest(token);
                return options.RequestService.Perform<CommitResponse, TransactionCommitException>(
                    commitRequest, options);
            });
        }

        public RefundResponse Refund(string token, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<RefundResponse, TransactionRefundException>(() =>
            {
                var refundRequest = new RefundRequest(token, amount);
                return options.RequestService.Perform<RefundResponse, TransactionRefundException>(
                    refundRequest, options);
            });
        }

        public StatusResponse Status(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<StatusResponse, TransactionStatusException>(() =>
            {
                var statusRequest = new StatusRequest(token);
                return options.RequestService.Perform<StatusResponse, TransactionStatusException>(
                    statusRequest, options);
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
