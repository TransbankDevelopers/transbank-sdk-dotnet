
namespace Transbank.Onepay.Enums
{
    public class OnepayIntegrationType
    {
        public static readonly OnepayIntegrationType LIVE = 
            new OnepayIntegrationType("","LIVE");
        public static readonly OnepayIntegrationType TEST =
            new OnepayIntegrationType("https://web2desa.test.transbank.cl", "TEST");
        public static readonly OnepayIntegrationType MOCK =
            new OnepayIntegrationType("http://onepay.getsandbox.com", "MOCK");

        private readonly string value;
        private readonly string key;
        private static readonly OnepayIntegrationType[] all = new[] { LIVE, TEST, MOCK };

        private OnepayIntegrationType(string displayValue, string key)
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
