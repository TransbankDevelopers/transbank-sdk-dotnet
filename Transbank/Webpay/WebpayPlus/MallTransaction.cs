using Transbank.Common;
using Transbank.Webpay.Common;
using System.Collections.Generic;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.WebpayPlus.Responses;
using Transbank.Exceptions;
using System.Net.Http;

namespace Transbank.Webpay.WebpayPlus
{
    public class MallTransaction : WebpayOptions
    {
        public MallTransaction() { ConfigureForTesting(); }
        public MallTransaction(Options options, HttpClient httpClient = null) : base(options, httpClient) { }
        public MallTransaction(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null)
            : base(commerceCode, apiKey, integrationType, httpClient) { }

        public MallCreateResponse Create(string buyOrder, string sessionId,
            string returnUrl, List<TransactionDetail> details)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(sessionId, ApiConstants.SESSION_ID_LENGTH, "sessionId");
            ValidationUtil.hasTextWithMaxLength(returnUrl, ApiConstants.RETURN_URL_LENGTH, "returnUrl");
            ValidationUtil.hasElements(details, "details");

            foreach (var item in details)
            {
                ValidationUtil.hasTextWithMaxLength(item.CommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "details.commerceCode");
                ValidationUtil.hasTextWithMaxLength(item.BuyOrder, ApiConstants.BUY_ORDER_LENGTH, "details.buyOrder");
            }

            return ExceptionHandler.Perform<MallCreateResponse, MallTransactionCreateException>(() =>
            {
                var mallCreateRequest = new MallCreateRequest(buyOrder, sessionId,
                    returnUrl, details);
                return _requestService.Perform<MallCreateResponse, MallTransactionCreateException>(
                    mallCreateRequest, Options);
            });
        }

        public MallCommitResponse Commit(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallCommitResponse, MallTransactionCommitException>(() =>
            {
                var mallCommitRequest = new MallCommitRequest(token);
                return _requestService.Perform<MallCommitResponse, MallTransactionCommitException>(
                    mallCommitRequest, Options);
            });
        }

        public MallRefundResponse Refund(string token, string buyOrder,
            string childCommerceCode, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");
            ValidationUtil.hasTextWithMaxLength(childCommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "childCommerceCode");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");

            return ExceptionHandler.Perform<MallRefundResponse, MallTransactionRefundException>(() =>
            {
                var mallRefundRequest = new MallRefundRequest(token, buyOrder,
                    childCommerceCode, amount);
                return _requestService.Perform<MallRefundResponse, MallTransactionRefundException>(
                    mallRefundRequest, Options);
            });
        }

        public MallStatusResponse Status(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(token);
                return _requestService.Perform<MallStatusResponse, MallTransactionStatusException>(
                    mallStatusRequest, Options);
            });
        }

        public MallCaptureResponse Capture(string childCommerceCode, string token, string buyOrder,
            string authorizationCode, decimal captureAmount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");
            ValidationUtil.hasTextWithMaxLength(childCommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "childCommerceCode");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(authorizationCode, ApiConstants.AUTHORIZATION_CODE_LENGTH, "authorizationCode");

            return ExceptionHandler.Perform<MallCaptureResponse, MallTransactionCaptureException>(() =>
            {
                var mallCaptureRequest = new MallCaptureRequest(token, childCommerceCode, buyOrder, authorizationCode, captureAmount);
                return _requestService.Perform<MallCaptureResponse, MallTransactionCaptureException>(mallCaptureRequest, Options);
            });
        }

        /*
        |--------------------------------------------------------------------------
        | Environment Configuration
        |--------------------------------------------------------------------------
        */
        public void ConfigureForTesting()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MALL, IntegrationApiKeys.WEBPAY);
        }

        public void ConfigureForTestingDeferred()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MALL_DEFERRED, IntegrationApiKeys.WEBPAY);
        }
    }
}
