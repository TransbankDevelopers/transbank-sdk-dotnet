using System;
using Transbank.Enums;

namespace Transbank
{
    public abstract class OnePay
    {
        private static string apiKey;
        private static string appKey;
        private static string callbackUrl;
        private static string sharedSecret;

        public static OnePayIntegrationType IntegrationType { get; set;} = OnePayIntegrationType.TEST;

        public static string ApiKey
        {
            get => apiKey;
            set => apiKey = value ?? throw 
                new ArgumentNullException("ApiKey can't be null");
        }
        public static string AppKey
        {
            get => appKey;
            set => appKey = value ?? throw 
                new ArgumentNullException("AppKey can't be null");
        }
        public static string CallbackUrl
        {
            get => callbackUrl;
            set => callbackUrl = value ?? throw 
                new ArgumentNullException("CallbackUrl can't be null");
        }
        public static string SharedSecret
        {
            get => sharedSecret;
            set => sharedSecret = value ?? throw 
                new ArgumentNullException("SharedSecret can't be null");
        }
    }
}
