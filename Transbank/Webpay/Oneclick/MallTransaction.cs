using System;
using System.Collections.Generic;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    public class MallTransaction
    {

        private Options _options;

        public Options Options
        {
            get => _options;
            private set => _options = value ?? throw new ArgumentNullException(
                nameof(value), "Options can't be null."
            );
        }

        public MallTransaction(Options options)
        {
            Options = options;
        }

        public static MallTransaction buildForIntegration(string commerceCode, string apiKey)
        {
            MallTransaction mallTransaction = new MallTransaction(new Options(commerceCode, apiKey, WebpayIntegrationType.Test));

            return mallTransaction;
        }

        public static MallTransaction buildForProduction(string commerceCode, string apiKey)
        {
            MallTransaction transaction = new MallTransaction(new Options(commerceCode, apiKey, WebpayIntegrationType.Live));

            return transaction;
        }

        public MallAuthorizeResponse Authorize(string userName, string tbkUser, string parentBuyOrder,
            List<PaymentRequest> details)
        {
            ValidationUtil.hasTextWithMaxLength(userName, ApiConstants.USER_NAME_LENGTH, "userName");
            ValidationUtil.hasTextWithMaxLength(tbkUser, ApiConstants.TBK_USER_LENGTH, "tbkUser");
            ValidationUtil.hasTextWithMaxLength(parentBuyOrder, ApiConstants.BUY_ORDER_LENGTH, "parentBuyOrder");
            ValidationUtil.hasElements(details, "details");

            foreach (var item in details)
            {
                ValidationUtil.hasTextWithMaxLength(item.CommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "details.commerceCode");
                ValidationUtil.hasTextWithMaxLength(item.BuyOrder, ApiConstants.BUY_ORDER_LENGTH, "details.buyOrder");
            }

            return ExceptionHandler.Perform<MallAuthorizeResponse, MallTransactionAuthorizeException>(() =>
            {
                var authorizeRequest = new MallAuthorizeRequest(userName, tbkUser, parentBuyOrder,
                    details);
                return Options.RequestService.Perform<MallAuthorizeResponse, MallTransactionAuthorizeException>(authorizeRequest, Options);
            });
        }

        public MallRefundResponse Refund(string buyOrder, string childCommerceCode, string childBuyOrder,
            decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(childCommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "childCommerceCode");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(childBuyOrder, ApiConstants.BUY_ORDER_LENGTH, "childBuyOrder");

            return ExceptionHandler.Perform<MallRefundResponse, MallTransactionRefundException>(() =>
            {
                var mallRefundRequest = new MallRefundRequest(buyOrder, childCommerceCode, childBuyOrder, amount);
                return Options.RequestService.Perform<MallRefundResponse, MallTransactionRefundException>(mallRefundRequest, Options);
            });
        }

        public MallStatusResponse Status(string buyOrder)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");

            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(buyOrder);
                return Options.RequestService.Perform<MallStatusResponse, MallTransactionStatusException>(mallStatusRequest, Options);
            });
        }

        public MallCaptureResponse Capture(string childCommerceCode, string childBuyOrder, string authorizationCode, decimal captureAmount)
        {
            ValidationUtil.hasTextWithMaxLength(childCommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "childCommerceCode");
            ValidationUtil.hasTextWithMaxLength(childBuyOrder, ApiConstants.BUY_ORDER_LENGTH, "childBuyOrder");
            ValidationUtil.hasTextWithMaxLength(authorizationCode, ApiConstants.AUTHORIZATION_CODE_LENGTH, "authorizationCode");

            return ExceptionHandler.Perform<MallCaptureResponse, MallCaptureException>(() =>
            {
                long.TryParse(childCommerceCode, out long ccode);
                var mallCaptureRequest = new MallCaptureRequest(ccode, childBuyOrder, captureAmount, authorizationCode);
                return Options.RequestService.Perform<MallCaptureResponse, MallCaptureException>(mallCaptureRequest, Options);
            });
        }
    }
}
