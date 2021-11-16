using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus.Exceptions;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.WebpayPlus.Responses;

namespace Transbank.Webpay.WebpayPlus
{
    public static class MallTransaction
    {
        private static string _commerceCode = "597055555535";
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

        public static MallCreateResponse Create(string buyOrder, string sessionId,
            string returnUrl, List<TransactionDetail> transactions)
        {
            return Create(buyOrder, sessionId, returnUrl, transactions, DefaultOptions());
        }

        public static MallCreateResponse Create(string buyOrder, string sessionId,
            string returnUrl, List<TransactionDetail> transactions, Options options)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstant.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(sessionId, ApiConstant.SESSION_ID_LENGTH, "sessionId");
            ValidationUtil.hasTextWithMaxLength(returnUrl, ApiConstant.RETURN_URL_LENGTH, "returnUrl");
            ValidationUtil.hasElements(transactions, "transactions");

            foreach (var item in transactions)
            {
                ValidationUtil.hasTextWithMaxLength(item.CommerceCode, ApiConstant.COMMERCE_CODE_LENGTH, "transactions.commerceCode");
                ValidationUtil.hasTextWithMaxLength(item.BuyOrder, ApiConstant.BUY_ORDER_LENGTH, "transactions.buyOrder");
            }

            return ExceptionHandler.Perform<MallCreateResponse, MallTransactionCreateException>(() =>
            {
                var mallCreateRequest = new MallCreateRequest(buyOrder, sessionId,
                    returnUrl, transactions);
                var response = RequestService.Perform<MallTransactionCreateException>(
                    mallCreateRequest, options);

                return JsonConvert.DeserializeObject<MallCreateResponse>(response);
            });
        }

        public static MallCommitResponse Commit(string token)
        {
            return Commit(token, DefaultOptions());
        }

        public static MallCommitResponse Commit(string token, Options options)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallCommitResponse, MallTransactionCommitException>(() =>
            {
                var mallCommitRequest = new MallCommitRequest(token);
                var response = RequestService.Perform<MallTransactionCommitException>(
                    mallCommitRequest, options);

                return JsonConvert.DeserializeObject<MallCommitResponse>(response);
            });
        }

        public static MallRefundResponse Refund(string token, string buyOrder,
            string commerceCode, decimal amount)
        {
            return Refund(token, buyOrder, commerceCode, amount, DefaultOptions());
        }

        public static MallRefundResponse Refund(string token, string buyOrder,
            string commerceCode, decimal amount, Options options)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");
            ValidationUtil.hasTextWithMaxLength(commerceCode, ApiConstant.COMMERCE_CODE_LENGTH, "commerceCode");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstant.BUY_ORDER_LENGTH, "buyOrder");

            return ExceptionHandler.Perform<MallRefundResponse, MallTransactionRefundException>(() =>
            {
                var mallRefundRequest = new MallRefundRequest(token, buyOrder,
                    commerceCode, amount);
                var response = RequestService.Perform<MallTransactionRefundException>(
                    mallRefundRequest, options);

                return JsonConvert.DeserializeObject<MallRefundResponse>(response);
            });
        }

        public static MallStatusResponse Status(string token)
        {
            return Status(token, DefaultOptions());
        }

        public static MallStatusResponse Status(string token, Options options)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(token);
                var response = RequestService.Perform<MallTransactionStatusException>(
                    mallStatusRequest, options);

                return JsonConvert.DeserializeObject<MallStatusResponse>(response);
            });
        }
    }
}
