using System;
using Transbank.Onepay.Enums;

namespace Transbank.Onepay
{
    public abstract class Onepay
    {
        public static readonly ChannelType DefaultChannel = ChannelType.Web;
        public static readonly string DefaultCallback = "http://no.callback.has/been.set";
       
        private static string _apiKey;
        private static string _sharedSecret;
        private static string _callbackUrl;
        private static string _appScheme;

        protected Onepay()
        {
        }

        public static OnepayIntegrationType IntegrationType { get; set;} = OnepayIntegrationType.Test;

        public static string ApiKey
        {
            get => _apiKey;
            set => _apiKey = value ?? throw 
                new ArgumentNullException(value,"ApiKey can't be null");
        }
        public static string SharedSecret
        {
            get => _sharedSecret;
            set => _sharedSecret = value ?? throw 
                new ArgumentNullException(value, "SharedSecret can't be null");
        }

        public static string AppScheme
        {
            get => _appScheme;
            set => _appScheme = value ?? throw new ArgumentNullException(nameof(value), "AppScheme can't be null");
        }
        
        public static string CallbackUrl
        {
            get => _callbackUrl;
            set => _callbackUrl = value ?? throw new ArgumentNullException(nameof(value), "CallbackUrl cant't be null");
        }

        public static string CurrentIntegrationTypeUrl => $"{IntegrationType.ApiBase}" +
                $"/ewallet-plugin-api-services/services/transactionservice";
    }
}
