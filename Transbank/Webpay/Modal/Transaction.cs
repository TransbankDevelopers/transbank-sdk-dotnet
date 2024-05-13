using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.Modal.Requests;
using Transbank.Webpay.Modal.Responses;

namespace Transbank.Webpay.Modal
{
    public class Transaction :  WebpayOptions
    {
        private Transaction() {  }
        public Transaction(Options options, HttpClient httpClient = null) : base(options, httpClient) { }
        public Transaction(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null)
            : base(commerceCode, apiKey, integrationType, httpClient) { }

        public static Transaction buildForProduction(string commerceCode, string apiKey)
        {

            Transaction transaction = new Transaction();
            transaction.ConfigureForProduction(commerceCode, apiKey);
            return transaction;

        }

        public static Transaction buildForIntegration(string commerceCode, string apiKey)
        {

            Transaction transaction = new Transaction();
            transaction.ConfigureForIntegration(commerceCode, apiKey);
            return transaction;

        }

        public CreateResponse Create(string buyOrder, string sessionId,
            decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(sessionId, ApiConstants.SESSION_ID_LENGTH, "sessionId");

            return ExceptionHandler.Perform<CreateResponse, TransactionCreateException>(() =>
            {
                var createRequest = new CreateRequest(buyOrder, sessionId, amount);
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

        /*
        |--------------------------------------------------------------------------
        | Environment Configuration
        |--------------------------------------------------------------------------
        */
        public void ConfigureForTesting()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MODAL, IntegrationApiKeys.WEBPAY);
        }

    }
}
