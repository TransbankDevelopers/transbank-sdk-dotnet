using System;
using System.Collections.Generic;
using System.Text;
using Transbank.Onepay.Enums;
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
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (options == null)
                throw new ArgumentNullException(nameof(options));
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

        public SendTransactionRequest BuildSendTransactionRequest(ShoppingCart cart, string externalUniqueNumber,
            ChannelType channel, Options options)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));
            if (externalUniqueNumber == null)
                throw new ArgumentNullException(nameof(externalUniqueNumber));
            
            var callbackUrl = string.IsNullOrEmpty(Onepay.CallbackUrl) ? Onepay.DefaultCallback : Onepay.CallbackUrl;
            
            var request = new SendTransactionRequest(
                externalUniqueNumber, cart.Total, cart.ItemQuantity,
                    GetTicksNow(), cart.Items, callbackUrl, channel.Value);

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
