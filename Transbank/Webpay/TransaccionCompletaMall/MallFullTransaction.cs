using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.TransaccionCompletaMall.Common;
using Transbank.Webpay.TransaccionCompletaMall.Requests;
using Transbank.Webpay.TransaccionCompletaMall.Responses;

namespace Transbank.Webpay.TransaccionCompletaMall
{
    public class MallFullTransaction
    {
        private static string _commerceCode = "";
        private static string _apiKey = "";
        
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

        public static MallCreateResponse Create(
            string buyOrder,
            string sessionId,
            string cardNumber,
            string cardExpirationDate,
            List<CreateDetails> details)
        {
            return Create(buyOrder, sessionId, cardNumber, cardExpirationDate, details);
        }

        public static MallCreateResponse Create(
            string buyOrder,
            string sessionId,
            string cardNumber,
            string cardExpirationDate,
            List<CreateDetails> details,
            Options options)
        {
            ValidationUtil.hasTextWithMaxLength(buyOrder, 26, "buyOrder");
            ValidationUtil.hasTextWithMaxLength(sessionId, 61, "sessionId");
            ValidationUtil.hasTextWithMaxLength(cardNumber, 19, "cardNumber");
            ValidationUtil.hasTextWithMaxLength(cardExpirationDate, 5, "cardExpirationDate");
            ValidationUtil.hasElements(details, "details");

            foreach (var item in details){
                ValidationUtil.hasText(item.CommerceCode, "details.commerceCode");
                ValidationUtil.hasTextWithMaxLength(item.BuyOrder, 26, "details.buyOrder");
            }

            return ExceptionHandler.Perform<MallCreateResponse, MallTransactionCreateException>(() =>
            {
                var mallCreateRequest = new MallCreateRequest(
                    buyOrder,
                    sessionId,
                    cardNumber,
                    cardExpirationDate,
                    details);
                var response = RequestService.Perform<MallTransactionCreateException>(mallCreateRequest, options);

                return JsonConvert.DeserializeObject<MallCreateResponse>(response);
            });
        }

        public static MallInstallmentsResponse Installments(
            string token,
            string commerceCode,
            string buyOrder,
            int installmentsAmount)
        {

            return Installments(
                token,
                commerceCode,
                buyOrder,
                installmentsAmount);
        }

        public static MallInstallmentsResponse Installments(
            string token,
            string commerceCode,
            string buyOrder,
            int installmentsNumber,
            Options options)
        {

            ValidationUtil.hasText(token, "token");
            ValidationUtil.hasText(commerceCode, "commerceCode");
            ValidationUtil.hasTextWithMaxLength(buyOrder, 26, "buyOrder");

            return ExceptionHandler.Perform<MallInstallmentsResponse, MallTransactionInstallmentsExceptions>(() =>
            {
                var mallInstallmentsResponse = new MallInstallmentsRequest(
                    token,
                    commerceCode,
                    buyOrder,
                    installmentsNumber);
                var response = RequestService.Perform<MallTransactionInstallmentsExceptions>(mallInstallmentsResponse, options);

                return JsonConvert.DeserializeObject<MallInstallmentsResponse>(response);
            });
        }

        public static MallInstallmentsDetailsResponse Installments(
            string token,
            List<MallInstallmentsDetails> details)
        {
            return Installments(token, details);
        }

        public static MallInstallmentsDetailsResponse Installments(
            string token,
            List<MallInstallmentsDetails> detailsGroup,
            Options options)
        {
            ValidationUtil.hasText(token, "token");

            return ExceptionHandler.Perform<MallInstallmentsDetailsResponse, MallTransactionInstallmentsExceptions>(() =>
            {
               List<MallInstallmentsResponse> details = new List<MallInstallmentsResponse>();

               foreach (MallInstallmentsDetails req in detailsGroup)
               {
                   var request = new MallInstallmentsRequest(
                       token,
                       req.CommerceCode,
                       req.BuyOrder,
                       req.InstallmentsNumber);

                   var response = RequestService.Perform<MallTransactionInstallmentsExceptions>(request, options);
                   var json = JsonConvert.DeserializeObject<MallInstallmentsResponse>(response);
                   
                   details.Add(new MallInstallmentsResponse(json.InstallmentsAmount, json.IdQueryInstallments, json.DeferredPeriods));

               }

              

               return JsonConvert.DeserializeObject<MallInstallmentsDetailsResponse>(details.ToString());
            });
        }

        public static MallCommitResponse Commit(
            string token,
            List<MallCommitDetails> details)
        {
            return Commit(
                token, 
                details);
        }

        public static MallCommitResponse Commit(
            string token,
            List<MallCommitDetails> details,
            Options options)
        {

            ValidationUtil.hasText(token, "token");

            return ExceptionHandler.Perform<MallCommitResponse, MallTransactionCommitException>(() =>
            {
                var mallCommitRequest = new MallCommitRequest(
                    token,
                    details);
                var response = RequestService.Perform<MallTransactionCommitException>(mallCommitRequest, options);

                return JsonConvert.DeserializeObject<MallCommitResponse>(response);
            });
        }

        public static MallRefundResponse Refund(
            string token,
            string buyOrder,
            string commerceCode,
            int amount)
        {
            return Refund(token, buyOrder, commerceCode, amount);
        }

        public static MallRefundResponse Refund(
            string token,
            string buyOrder,
            string commerceCode,
            int amount,
            Options options)
        {
            ValidationUtil.hasText(token, "token");
            ValidationUtil.hasText(commerceCode, "commerceCode");
            ValidationUtil.hasTextWithMaxLength(buyOrder, 26, "buyOrder");

            return ExceptionHandler.Perform<MallRefundResponse, MallTransactionRefundException>(() =>
            {
                var mallRefundRequest = new MallRefundRequest(
                    token,
                    buyOrder,
                    commerceCode, 
                    amount);
                var response = RequestService.Perform<MallTransactionRefundException>(mallRefundRequest, options);

                return JsonConvert.DeserializeObject<MallRefundResponse>(response);

            });
        }

        public static MallStatusResponse Status(
            string token)
        {
            return Status(token);
        }

        public static MallStatusResponse Status(
            string token,
            Options options)
        {

            ValidationUtil.hasText(token, "token");
            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(
                    token);
                var response = RequestService.Perform<MallTransactionStatusException>(mallStatusRequest, options);

                return JsonConvert.DeserializeObject<MallStatusResponse>(response);
            });
        }
    }
 }
