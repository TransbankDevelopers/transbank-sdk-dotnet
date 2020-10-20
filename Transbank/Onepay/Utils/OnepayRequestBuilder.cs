// Class based in https://github.com/aws-samples/aws-iot-core-dotnet-app-mqtt-over-websockets-sigv4
// subsequently modified.

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
            request.AppKey = Onepay.IntegrationType.AppKey;
        }

        private OnepayRequestBuilder() : base()
        {
            onePaySignUtil = OnepaySignUtil.Instance;
        }

        private long GetTicksNow() => DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

        public SendTransactionRequest BuildSendTransactionRequest(ShoppingCart cart, ChannelType channel, 
            string externalUniqueNumber, Options options)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));
            if (externalUniqueNumber == null)
                throw new ArgumentNullException(nameof(externalUniqueNumber));
            if (channel == null)
                throw new ArgumentNullException(nameof(channel));
            
            var callbackUrl = string.IsNullOrEmpty(Onepay.CallbackUrl) ? Onepay.DefaultCallback : Onepay.CallbackUrl;
            
            var request = new SendTransactionRequest(
                externalUniqueNumber, cart.Total, cart.ItemQuantity,
                GetTicksNow(), cart.Items, callbackUrl, channel.Value,
                options?.CommerceLogoUrl, options?.QrWidthHeight
                );

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
