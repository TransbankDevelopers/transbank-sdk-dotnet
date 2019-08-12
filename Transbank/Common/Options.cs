using System;

namespace Transbank.Common
{
    public class Options
    {
        private string _commerceCode;
        private string _apiKey;
        private IIntegrationType _integrationType;

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

        public Options(string commerceCode, string apiKey, IIntegrationType integrationType)
        {
            CommerceCode = commerceCode;
            ApiKey = apiKey;
            IntegrationType = integrationType;
        }
    }
}
