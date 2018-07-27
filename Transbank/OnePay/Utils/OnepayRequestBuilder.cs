using System;
using System.Collections.Generic;
using System.Text;
using Transbank.OnePay.Model;
using Transbank.OnePay.Net;

namespace Transbank.OnePay.Utils
{
    public class OnePayRequestBuilder : IRequestBuilder
    {
        private static OnePaySignUtil onePaySignUtil;
        private static volatile OnePayRequestBuilder instance;
        private static readonly object padlock = new object();

        protected void PrepareRequest(BaseRequest request, Options options)
        {
            request.ApiKey = options.ApiKey;
            request.AppKey = OnePay.AppKey;
        }

        private OnePayRequestBuilder() : base()
        {
            onePaySignUtil = OnePaySignUtil.Instance;
        }

        private long GetTicksNow()
        {
            return (long)DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public SendTransactionRequest BuildSendTransactionRequest(ShoppingCart cart, Options options)
        {
            SendTransactionRequest request = new SendTransactionRequest(
                Guid.NewGuid().ToString(), cart.Total, cart.ItemQuantity,
                    GetTicksNow(), cart.Items, OnePay.FakeCallbackUrl, "WEB");
            PrepareRequest(request, options);
            onePaySignUtil.Sign(request, options.SharedSecret);
            return request;
        }

        public GetTransactionNumberRequest BuildGetTransactionNumberRequest(string occ, string externalUniqueNumber, Options options)
        {
            GetTransactionNumberRequest request =
                new GetTransactionNumberRequest(occ, externalUniqueNumber,
                GetTicksNow());
            PrepareRequest(request, options);
            onePaySignUtil.Sign(request, options.SharedSecret);
            return request;
        }

        public NullifyTransactionRequest BuildNullifyTransactionRequest(long amount, string occ, string externalUniqueNumber, string authorizationCode, Options options)
        {
            NullifyTransactionRequest request =
               new NullifyTransactionRequest(occ, externalUniqueNumber,
               authorizationCode, amount, GetTicksNow());
            PrepareRequest(request, options);
            onePaySignUtil.Sign(request, options.SharedSecret);
            return request;
        }

        public static OnePayRequestBuilder Instance
        {
            get
            {
                if (instance == null)
                    lock (padlock)
                        if (instance == null)
                            instance = new OnePayRequestBuilder();
                return instance;
            }
        }
        
    }
}
