using Transbank.Common;
using System.Collections.Generic;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.Requests;
using Transbank.Webpay.Responses;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;
using System.Net.Http;

namespace Transbank.Webpay.Oneclick
{
    public class MallTransaction : OneclickOptions
    {
        public MallTransaction(){ ConfigureForTesting(); }
        public MallTransaction(Options options, HttpClient httpClient = null) : base(options, httpClient) { }
        public MallTransaction(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null)
            : base(commerceCode, apiKey, integrationType, httpClient) { }

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
                return _requestService.Perform<MallAuthorizeResponse, MallTransactionAuthorizeException>(authorizeRequest, Options);
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
                return _requestService.Perform<MallRefundResponse, MallTransactionRefundException>(mallRefundRequest, Options);
            });
        }

        public MallStatusResponse Status(string buyOrder)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");

            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(buyOrder);
                return _requestService.Perform<MallStatusResponse, MallTransactionStatusException>(mallStatusRequest, Options);
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
                return _requestService.Perform<MallCaptureResponse, MallCaptureException>(mallCaptureRequest, Options);
            });
        }

        public IncreaseAmountResponse IncreaseAmount(string childCommerceCode, string childBuyOrder, string authorizationCode, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(childCommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "childCommerceCode");
            ValidationUtil.hasTextWithMaxLength(childBuyOrder, ApiConstants.BUY_ORDER_LENGTH, "childBuyOrder");
            ValidationUtil.hasTextWithMaxLength(authorizationCode, ApiConstants.AUTHORIZATION_CODE_LENGTH, "authorizationCode");

            return ExceptionHandler.Perform<IncreaseAmountResponse, IncreaseAmountException>(() =>
            {
                var req = new IncreaseAmountRequest($"{ApiConstants.ONECLICK_METHOD}/transactions/amount", childCommerceCode, childBuyOrder, authorizationCode, amount);
                return _requestService.Perform<IncreaseAmountResponse, IncreaseAmountException>(req, Options);
            });
        }
        public IncreaseAuthorizationDateResponse IncreaseAuthorizationDate(string childCommerceCode, string childBuyOrder, string authorizationCode)
        {
            ValidationUtil.hasTextWithMaxLength(childCommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "childCommerceCode");
            ValidationUtil.hasTextWithMaxLength(childBuyOrder, ApiConstants.BUY_ORDER_LENGTH, "childBuyOrder");
            ValidationUtil.hasTextWithMaxLength(authorizationCode, ApiConstants.AUTHORIZATION_CODE_LENGTH, "authorizationCode");

            return ExceptionHandler.Perform<IncreaseAuthorizationDateResponse, IncreaseAuthorizationDateException>(() =>
            {
                var req = new IncreaseAuthorizationDateRequest($"{ApiConstants.ONECLICK_METHOD}/transactions/authorization_date", childCommerceCode, childBuyOrder, authorizationCode);
                return _requestService.Perform<IncreaseAuthorizationDateResponse, IncreaseAuthorizationDateException>(req, Options);
            });
        }
        public ReversePreAuthorizedAmountResponse ReversePreAuthorizedAmount(string childCommerceCode, string childBuyOrder, string authorizationCode, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(childCommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "childCommerceCode");
            ValidationUtil.hasTextWithMaxLength(childBuyOrder, ApiConstants.BUY_ORDER_LENGTH, "childBuyOrder");
            ValidationUtil.hasTextWithMaxLength(authorizationCode, ApiConstants.AUTHORIZATION_CODE_LENGTH, "authorizationCode");

            return ExceptionHandler.Perform<ReversePreAuthorizedAmountResponse, ReversePreAuthorizedAmountException>(() =>
            {
                var req = new ReversePreAuthorizedAmountRequest($"{ApiConstants.ONECLICK_METHOD}/transactions/reverse/amount", childCommerceCode, childBuyOrder, authorizationCode, amount);
                return _requestService.Perform<ReversePreAuthorizedAmountResponse, ReversePreAuthorizedAmountException>(req, Options);
            });
        }
        public List<DeferredCaptureHistoryResponse> DeferredCaptureHistory(string childCommerceCode, string childBuyOrder, string authorizationCode)
        {
            ValidationUtil.hasTextWithMaxLength(childCommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "childCommerceCode");
            ValidationUtil.hasTextWithMaxLength(childBuyOrder, ApiConstants.BUY_ORDER_LENGTH, "childBuyOrder");
            ValidationUtil.hasTextWithMaxLength(authorizationCode, ApiConstants.AUTHORIZATION_CODE_LENGTH, "authorizationCode");

            return ExceptionHandler.Perform<List<DeferredCaptureHistoryResponse>, DeferredCaptureHistoryException>(() =>
            {
                var req = new DeferredCaptureHistoryRequest($"{ApiConstants.ONECLICK_METHOD}/transactions/details", childCommerceCode, childBuyOrder, authorizationCode);
                return _requestService.PerformToList<DeferredCaptureHistoryResponse, DeferredCaptureHistoryException>(req, Options);
            });
        }

    }
}
