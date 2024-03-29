using System;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using System.Collections.Generic;
using Transbank.Webpay.TransaccionCompletaMall.Common;
using Transbank.Webpay.TransaccionCompletaMall.Requests;
using Transbank.Webpay.TransaccionCompletaMall.Responses;
using System.Net.Http;

namespace Transbank.Webpay.TransaccionCompletaMall
{
    public class MallFullTransaction : WebpayOptions
    {
        public MallFullTransaction() { ConfigureForTesting(); }
        public MallFullTransaction(Options options, HttpClient httpClient = null) : base(options, httpClient) { }
        public MallFullTransaction(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null)
            : base(commerceCode, apiKey, integrationType, httpClient) { }

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
                return _requestService.Perform<MallCreateResponse, MallTransactionCreateException>(mallCreateRequest, Options);
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
                return _requestService.Perform<MallInstallmentsResponse, MallTransactionInstallmentsExceptions>(mallInstallmentsResponse, Options);
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

                    var resp = _requestService.Perform<MallInstallmentsResponse, MallTransactionInstallmentsExceptions>(request, Options);
                    det.Add(new MallInstallmentsResponse(resp.InstallmentsAmount, resp.IdQueryInstallments, resp.DeferredPeriods));
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
                return _requestService.Perform<MallCommitResponse, MallTransactionCommitException>(mallCommitRequest, Options);
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
                return _requestService.Perform<MallRefundResponse, MallTransactionRefundException>(mallRefundRequest, Options);
            });
        }

        public  MallStatusResponse Status(string token)
        {

            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");
            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(token);
                return _requestService.Perform<MallStatusResponse, MallTransactionStatusException>(mallStatusRequest, Options);
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
                return _requestService.Perform<MallCaptureResponse, MallTransactionCaptureException>(mallCaptureRequest, Options);
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
