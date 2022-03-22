using System.Net.Http;

namespace Transbank.Common
{
    public class BaseOptions
    {
        public Options Options { get; protected set; }
        protected RequestService _requestService;
        public BaseOptions() {
            _requestService = new RequestService();
        }
        public BaseOptions(Options options, HttpClient httpClient = null) { 
            Options = options;
            _requestService = new RequestService(httpClient);
        }
        public BaseOptions(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null)
        {
            Configure(commerceCode, apiKey, integrationType);
            _requestService = new RequestService(httpClient);
        }
        public void Configure(string commerceCode, string apiKey, IIntegrationType integrationType)
        {
            Options = new Options(commerceCode, apiKey, integrationType);
        }
    }
}


