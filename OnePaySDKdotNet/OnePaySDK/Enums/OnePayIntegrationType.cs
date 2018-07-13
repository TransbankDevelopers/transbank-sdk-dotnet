using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Transbank.Enums
{
    public class OnePayIntegrationType
    {
        public static readonly OnePayIntegrationType LIVE = 
            new OnePayIntegrationType("","LIVE");
        public static readonly OnePayIntegrationType TEST =
            new OnePayIntegrationType("https://web2desa.test.transbank.cl", "TEST");
        public static readonly OnePayIntegrationType MOCK =
            new OnePayIntegrationType("http://onepay.getsandbox.com", "MOCK");

        private readonly string displayValue;
        private readonly string key;
        private static readonly OnePayIntegrationType[] all = new[] { LIVE, TEST, MOCK };

        private OnePayIntegrationType(string displayValue, string key)
        {
            this.displayValue = displayValue;
            this.key = key;
        }

        public string DisplayValue
        {
            get { return displayValue; }
        }

        public string Key
        {
            get { return key; }
        }
    }
}
