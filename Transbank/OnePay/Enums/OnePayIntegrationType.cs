
namespace Transbank.OnePay.Enums
{
    public class OnePayIntegrationType
    {
        public static readonly OnePayIntegrationType LIVE = 
            new OnePayIntegrationType("","LIVE");
        public static readonly OnePayIntegrationType TEST =
            new OnePayIntegrationType("https://web2desa.test.transbank.cl", "TEST");
        public static readonly OnePayIntegrationType MOCK =
            new OnePayIntegrationType("http://onepay.getsandbox.com", "MOCK");

        private readonly string value;
        private readonly string key;
        private static readonly OnePayIntegrationType[] all = new[] { LIVE, TEST, MOCK };

        private OnePayIntegrationType(string displayValue, string key)
        {
            this.value = displayValue;
            this.key = key;
        }

        public string Value
        {
            get { return value; }
        }

        public string Key
        {
            get { return key; }
        }
    }
}
