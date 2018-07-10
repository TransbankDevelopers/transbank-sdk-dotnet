using System;
using System.Collections.Generic;
using System.Text;

namespace OnePaySDK
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
            get { return apiKey; }
            set { apiKey = value ?? throw new ArgumentNullException(); }
        }
        public string AppKey
        {
            get { return appKey; }
            set { appKey = value ?? throw new ArgumentNullException(); }
        }
        public string CallbackUrl
        {
            get { return callbackUrl; }
            set { callbackUrl = value ?? throw new ArgumentNullException(); }
        }
        public string SharedSecret {
            get { return sharedSecret; }
            set { sharedSecret = value ?? throw new ArgumentNullException(); }
        }
    }
}
