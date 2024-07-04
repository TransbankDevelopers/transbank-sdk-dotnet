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
        private const int DefaultTotalTimeout = 60 * 10;
        private int _totalTimeout;

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
        public int GetTimeout()
        {
            return _totalTimeout;
        }
        public void SetTimeout(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Timeout must be a non-negative integer.");
            }
            _totalTimeout = value;
        }

        public Options(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null, int totalTimeout = DefaultTotalTimeout)
        {
            CommerceCode = commerceCode;
            ApiKey = apiKey;
            IntegrationType = integrationType;
            RequestService = new RequestService(httpClient);
            _totalTimeout = totalTimeout;
        }
        public Options(string commerceCode, string apiKey, int totalTimeout, IIntegrationType integrationType, HttpClient httpClient = null)
        {
            CommerceCode = commerceCode;
            ApiKey = apiKey;
            IntegrationType = integrationType;
            RequestService = new RequestService(httpClient);
            _totalTimeout = totalTimeout;
        }

        public override string ToString()
        {
            return $"{nameof(CommerceCode)}: {CommerceCode}, {nameof(ApiKey)}: {ApiKey}, {nameof(IntegrationType)}: {IntegrationType}, {nameof(_totalTimeout)}: {_totalTimeout}";
        }
    }
}
