using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.WebpayPlus.Responses;

namespace Transbank.Webpay.WebpayPlus
{
    public static class MallTransaction
    {
        public static MallCreateResponse Create(string buyOrder, string sessionId, string returnUrl, List<TransactionDetail> transactions)
        {
            return Create(buyOrder, sessionId, returnUrl, transactions, WebpayPlus.DefaultOptions());
        }

        public static MallCreateResponse Create(string buyOrder, string sessionId, string returnUrl, List<TransactionDetail> transactions, Options options)
        {
            var mallCreateRequest = new MallCreateRequest(buyOrder, sessionId, returnUrl, transactions);
            var response = RequestService.Perform(mallCreateRequest, options);

            return JsonConvert.DeserializeObject<MallCreateResponse>(response);
        }

        public static MallCommitResponse Commit(string token)
        {
            return Commit(token, WebpayPlus.DefaultOptions());
        }

        public static MallCommitResponse Commit(string token, Options options)
        {
            var mallCommitRequest = new MallCommitRequest(token);
            var response = RequestService.Perform(mallCommitRequest, options);

            return JsonConvert.DeserializeObject<MallCommitResponse>(response);
        }
    }
}
