using Transbank.Common;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.WebpayPlus
{
    public class WebpayOptions
    {
        public Options Options { get; private set; }

        public WebpayOptions(Options options) { Options = options; }

        /*
        |--------------------------------------------------------------------------
        | Environment Configuration
        |--------------------------------------------------------------------------
        */

        public void ConfigureForIntegration(string commerceCode, string apiKey)
        {
            Options = new Options(commerceCode, apiKey, WebpayIntegrationType.Test);
        }

        public void ConfigureForProduction(string commerceCode, string apiKey)
        {
            Options = new Options(commerceCode, apiKey, WebpayIntegrationType.Live);
        }

        public void ConfigureForTesting()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY);
        }

        public void ConfigureForTestingDeferred()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_DEFERRED, IntegrationApiKeys.WEBPAY);
        }

        public void ConfigureForTestingMall()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MALL, IntegrationApiKeys.WEBPAY);
        }

        public void ConfigureForTestingMallDeferred()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MALL_DEFERRED, IntegrationApiKeys.WEBPAY);
        }
    }
}
