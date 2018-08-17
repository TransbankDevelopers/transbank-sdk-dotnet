using System;
using Transbank.Onepay.Enums;

namespace Transbank.Onepay
{
    public abstract class Onepay
    {
        public static readonly string AppKey = "04533c31-fe7e-43ed-bbc4-1c8ab1538afp";
        public static readonly string FakeCallbackUrl = "http://nourlcallbackneededhere";

        private static string _apiKey;
        private static string _sharedSecret;

        public static OnepayIntegrationType IntegrationType { get; set;} = OnepayIntegrationType.Test;

        public static string ApiKey
        {
            get => _apiKey;
            set => _apiKey = value ?? throw 
                new ArgumentNullException("ApiKey can't be null");
        }
        public static string SharedSecret
        {
            get => _sharedSecret;
            set => _sharedSecret = value ?? throw 
                new ArgumentNullException("SharedSecret can't be null");
        }
    }
}
