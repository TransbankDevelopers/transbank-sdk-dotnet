using Transbank.Common;
using Transbank.Webpay.Common;
using System.Collections.Generic;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.WebpayPlus.Responses;
using Transbank.Exceptions;

namespace Transbank.Webpay.WebpayPlus
{
    public class MallTransaction
    {
        public Options options;
        public MallTransaction(Options options)
        {
            this.options = options;
        }


        public static MallTransaction buildForIntegration(string commerceCode, string apiKey)
        {
            MallTransaction mallTransaction = new MallTransaction(new Options(commerceCode, apiKey, WebpayIntegrationType.Test));

            return mallTransaction;
        }

        public static MallTransaction buildForProduction(string commerceCode, string apiKey)
        {
            MallTransaction mallTransaction = new MallTransaction(new Options(commerceCode, apiKey, WebpayIntegrationType.Live));

            return mallTransaction;
        }

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
                return options.RequestService.Perform<MallCreateResponse, MallTransactionCreateException>(
                    mallCreateRequest, options);
            });
        }

        public MallCommitResponse Commit(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallCommitResponse, MallTransactionCommitException>(() =>
            {
                var mallCommitRequest = new MallCommitRequest(token);
                return options.RequestService.Perform<MallCommitResponse, MallTransactionCommitException>(
                    mallCommitRequest, options);
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
                return options.RequestService.Perform<MallRefundResponse, MallTransactionRefundException>(
                    mallRefundRequest, options);
            });
        }

        public MallStatusResponse Status(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(token);
                return options.RequestService.Perform<MallStatusResponse, MallTransactionStatusException>(
                    mallStatusRequest, options);
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
                return options.RequestService.Perform<MallCaptureResponse, MallTransactionCaptureException>(mallCaptureRequest, options);
            });
        }
    }
}
