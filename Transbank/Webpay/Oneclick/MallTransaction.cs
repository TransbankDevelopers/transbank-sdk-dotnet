using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using System.Collections.Generic;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    public class MallTransaction : OneclickOptions
    {
        public MallTransaction() : this(
            new Options(
                IntegrationCommerceCodes.ONECLICK_MALL,
                IntegrationApiKeys.WEBPAY,
                WebpayIntegrationType.Test
            )
        )
        { }

        public MallTransaction(Options options) : base(options) { }

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
                var response = RequestService.Perform<MallTransactionAuthorizeException>(authorizeRequest, Options);

                return JsonConvert.DeserializeObject<MallAuthorizeResponse>(response);
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
                var response = RequestService.Perform<MallTransactionRefundException>(mallRefundRequest, Options);
                return JsonConvert.DeserializeObject<MallRefundResponse>(response);
            });
        }

        public MallStatusResponse Status(string buyOrder)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");

            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(buyOrder);
                var response = RequestService.Perform<MallTransactionStatusException>(mallStatusRequest, Options);
                return JsonConvert.DeserializeObject<MallStatusResponse>(response);
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
                var response = RequestService.Perform<MallCaptureException>(mallCaptureRequest, Options);
                return JsonConvert.DeserializeObject<MallCaptureResponse>(response);
            });
        }
    }
}
