using System;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.WebpayPlus.Responses;

namespace Transbank.Webpay.WebpayPlus
{
    public class Transaction
    {
        private Options _options;

        public Options Options
        {
            get => _options;
            private set => _options = value ?? throw new ArgumentNullException(
                nameof(value), "Options can't be null."
            );
        }

        public Transaction(Options options) 
        {
            Options = options;
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
                return Options.RequestService.Perform<CreateResponse, TransactionCreateException>(
                    createRequest, Options);
            });
        }

        public CommitResponse Commit(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<CommitResponse, TransactionCommitException>(() =>
            {
                var commitRequest = new CommitRequest(token);
                return Options.RequestService.Perform<CommitResponse, TransactionCommitException>(
                    commitRequest, Options);
            });
        }

        public RefundResponse Refund(string token, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<RefundResponse, TransactionRefundException>(() =>
            {
                var refundRequest = new RefundRequest(token, amount);
                return Options.RequestService.Perform<RefundResponse, TransactionRefundException>(
                    refundRequest, Options);
            });
        }

        public StatusResponse Status(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<StatusResponse, TransactionStatusException>(() =>
            {
                var statusRequest = new StatusRequest(token);
                return Options.RequestService.Perform<StatusResponse, TransactionStatusException>(
                    statusRequest, Options);
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
