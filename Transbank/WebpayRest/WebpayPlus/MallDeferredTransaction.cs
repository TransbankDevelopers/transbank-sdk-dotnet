﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Onepay.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus.Responses;
using Transbank.WebpayRest.WebpayPlus.Exceptions;
using Transbank.WebpayRest.WebpayPlus.Requests;
using Transbank.WebpayRest.WebpayPlus.Responses;

namespace Transbank.Webpay.WebpayPlus
{
    public static class MallDeferredTransaction
    {
        private static string _commerceCode = "597055555544";
        private static string _apiKey = "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C";
        private static WebpayIntegrationType _integrationType = WebpayIntegrationType.Test;
        
        private static string _commerceCodeHeaderName = "Tbk-Api-Key-Id";
        private static string _apiKeyHeaderName = "Tbk-Api-Key-Secret";

        private static RequestServiceHeaders _headers = new RequestServiceHeaders(_apiKeyHeaderName, _commerceCodeHeaderName);

        public static RequestServiceHeaders Headers
        {
            get => _headers;
            set => _headers = value ?? throw new ArgumentNullException(
                                  nameof(value), "Integration type can't be null."
                              );
        }

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
            return new Options(CommerceCode, ApiKey, IntegrationType, Headers);
        }

        public static MallCreateResponse Create(string buyOrder, string sessionId, string returnUrl,
            List<TransactionDetail> transactions)
        {
            return Create(buyOrder, sessionId, returnUrl, transactions, DefaultOptions());
        }

        public static MallCreateResponse Create(string buyOrder, string sessionId, string returnUrl,
            List<TransactionDetail> transactions, Options options)
        {
            return MallTransaction.Create(buyOrder, sessionId, returnUrl, transactions, options);
        }

        public static MallCommitResponse Commit(string token)
        {
            return Commit(token, DefaultOptions());
        }

        public static MallCommitResponse Commit(string token, Options options)
        {
            return MallTransaction.Commit(token, options);
        }

        public static MallRefundResponse Refund(string token, string buyOrder, string commerceCode, decimal amount)
        {
            return Refund(token, buyOrder, commerceCode, amount, DefaultOptions());
        }
        
        public static MallRefundResponse Refund(string token, string buyOrder, string commerceCode, decimal amount, 
            Options options)
        {
            return MallTransaction.Refund(token, buyOrder, commerceCode, amount, options);
        }

        public static MallStatusResponse Status(string token)
        {
            return Status(token, DefaultOptions());
        }
        
        public static MallStatusResponse Status(string token, Options options)
        {
            return MallTransaction.Status(token, options);
        }

        public static MallCaptureResponse Capture(string token, string commerceCode, string buyOrder,
            string authorizationCode, decimal amount)
        {
            return Capture(token, commerceCode, buyOrder, authorizationCode, amount, DefaultOptions());
        }
        
        public static MallCaptureResponse Capture(string token, string commerceCode, string buyOrder,
            string authorizationCode, decimal amount, Options options)
        {
            return ExceptionHandler.Perform<MallCaptureResponse, MallTransactionCaptureException>(() =>
            {
                var mallCaptureRequest = new MallCaptureRequest(token, commerceCode, buyOrder, authorizationCode, amount);
                var response = RequestService.Perform<MallTransactionCaptureException>(mallCaptureRequest, options);
                return JsonConvert.DeserializeObject<MallCaptureResponse>(response);
            });
        }
    }
}
