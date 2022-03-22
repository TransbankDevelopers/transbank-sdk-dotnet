using System.Net.Http;
using Transbank.Common;

namespace Transbank.Webpay.Common
{
    public class WebpayOptions : BaseOptions
    {
        public WebpayOptions() { }
        public WebpayOptions(Options options, HttpClient httpClient = null) : base(options, httpClient) { }
        public WebpayOptions(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null)
            : base(commerceCode, apiKey, integrationType, httpClient) { }
        public void ConfigureForIntegration(string commerceCode, string apiKey)
        {
            Configure(commerceCode, apiKey, WebpayIntegrationType.Test);
        }
        public void ConfigureForProduction(string commerceCode, string apiKey)
        {
            Configure(commerceCode, apiKey, WebpayIntegrationType.Live);
        }
    }
}


