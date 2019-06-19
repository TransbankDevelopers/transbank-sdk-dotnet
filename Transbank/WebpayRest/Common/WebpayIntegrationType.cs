using System;
namespace Transbank.Webpay.Common
{
    public class WebpayIntegrationType
    {
        public string Key { get; private set; }
        public string ApiBase { get; private set; }

        private WebpayIntegrationType(string key, string apiBase)
        {
            Key = key;
            ApiBase = apiBase;
        }

        public static readonly WebpayIntegrationType Live =
            new WebpayIntegrationType("LIVE", "https://webpay3g.transbank.cl/");
        public static readonly WebpayIntegrationType Test =
            new WebpayIntegrationType("TEST", "https://webpay3gint.transbank.cl/");
    }
}
