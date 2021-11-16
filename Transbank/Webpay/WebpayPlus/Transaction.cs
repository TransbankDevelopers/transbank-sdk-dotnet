using System;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus.Responses;
using Newtonsoft.Json;

namespace Transbank.Webpay.WebpayPlus
{
    public static class Transaction
    {
        private static string _commerceCode = "597055555532";
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

        public static CreateResponse Create(string buyOrder, string sessionId,
            decimal amount, string returnUrl)
        {
            return Create(buyOrder, sessionId, amount, returnUrl, DefaultOptions());
        }

        public static CreateResponse Create(string buyOrder, string sessionId,
            decimal amount, string returnUrl, Options options)
        {

            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstant.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(sessionId, ApiConstant.SESSION_ID_LENGTH, "sessionId");
            ValidationUtil.hasTextWithMaxLength(returnUrl, ApiConstant.RETURN_URL_LENGTH, "returnUrl");

            return ExceptionHandler.Perform<CreateResponse, TransactionCreateException>(() =>
            {
                var createRequest = new CreateRequest(buyOrder, sessionId, amount, returnUrl);
                var response = RequestService.Perform<TransactionCreateException>(
                    createRequest, options);

                return JsonConvert.DeserializeObject<CreateResponse>(response);
            });
        }

        public static CommitResponse Commit(string token)
        {
            return Commit(token, DefaultOptions());
        }

        public static CommitResponse Commit(string token, Options options)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<CommitResponse, TransactionCommitException>(() =>
            {
                var commitRequest = new CommitRequest(token);
                var response = RequestService.Perform<TransactionCommitException>(
                    commitRequest, options);

                return JsonConvert.DeserializeObject<CommitResponse>(response);
            });
        }

        public static RefundResponse Refund(string token, decimal amount)
        {
            return Refund(token, amount, DefaultOptions());
        }

        public static RefundResponse Refund(string token, decimal amount, Options options)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<RefundResponse, TransactionRefundException>(() =>
            {
                var refundRequest = new RefundRequest(token, amount);
                var response = RequestService.Perform<TransactionRefundException>(
                    refundRequest, options);

                return JsonConvert.DeserializeObject<RefundResponse>(response);
            });
        }

        public static StatusResponse Status(string token)
        {
            return Status(token, DefaultOptions());
        }

        public static StatusResponse Status(string token, Options options)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<StatusResponse, TransactionStatusException>(() =>
            {
                var statusRequest = new StatusRequest(token);
                var response = RequestService.Perform<TransactionStatusException>(
                    statusRequest, options);

                return JsonConvert.DeserializeObject<StatusResponse>(response);
            });
        }
    }
}
