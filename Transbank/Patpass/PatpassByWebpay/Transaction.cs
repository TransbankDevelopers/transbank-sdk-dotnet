using System;
using System.Net.Http;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Patpass.Common;
using Transbank.Patpass.PatpassByWebpay.Requests;
using Transbank.Patpass.PatpassByWebpay.Responses;

namespace Transbank.Patpass.PatpassByWebpay
{
    public class Transaction : BaseOptions
    {
        public Transaction() { ConfigureForTesting(); }

        public Transaction(Options options, HttpClient httpClient = null) : base(options, httpClient) { }
        public Transaction(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null)
            : base(commerceCode, apiKey, integrationType, httpClient) { }

        public CreateResponse Create(string buyOrder, string sessionId, decimal amount, string returnUrl, string serviceId, string cardHolderId,
                string cardHolderName, string cardHolderLastName1, string cardHolderLastName2, string cardHolderMail, string cellphoneNumber,
                string expirationDate, string commerceMail, bool ufFlag)
        {
            return ExceptionHandler.Perform<CreateResponse, TransactionCreateException>(() =>
            {
                var createRequest = new CreateRequest(buyOrder, sessionId, amount, returnUrl, serviceId, cardHolderId,
                cardHolderName, cardHolderLastName1, cardHolderLastName2, cardHolderMail, cellphoneNumber,
                expirationDate, commerceMail, ufFlag);
                return _requestService.Perform<CreateResponse, TransactionCreateException>(createRequest, Options);
            });
        }

        public CommitResponse Commit(string token)
        {
            return ExceptionHandler.Perform<CommitResponse, TransactionCommitException>(() =>
            {
                var commitRequest = new CommitRequest(token);
                return _requestService.Perform<CommitResponse, TransactionCommitException>(
                    commitRequest, Options);
            });
        }

        public StatusResponse Status(string token)
        {
            return ExceptionHandler.Perform<StatusResponse, TransactionStatusException>(() =>
            {
                var statusRequest = new StatusRequest(token);
                return _requestService.Perform<StatusResponse, TransactionStatusException>(
                    statusRequest, Options);
            });
        }

        /*
        |--------------------------------------------------------------------------
        | Environment Configuration
        |--------------------------------------------------------------------------
        */

        public void ConfigureForIntegration(String commerceCode, String apiKey)
        {
            Configure(commerceCode, apiKey, PatpassByWebpayIntegrationType.Test);
        }

        public void ConfigureForProduction(String commerceCode, String apiKey)
        {
            Configure(commerceCode, apiKey, PatpassByWebpayIntegrationType.Live);
        }
        public void ConfigureForTesting()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.PATPASS_BY_WEBPAY, IntegrationApiKeys.WEBPAY);
        }
    }
}
