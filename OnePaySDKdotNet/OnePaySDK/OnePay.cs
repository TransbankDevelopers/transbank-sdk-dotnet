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

        public static IntegrationType IntegrationType { get; set;} = IntegrationType.TEST;

        public static string ApiKey
        {
            get => apiKey;
            set => apiKey = value ?? throw new ArgumentNullException();
        }
        public static string AppKey
        {
            get => appKey;
            set => appKey = value ?? throw new ArgumentNullException();
        }
        public static string CallbackUrl
        {
            get => callbackUrl;
            set => callbackUrl = value ?? throw new ArgumentNullException();
        }
        public static string SharedSecret
        {
            get => sharedSecret;
            set => sharedSecret = value ?? throw new ArgumentNullException();
        }
    }
}
