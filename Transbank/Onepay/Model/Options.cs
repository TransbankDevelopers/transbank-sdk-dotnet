namespace Transbank.Onepay.Model
{
    public class Options
    {
        public Options()
        {
            ApiKey = Options.Default.ApiKey;
            SharedSecret = Options.Default.SharedSecret;
        }
        public Options(string commerceLogoUrl = null, int? qrWidthHeight = null)
        {
            ApiKey = Options.Default.ApiKey;
            SharedSecret = Options.Default.SharedSecret;
            CommerceLogoUrl = commerceLogoUrl;
            QrWidthHeight = qrWidthHeight;
        }
        public Options(string apiKey, string sharedSecret)
        {
            ApiKey = apiKey;
            SharedSecret = sharedSecret;
        }
        public Options(string apiKey, string sharedSecret, string commerceLogoUrl = null, int? qrWidthHeight = null)
        {
            ApiKey = apiKey;
            SharedSecret = sharedSecret;
            CommerceLogoUrl = commerceLogoUrl;
            QrWidthHeight = qrWidthHeight;
        }

        public string ApiKey { get; set; }
        public string SharedSecret { set; get; }
        public string CommerceLogoUrl { get; set; }
        public int? QrWidthHeight { get; set; }

        public override string ToString()
        {
            return $"ApiKey={ApiKey}, SharedSecret={SharedSecret}, CommerceLogoUrl={CommerceLogoUrl}, QrWidthHeight={QrWidthHeight}";
        }

        public static Options Default
        {
            get =>  new Options(Onepay.ApiKey, Onepay.SharedSecret);
        }

        public static Options Build(Options options)
        {
            if (options == null) return Options.Default;

            if (options.ApiKey == null) options.ApiKey = Onepay.ApiKey;
            if (options.SharedSecret == null) options.SharedSecret = Onepay.SharedSecret;
            if (options.CommerceLogoUrl == null) options.CommerceLogoUrl = Onepay.CommerceLogoUrl;
            if (options.QrWidthHeight == null) options.QrWidthHeight = Onepay.QrWidthHeight;

            return options;
        }
    }
}
