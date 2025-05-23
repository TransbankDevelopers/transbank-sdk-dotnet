using System;
using System.Net.Http;

namespace Transbank.Common
{
    public class Options
    {
        private string _commerceCode;
        private string _apiKey;
        private IIntegrationType _integrationType;
        private RequestService _requestService;
        private const int _defaultTimeout = 60 * 10;
        private int _timeout;

        public string CommerceCode
        {
            get => _commerceCode;
            private set => _commerceCode = value ?? throw new ArgumentNullException(
                nameof(value), "Commerce code can't be null."
            );
        }

        public string ApiKey
        {
            get => _apiKey;
            private set => _apiKey = value ?? throw new ArgumentNullException(
                nameof(value), "Api Key can't be null."
            );
        }

        public IIntegrationType IntegrationType
        {
            get => _integrationType;
            private set => _integrationType = value ?? throw new ArgumentNullException(
                nameof(value), "IntegrationType can't be null."
                );
        }

        public RequestService RequestService
        {
            get
            {
                return _requestService;
            }

            private set => _requestService = value ?? throw new ArgumentNullException(
                nameof(value), "Request service can't be null."
            );

        }
        public int Timeout
        {
            get => _timeout;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Timeout must be a non-negative integer.");
                }
                _timeout = value;
            }
        }

        public Options(string commerceCode, string apiKey, IIntegrationType integrationType, int  timeout = _defaultTimeout, HttpClient httpClient = null)
        {
            CommerceCode = commerceCode;
            ApiKey = apiKey;
            IntegrationType = integrationType;
            RequestService = new RequestService(httpClient);
            Timeout = timeout;
        }

        public override string ToString()
        {
            return $"{nameof(CommerceCode)}: {CommerceCode}, {nameof(ApiKey)}: {ApiKey}, {nameof(IntegrationType)}: {IntegrationType}, {nameof(_timeout)}: {_timeout}";
        }
    }
}
