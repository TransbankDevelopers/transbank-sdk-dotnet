using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Transbank.Common;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;
using Transbank.Webpay.Oneclick.Exceptions;
using Transbank.Webpay.WebpayPlus.Exceptions;
using Transbank.WebpayRest.Oneclick.Requests;
using Transbank.WebpayRest.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    public static class MallTransaction
    {
        private static string _commerceCode = "597055555541";
        private static string _apiKey = "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C";

        private static WebpayIntegrationType _integrationType = WebpayIntegrationType.Test;
        public static string CommerceCode
        {
            get => _commerceCode;
            set => _commerceCode = value ?? throw new ArgumentNullException(
                                       nameof(value), "Commerce code can't be null."
                                   );
        }

        public static string ApiKey
        {
            get => _apiKey;
            set => _apiKey = value ?? throw new ArgumentNullException(
                                 nameof(value), "Api Key can't be null."
                             );
        }

        public static WebpayIntegrationType IntegrationType
        {
            get => _integrationType;
            set => _integrationType = value ?? throw new ArgumentNullException(
                                          nameof(value), "Integration type can't be null."
                                      );
        }

        public static Options DefaultOptions()
        {
            return new Options(CommerceCode, ApiKey, IntegrationType);
        }
        
        public static MallAuthorizeResponse Authorize(string userName, string tbkUser,
            string buyOrder, List<PaymentRequest> details)
        {
            return Authorize(userName, tbkUser, buyOrder, details, DefaultOptions());
        }

        public static MallAuthorizeResponse Authorize(string userName, string tbkUser, string buyOrder,
            List<PaymentRequest> details, Options options)
        {
            ValidationUtil.hasTextWithMaxLength(userName, ApiConstant.USER_NAME_LENGTH, "userName");
            ValidationUtil.hasTextWithMaxLength(tbkUser, ApiConstant.TBK_USER_LENGTH, "tbkUser");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstant.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasElements(details, "details");

            foreach (var item in details)
            {
                ValidationUtil.hasTextWithMaxLength(item.CommerceCode, ApiConstant.COMMERCE_CODE_LENGTH, "details.commerceCode");
                ValidationUtil.hasTextWithMaxLength(item.BuyOrder, ApiConstant.BUY_ORDER_LENGTH, "details.buyOrder");
            }

            return ExceptionHandler.Perform<MallAuthorizeResponse, MallTransactionAuthorizeException>(() =>
            {
                var authorizeRequest = new MallAuthorizeRequest(userName, tbkUser, buyOrder,
                    details);
                var response = RequestService.Perform<MallTransactionAuthorizeException>(authorizeRequest, options);

                return JsonConvert.DeserializeObject<MallAuthorizeResponse>(response);
            });
        }

        public static MallRefundResponse Refund(string buyOrder, string childCommerceCode, string childBuyOrder,
            decimal amount)
        {
            return Refund(buyOrder, childCommerceCode, childBuyOrder, amount, DefaultOptions());
        }

        public static MallRefundResponse Refund(string buyOrder, string childCommerceCode, string childBuyOrder,
            decimal amount, Options options)
        {
            ValidationUtil.hasTextWithMaxLength(childCommerceCode, ApiConstant.COMMERCE_CODE_LENGTH, "childCommerceCode");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstant.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(childBuyOrder, ApiConstant.BUY_ORDER_LENGTH, "childBuyOrder");

            return ExceptionHandler.Perform<MallRefundResponse, MallTransactionRefundException>(() =>
            {
                var mallRefundRequest = new MallRefundRequest(buyOrder, childCommerceCode, childBuyOrder, amount);
                var response = RequestService.Perform<MallTransactionRefundException>(mallRefundRequest, options);
                return JsonConvert.DeserializeObject<MallRefundResponse>(response);
            });
        }

        public static MallStatusResponse Status(string buyOrder)
        {
            return Status(buyOrder, DefaultOptions());
        }
        
        public static MallStatusResponse Status(string buyOrder, Options options)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstant.BUY_ORDER_LENGTH, "buyOrder");

            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(buyOrder);
                var response = RequestService.Perform<MallTransactionStatusException>(mallStatusRequest, options);
                return JsonConvert.DeserializeObject<MallStatusResponse>(response);
            });
        }
    }
}
