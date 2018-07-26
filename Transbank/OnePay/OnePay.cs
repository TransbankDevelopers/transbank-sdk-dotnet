using System;
using Transbank.OnePay.Enums;

namespace Transbank.OnePay
{
    public abstract class OnePay
    {
        public static readonly string AppKey = "04533c31-fe7e-43ed-bbc4-1c8ab1538afp";
        public static readonly string FakeCallbackUrl = "http://nourlcallbackneededhere";

        private static string apiKey;
        private static string sharedSecret;

        public static OnePayIntegrationType IntegrationType { get; set;} = OnePayIntegrationType.TEST;

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
    }
}
