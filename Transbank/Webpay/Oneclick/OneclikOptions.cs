using System.Net.Http;
using Transbank.Common;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Oneclick
{
    public class OneclickOptions : WebpayOptions
    {
        public OneclickOptions() { }
        public OneclickOptions(Options options) : base(options) { }
        public OneclickOptions(Options options, HttpClient httpClient = null) : base(options, httpClient) { }
        public OneclickOptions(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null)
            : base(commerceCode, apiKey, integrationType, httpClient) { }

        /*
        |--------------------------------------------------------------------------
        | Environment Configuration
        |--------------------------------------------------------------------------
        */
        public void ConfigureForTesting()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.ONECLICK_MALL, IntegrationApiKeys.WEBPAY);
        }

        public void ConfigureForTestingDeferred()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.ONECLICK_MALL_DEFERRED, IntegrationApiKeys.WEBPAY);
        }
    }
}
