using System;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using System.Collections.Generic;
using Transbank.Webpay.TransaccionCompletaMall.Common;
using Transbank.Webpay.TransaccionCompletaMall.Requests;
using Transbank.Webpay.TransaccionCompletaMall.Responses;

namespace Transbank.Webpay.TransaccionCompletaMall
{
    public class MallFullTransaction : WebpayOptions
    {
        public MallFullTransaction() : this(
            new Options(
                IntegrationCommerceCodes.TRANSACCION_COMPLETA_MALL,
                IntegrationApiKeys.WEBPAY,
                WebpayIntegrationType.Test
            )
        )
        { }

        public MallFullTransaction(Options options) : base(options) {}

        public  MallCreateResponse Create(
            string buyOrder,
            string sessionId,
            string cardNumber,
            string cardExpirationDate,
            List<CreateDetails> details,
            short? cvv
            )
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(sessionId, ApiConstants.SESSION_ID_LENGTH, "sessionId");
            ValidationUtil.hasTextWithMaxLength(cardNumber, ApiConstants.CARD_NUMBER_LENGTH, "cardNumber");
            ValidationUtil.hasTextWithMaxLength(cardExpirationDate, ApiConstants.CARD_EXPIRATION_DATE_LENGTH, "cardExpirationDate");
            ValidationUtil.hasElements(details, "details");

            foreach (var item in details)
            {
                ValidationUtil.hasTextWithMaxLength(item.CommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "details.commerceCode");
                ValidationUtil.hasTextWithMaxLength(item.BuyOrder, ApiConstants.BUY_ORDER_LENGTH, "details.buyOrder");
            }

            return ExceptionHandler.Perform<MallCreateResponse, MallTransactionCreateException>(() =>
            {
                var mallCreateRequest = new MallCreateRequest(
                    buyOrder,
                    sessionId,
                    cardNumber,
                    cardExpirationDate,
                    details,
                    cvv
                );
                var response = RequestService.Perform<MallTransactionCreateException>(mallCreateRequest, Options);

                return JsonConvert.DeserializeObject<MallCreateResponse>(response);
            });
        }

        public  MallInstallmentsResponse Installments(
            string token,
            string commerceCode,
            string buyOrder,
            int installmentsNumber)
        {

            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");
            ValidationUtil.hasTextWithMaxLength(commerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "commerceCode");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");

            return ExceptionHandler.Perform<MallInstallmentsResponse, MallTransactionInstallmentsExceptions>(() =>
            {
                var mallInstallmentsResponse = new MallInstallmentsRequest(
                    token,
                    commerceCode,
                    buyOrder,
                    installmentsNumber);
                var response = RequestService.Perform<MallTransactionInstallmentsExceptions>(mallInstallmentsResponse, Options);

                return JsonConvert.DeserializeObject<MallInstallmentsResponse>(response);
            });
        }

        public  MallInstallmentsDetailsResponse Installments(
            string token,
            List<MallInstallmentsDetails> details)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallInstallmentsDetailsResponse, MallTransactionInstallmentsExceptions>(() =>
            {
                List<MallInstallmentsResponse> det = new List<MallInstallmentsResponse>();

                foreach (MallInstallmentsDetails req in details)
                {
                    var request = new MallInstallmentsRequest(
                        token,
                        req.CommerceCode,
                        req.BuyOrder,
                        req.InstallmentsNumber);

                    var response = RequestService.Perform<MallTransactionInstallmentsExceptions>(request, Options);
                    var json = JsonConvert.DeserializeObject<MallInstallmentsResponse>(response);

                    det.Add(new MallInstallmentsResponse(json.InstallmentsAmount, json.IdQueryInstallments, json.DeferredPeriods));

                }

                return JsonConvert.DeserializeObject<MallInstallmentsDetailsResponse>(det.ToString());
            });
        }

        public  MallCommitResponse Commit(
            string token,
            List<MallCommitDetails> details)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallCommitResponse, MallTransactionCommitException>(() =>
            {
                var mallCommitRequest = new MallCommitRequest(
                    token,
                    details);
                var response = RequestService.Perform<MallTransactionCommitException>(mallCommitRequest, Options);

                return JsonConvert.DeserializeObject<MallCommitResponse>(response);
            });
        }

        public  MallRefundResponse Refund(
            string token,
            string buyOrder,
            string childCommerceCode,
            int amount)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");
            ValidationUtil.hasTextWithMaxLength(childCommerceCode, ApiConstants.COMMERCE_CODE_LENGTH, "childCommerceCode");
            ValidationUtil.hasTextWithMaxLength(buyOrder, ApiConstants.BUY_ORDER_LENGTH, "buyOrder");

            return ExceptionHandler.Perform<MallRefundResponse, MallTransactionRefundException>(() =>
            {
                var mallRefundRequest = new MallRefundRequest(
                    token,
                    buyOrder,
                    childCommerceCode,
                    amount);
                var response = RequestService.Perform<MallTransactionRefundException>(mallRefundRequest, Options);

                return JsonConvert.DeserializeObject<MallRefundResponse>(response);

            });
        }

        public  MallStatusResponse Status(string token)
        {

            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");
            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(
                    token);
                var response = RequestService.Perform<MallTransactionStatusException>(mallStatusRequest, Options);

                return JsonConvert.DeserializeObject<MallStatusResponse>(response);
            });
        }

        public MallCaptureResponse Capture(string token, string childCommerceCode, string buyOrder,
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

        public void ConfigureForTesting()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.TRANSACCION_COMPLETA_MALL, IntegrationApiKeys.WEBPAY);
        }
        public void ConfigureForTestingDeferred()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.TRANSACCION_COMPLETA_MALL_DEFERRED, IntegrationApiKeys.WEBPAY);
        } 
    }
}
