using System;
using Transbank.Common;

namespace Transbank.Patpass.Common
{
    public class PatpassComercioIntegrationType : IIntegrationType
    {
        public string Key { get; private set; }
        public string ApiBase { get; private set; }

        private PatpassComercioIntegrationType(string key, string apiBase)
        {
            Key = key;
            ApiBase = apiBase;
        }
        
        public static readonly PatpassComercioIntegrationType Live =
            new PatpassComercioIntegrationType("LIVE", "https://www.pagoautomaticocontarjetas.cl");
        public static readonly PatpassComercioIntegrationType Test =
            new PatpassComercioIntegrationType("TEST", "https://pagoautomaticocontarjetasint.transbank.cl");
    }
}
