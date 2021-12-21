using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.WebpayPlus.Responses;

namespace Transbank.Webpay.WebpayPlus
{
    public class Transaction : WebpayOptions
    {
        public Transaction() : this(
            new Options(
                IntegrationCommerceCodes.WEBPAY_PLUS,
                IntegrationApiKeys.WEBPAY,
                WebpayIntegrationType.Test
            )
        )
        { }

        public Transaction(Options options) : base(options) { }

        public CreateResponse Create(string buyOrder, string sessionId,
            decimal amount, string returnUrl)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(sessionId, ApiConstants.SESSION_ID_LENGTH, "sessionId");
            ValidationUtil.hasTextWithMaxLength(returnUrl, ApiConstants.RETURN_URL_LENGTH, "returnUrl");

            return ExceptionHandler.Perform<CreateResponse, TransactionCreateException>(() =>
            {
                var createRequest = new CreateRequest(buyOrder, sessionId, amount, returnUrl);
                var response = RequestService.Perform<TransactionCreateException>(
                    createRequest, Options);

                return JsonConvert.DeserializeObject<CreateResponse>(response);
            });
        }

        public CommitResponse Commit(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<CommitResponse, TransactionCommitException>(() =>
            {
                var commitRequest = new CommitRequest(token);
                var response = RequestService.Perform<TransactionCommitException>(
                    commitRequest, Options);

                return JsonConvert.DeserializeObject<CommitResponse>(response);
            });
        }

        public RefundResponse Refund(string token, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<RefundResponse, TransactionRefundException>(() =>
            {
                var refundRequest = new RefundRequest(token, amount);
                var response = RequestService.Perform<TransactionRefundException>(
                    refundRequest, Options);

                return JsonConvert.DeserializeObject<RefundResponse>(response);
            });
        }

        public StatusResponse Status(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<StatusResponse, TransactionStatusException>(() =>
            {
                var statusRequest = new StatusRequest(token);
                var response = RequestService.Perform<TransactionStatusException>(
                    statusRequest, Options);

                return JsonConvert.DeserializeObject<StatusResponse>(response);
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
                var response = RequestService.Perform<TransactionCaptureException>(
                    captureRequest, Options);

                return JsonConvert.DeserializeObject<CaptureResponse>(response);
            });
        }


        /*
        |--------------------------------------------------------------------------
        | Environment Configuration
        |--------------------------------------------------------------------------
        */

        public void ConfigureForIntegration(string commerceCode, string apiKey)
        {
            Options = new Options(commerceCode, apiKey, WebpayIntegrationType.Test);
        }

        public void ConfigureForProduction(string commerceCode, string apiKey)
        {
            Options = new Options(commerceCode, apiKey, WebpayIntegrationType.Live);
        }

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
