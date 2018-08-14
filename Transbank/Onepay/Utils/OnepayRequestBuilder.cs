using System;
using Transbank.Onepay.Model;
using Transbank.Onepay.Net;

namespace Transbank.Onepay.Utils
{
    public class OnepayRequestBuilder : IRequestBuilder
    {
        private static OnepaySignUtil onePaySignUtil;
        private static volatile OnepayRequestBuilder instance;
        private static readonly object padlock = new object();

        protected void PrepareRequest(BaseRequest request, Options options)
        {
            request.ApiKey = options.ApiKey;
            request.AppKey = Onepay.AppKey;
        }

        private OnepayRequestBuilder() : base()
        {
            onePaySignUtil = OnepaySignUtil.Instance;
        }

        private long GetTicksNow()
        {
            return (long)DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public SendTransactionRequest BuildSendTransactionRequest(ShoppingCart cart, Options options)
        {
            var request = new SendTransactionRequest(
                Guid.NewGuid().ToString(), cart.Total, cart.ItemQuantity,
                    GetTicksNow(), cart.Items, Onepay.FakeCallbackUrl, "WEB");
            PrepareRequest(request, options);
            onePaySignUtil.Sign(request, options.SharedSecret);
            return request;
        }

        public GetTransactionNumberRequest BuildGetTransactionNumberRequest(string occ, string externalUniqueNumber, Options options)
        {
            var request =
                new GetTransactionNumberRequest(occ, externalUniqueNumber,
                GetTicksNow());
            PrepareRequest(request, options);
            onePaySignUtil.Sign(request, options.SharedSecret);
            return request;
        }

        public NullifyTransactionRequest BuildNullifyTransactionRequest(long amount, string occ, string externalUniqueNumber, string authorizationCode, Options options)
        {
            var request =
               new NullifyTransactionRequest(occ, externalUniqueNumber,
               authorizationCode, amount, GetTicksNow());
            PrepareRequest(request, options);
            onePaySignUtil.Sign(request, options.SharedSecret);
            return request;
        }

        public static OnepayRequestBuilder Instance
        {
            get
            {
                if (instance == null)
                    lock (padlock)
                        if (instance == null)
                            instance = new OnepayRequestBuilder();
                return instance;
            }
        }
        
    }
}
