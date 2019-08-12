using System;
using Transbank.Common;

namespace Transbank.Patpass.Common
{
    public class PatpassByWebpayIntegrationType : IIntegrationType
    {
        public string Key { get; private set; }
        public string ApiBase { get; private set; }

        private PatpassByWebpayIntegrationType(string key, string apiBase)
        {
            Key = key;
            ApiBase = apiBase;
        }

        public static readonly PatpassByWebpayIntegrationType Live =
            new PatpassByWebpayIntegrationType("LIVE", "https://webpay3g.transbank.cl");
        public static readonly PatpassByWebpayIntegrationType Test =
            new PatpassByWebpayIntegrationType("TEST", "https://webpay3gint.transbank.cl");
    }
}
