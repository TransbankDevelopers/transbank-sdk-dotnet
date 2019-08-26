using System;
using System.Collections.Generic;
using Microsoft.Web.Services3.Security;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Patpass.Common;
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

        public static MallCreateResponse MallCreate(
            string buyOrder,
            string sessionId,
            string cardNumber,
            string cardExpirationDate,
            List<CreateDetails> details)
        {
            return MallCreate(buyOrder, sessionId, cardNumber, cardExpirationDate, details);
        }

        public static MallCreateResponse MallCreate(
            string buyOrder,
            string sessionId,
            string cardNumber,
            string cardExpirationDate,
            List<CreateDetails> details,
            Options options)
        {
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

        public static MallInstallmentsResponse MallInstallments(
            string token,
            string commerceCode,
            string buyOrder,
            int installmentsAmount)
        {
            return MallInstallments(
                token,
                commerceCode,
                buyOrder,
                installmentsAmount);
        }

        public static MallInstallmentsResponse MallInstallments(
            string token,
            string commerceCode,
            string buyOrder,
            int installmentsAmount,
            Options options)
        {
            return ExceptionHandler.Perform<MallInstallmentsResponse, MallTransactionInstallmentsExceptions>(() =>
            {
                var mallInstallmentsResponse = new MallInstallmentsRequest(
                    token,
                    commerceCode,
                    buyOrder,
                    installmentsAmount);
                var response = RequestService.Perform<MallTransactionInstallmentsExceptions>(mallInstallmentsResponse, options);

                return JsonConvert.DeserializeObject<MallInstallmentsResponse>(response);
            });
        }

        public static MallCommitResponse MallCommit(
            string token,
            List<CommitDetails> details)
        {
            return MallCommit(
                token, 
                details);
        }

        public static MallCommitResponse MallCommit(
            string token,
            List<CommitDetails> details,
            Options options)
        {
            return ExceptionHandler.Perform<MallCommitResponse, MallTransactionCommitException>(() =>
            {
                var mallCommitRequest = new MallCommitRequest(
                    token,
                    details);
                var response = RequestService.Perform<MallTransactionCommitException>(mallCommitRequest, options);

                return JsonConvert.DeserializeObject<MallCommitResponse>(response);
            });
        }

        public static MallRefundResponse MallRefund(
            string token,
            string buyOrder,
            string commerceCode,
            int amount)
        {
            return MallRefund(token, buyOrder, commerceCode, amount);
        }

        public static MallRefundResponse MallRefund(
            string token,
            string buyOrder,
            string commerceCode,
            int amount,
            Options options)
        {
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
    }
    
    
}
