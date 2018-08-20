using System;
using Transbank.Onepay.Enums;

namespace Transbank.Onepay
{
    public abstract class Onepay
    {
        public static readonly ChannelType DefaultChannel = ChannelType.Web;
        public static readonly string DefaultCallback = "http://no.callback.has/been.set";
        public static readonly string AppKey = "04533c31-fe7e-43ed-bbc4-1c8ab1538afp";
        public static readonly string FakeCallbackUrl = "http://nourlcallbackneededhere";

        private static string apiKey;
        private static string sharedSecret;
        private static string _callbackUrl;
        private static string _appScheme;

        public static OnepayIntegrationType IntegrationType { get; set;} = OnepayIntegrationType.TEST;

        public static string ApiKey
        {
            get => apiKey;
            set => apiKey = value ?? throw 
                new ArgumentNullException("ApiKey can't be null");
        }
        public static string SharedSecret
        {
            get => sharedSecret;
            set => sharedSecret = value ?? throw 
                new ArgumentNullException("SharedSecret can't be null");
        }

        public static string AppScheme
        {
            get => _appScheme;
            set => _appScheme = value ?? throw new ArgumentNullException(nameof(_appScheme));
        }
        
        public static string CallbackUrl
        {
            get => _callbackUrl;
            set => _callbackUrl = value ?? throw new ArgumentNullException(nameof(_callbackUrl));
        }
    }
}
