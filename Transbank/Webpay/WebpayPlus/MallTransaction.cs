using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.Common;
using System.Collections.Generic;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.WebpayPlus.Responses;
using Transbank.Exceptions;

namespace Transbank.Webpay.WebpayPlus
{
    public class MallTransaction : WebpayOptions
    {
        public MallTransaction() : this(
            new Options(
                IntegrationCommerceCodes.WEBPAY_PLUS_MALL,
                IntegrationApiKeys.WEBPAY,
                WebpayIntegrationType.Test
            )
        )
        { }

        public MallTransaction(Options options) : base(options) { }

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
                var response = RequestService.Perform<MallTransactionCreateException>(
                    mallCreateRequest, Options);

                return JsonConvert.DeserializeObject<MallCreateResponse>(response);
            });
        }

        public MallCommitResponse Commit(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallCommitResponse, MallTransactionCommitException>(() =>
            {
                var mallCommitRequest = new MallCommitRequest(token);
                var response = RequestService.Perform<MallTransactionCommitException>(
                    mallCommitRequest, Options);

                return JsonConvert.DeserializeObject<MallCommitResponse>(response);
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
                var response = RequestService.Perform<MallTransactionRefundException>(
                    mallRefundRequest, Options);

                return JsonConvert.DeserializeObject<MallRefundResponse>(response);
            });
        }

        public MallStatusResponse Status(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(token);
                var response = RequestService.Perform<MallTransactionStatusException>(
                    mallStatusRequest, Options);

                return JsonConvert.DeserializeObject<MallStatusResponse>(response);
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
                var response = RequestService.Perform<MallTransactionCaptureException>(mallCaptureRequest, Options);
                return JsonConvert.DeserializeObject<MallCaptureResponse>(response);
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

        public void ConfigureForTestingMall()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MALL, IntegrationApiKeys.WEBPAY);
        }

        public void ConfigureForTestingMallDeferred()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MALL_DEFERRED, IntegrationApiKeys.WEBPAY);
        }
    }
}
