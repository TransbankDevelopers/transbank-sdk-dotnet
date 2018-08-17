
namespace Transbank.Onepay.Enums
{
    public class OnepayIntegrationType
    {
        public static readonly OnepayIntegrationType Live = 
            new OnepayIntegrationType("","LIVE");
        public static readonly OnepayIntegrationType Test =
            new OnepayIntegrationType("https://web2desa.test.transbank.cl", "TEST");
        public static readonly OnepayIntegrationType Mock =
            new OnepayIntegrationType("http://onepay.getsandbox.com", "MOCK");

        private readonly string _value;
        private readonly string _key;
        private static readonly OnepayIntegrationType[] _all = new[] { Live, Test, Mock };

        private OnepayIntegrationType(string displayValue, string key)
        {
            this._value = displayValue;
            this._key = key;
        }

        public string Value
        {
            get { return _value; }
        }

        public string Key
        {
            get { return _key; }
        }
    }
}
