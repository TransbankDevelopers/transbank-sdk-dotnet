using System;
using Newtonsoft.Json;

namespace Transbank.Common
{
    public class Options
    {
        private string _commerceCode;
        private string _apiKey;
        private IIntegrationType _integrationType;
        
        private static string _commerceCodeHeaderName = "Tbk-Api-Key-Id";
        private static string _apiKeyHeaderName = "Tbk-Api-Key-Secret";

        private static RequestServiceHeaders _headers = new RequestServiceHeaders(_apiKeyHeaderName, _commerceCodeHeaderName);
        
        public RequestServiceHeaders Headers
        {
            get => _headers;
            set => _headers = value ?? throw new ArgumentNullException(
                                  nameof(value), "headers can't be null."
                              );
        }

        public string CommerceCode
        {
            get => _commerceCode;
            set => _commerceCode = value ?? throw new ArgumentNullException(
                nameof(value), "Commerce code can't be null."
            );
        }

        public string ApiKey
        {
            get => _apiKey;
            set => _apiKey = value ?? throw new ArgumentNullException(
                nameof(value), "Api Key can't be null."
            );
        }

        public IIntegrationType IntegrationType
        {
            get => _integrationType;
            set => _integrationType = value ?? throw new ArgumentNullException(
                nameof(value), "IntegrationType can't be null."
                );
        }

        public Options(string commerceCode, string apiKey, IIntegrationType integrationType, RequestServiceHeaders headers)
        {
            CommerceCode = commerceCode;
            ApiKey = apiKey;
            IntegrationType = integrationType;
            Headers = headers;
        }
    }
}
