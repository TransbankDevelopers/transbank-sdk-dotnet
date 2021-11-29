using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.Common;
using System.Collections.Generic;
using Transbank.Webpay.WebpayPlus.Exceptions;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.WebpayPlus.Responses;

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
            string returnUrl, List<TransactionDetail> transactions)
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
                    mallCreateRequest, Options);

                return JsonConvert.DeserializeObject<MallCreateResponse>(response);
            });
        }

        public MallCommitResponse Commit(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallCommitResponse, MallTransactionCommitException>(() =>
            {
                var mallCommitRequest = new MallCommitRequest(token);
                var response = RequestService.Perform<MallTransactionCommitException>(
                    mallCommitRequest, Options);

                return JsonConvert.DeserializeObject<MallCommitResponse>(response);
            });
        }

        public MallRefundResponse Refund(string token, string buyOrder,
            string commerceCode, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");
            ValidationUtil.hasTextWithMaxLength(commerceCode, ApiConstant.COMMERCE_CODE_LENGTH, "commerceCode");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstant.BUY_ORDER_LENGTH, "buyOrder");

            return ExceptionHandler.Perform<MallRefundResponse, MallTransactionRefundException>(() =>
            {
                var mallRefundRequest = new MallRefundRequest(token, buyOrder,
                    commerceCode, amount);
                var response = RequestService.Perform<MallTransactionRefundException>(
                    mallRefundRequest, Options);

                return JsonConvert.DeserializeObject<MallRefundResponse>(response);
            });
        }

        public MallStatusResponse Status(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(token);
                var response = RequestService.Perform<MallTransactionStatusException>(
                    mallStatusRequest, Options);

                return JsonConvert.DeserializeObject<MallStatusResponse>(response);
            });
        }

        public MallCaptureResponse Capture(string token, string commerceCode, string buyOrder,
            string authorizationCode, decimal amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");
            ValidationUtil.hasTextWithMaxLength(commerceCode, ApiConstant.COMMERCE_CODE_LENGTH, "commerceCode");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstant.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(authorizationCode, ApiConstant.AUTHORIZATION_CODE_LENGTH, "authorizationCode");

            return ExceptionHandler.Perform<MallCaptureResponse, MallTransactionCaptureException>(() =>
            {
                var mallCaptureRequest = new MallCaptureRequest(token, commerceCode, buyOrder, authorizationCode, amount);
                var response = RequestService.Perform<MallTransactionCaptureException>(mallCaptureRequest, Options);
                return JsonConvert.DeserializeObject<MallCaptureResponse>(response);
            });
        }
    }
}
