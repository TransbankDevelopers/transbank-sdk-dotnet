using System.Collections.Generic;
using System.Net.Http;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.Requests;
using Transbank.Webpay.Responses;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.WebpayPlus.Responses;

namespace Transbank.Webpay.WebpayPlus
{
    public class Transaction : WebpayOptions
    {
        public Transaction() { ConfigureForTesting(); }
        public Transaction(Options options, HttpClient httpClient = null) : base(options, httpClient) { }
        public Transaction(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null) 
            : base(commerceCode, apiKey, integrationType, httpClient) { }

        public CreateResponse Create(string buyOrder, string sessionId,
            decimal amount, string returnUrl)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(sessionId, ApiConstants.SESSION_ID_LENGTH, "sessionId");
            ValidationUtil.hasTextWithMaxLength(returnUrl, ApiConstants.RETURN_URL_LENGTH, "returnUrl");

            return ExceptionHandler.Perform<CreateResponse, TransactionCreateException>(() =>
            {
                var createRequest = new CreateRequest(buyOrder, sessionId, amount, returnUrl);
                return _requestService.Perform<CreateResponse, TransactionCreateException>(
                    createRequest, Options);
            });
        }

        public CommitResponse Commit(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<CommitResponse, TransactionCommitException>(() =>
            {
                var commitRequest = new CommitRequest(token);
                return _requestService.Perform<CommitResponse, TransactionCommitException>(
                    commitRequest, Options);
            });
        }

        public RefundResponse Refund(string token, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<RefundResponse, TransactionRefundException>(() =>
            {
                var refundRequest = new RefundRequest(token, amount);
                return _requestService.Perform<RefundResponse, TransactionRefundException>(
                    refundRequest, Options);
            });
        }

        public StatusResponse Status(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<StatusResponse, TransactionStatusException>(() =>
            {
                var statusRequest = new StatusRequest(token);
                return _requestService.Perform<StatusResponse, TransactionStatusException>(
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
                return _requestService.Perform<CaptureResponse, TransactionCaptureException>(
                    captureRequest, Options);
            });
        }

        public IncreaseAmountResponse IncreaseAmount(string token, string buyOrder, string authorizationCode, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(authorizationCode, ApiConstants.AUTHORIZATION_CODE_LENGTH, "authorizationCode");

            return ExceptionHandler.Perform<IncreaseAmountResponse, IncreaseAmountException>(() =>
            {
                var req = new IncreaseAmountRequest($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}/amount", Options.CommerceCode, buyOrder, authorizationCode, amount);
                return _requestService.Perform<IncreaseAmountResponse, IncreaseAmountException>(req, Options);
            });
        }
        public IncreaseAuthorizationDateResponse IncreaseAuthorizationDate(string token, string buyOrder, string authorizationCode)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(authorizationCode, ApiConstants.AUTHORIZATION_CODE_LENGTH, "authorizationCode");

            return ExceptionHandler.Perform<IncreaseAuthorizationDateResponse, IncreaseAuthorizationDateException>(() =>
            {
                var req = new IncreaseAuthorizationDateRequest($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}/authorization_date", Options.CommerceCode, buyOrder, authorizationCode);
                return _requestService.Perform<IncreaseAuthorizationDateResponse, IncreaseAuthorizationDateException>(req, Options);
            });
        }
        public ReversePreAuthorizedAmountResponse ReversePreAuthorizedAmount(string token, string buyOrder, string authorizationCode, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(authorizationCode, ApiConstants.AUTHORIZATION_CODE_LENGTH, "authorizationCode");

            return ExceptionHandler.Perform<ReversePreAuthorizedAmountResponse, ReversePreAuthorizedAmountException>(() =>
            {
                var req = new ReversePreAuthorizedAmountRequest($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}/reverse/amount", Options.CommerceCode, buyOrder, authorizationCode, amount);
                return _requestService.Perform<ReversePreAuthorizedAmountResponse, ReversePreAuthorizedAmountException>(req, Options);
            });
        }
        public List<DeferredCaptureHistoryResponse> DeferredCaptureHistory(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<List<DeferredCaptureHistoryResponse>, DeferredCaptureHistoryException>(() =>
            {
                var req = new DeferredCaptureHistoryRequest($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}/details");
                return _requestService.PerformToList<DeferredCaptureHistoryResponse, DeferredCaptureHistoryException>(req, Options);
            });
        }


        /*
        |--------------------------------------------------------------------------
        | Environment Configuration
        |--------------------------------------------------------------------------
        */

        public void ConfigureForTesting()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY);
        }

        public void ConfigureForTestingDeferred()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_DEFERRED, IntegrationApiKeys.WEBPAY);
        }

    }
}
