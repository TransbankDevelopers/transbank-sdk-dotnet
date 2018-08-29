
namespace Transbank.Onepay.Enums
{
    public class OnepayIntegrationType
    {
        public static readonly OnepayIntegrationType LIVE = 
            new OnepayIntegrationType("LIVE", "https://www.onepay.cl", "81A33064-26DC-4267-8616-C97D252E7378");
        public static readonly OnepayIntegrationType TEST =
            new OnepayIntegrationType("TEST", "https://onepay.ionix.cl", "297a620c-c776-4dd6-a42c-8669c6a4f2c5");
        public static readonly OnepayIntegrationType MOCK =
            new OnepayIntegrationType("MOCK", "http://onepay.getsandbox.com", "04533c31-fe7e-43ed-bbc4-1c8ab1538afp");

        private readonly string _apiBase;
        private readonly string _appKey;
        private readonly string _key;
        
        private OnepayIntegrationType(string key, string apiBase, string appKey)
        {
            _key = key;
            _apiBase = apiBase;
            _appKey = appKey;
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
