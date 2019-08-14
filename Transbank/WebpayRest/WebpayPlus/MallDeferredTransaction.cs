using System;
using System.Collections.Generic;
using Transbank.Common;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus.Responses;

namespace Transbank.Webpay.WebpayPlus
{
    public static class MallDeferredTransaction
    {
        private static string _commerceCode = "597055555544";
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
    }
}
