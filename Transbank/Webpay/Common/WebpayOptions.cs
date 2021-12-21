using Transbank.Common;

namespace Transbank.Webpay.Common
{
    public class WebpayOptions
    {
        public Options Options { get; protected set; }
        public WebpayOptions(Options options) { Options = options; }
        public void ConfigureForIntegration(string commerceCode, string apiKey)
        {
            Options = new Options(commerceCode, apiKey, WebpayIntegrationType.Test);
        }
        public void ConfigureForProduction(string commerceCode, string apiKey)
        {
            Options = new Options(commerceCode, apiKey, WebpayIntegrationType.Live);
        }

    }
}
