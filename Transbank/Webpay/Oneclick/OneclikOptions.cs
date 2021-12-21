using Transbank.Common;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Oneclick
{
    public class OneclickOptions : WebpayOptions
    {
        public OneclickOptions(Options options) : base(options) { }

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
