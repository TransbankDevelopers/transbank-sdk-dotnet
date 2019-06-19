using System;
namespace Transbank.Webpay.Common
{
    public class Options
    {
        private string _commerceCode;
        private string _apiKey;
        private WebpayIntegrationType _integrationType;

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

        public WebpayIntegrationType IntegrationType
        {
            get => _integrationType;
            set => _integrationType = value ?? throw new ArgumentNullException(
                nameof(value), "IntegrationType can't be null."
                );
        }

        public Options(string commerceCode, string apiKey, WebpayIntegrationType webpayIntegrationType)
        {
            CommerceCode = commerceCode;
            ApiKey = apiKey;
            IntegrationType = webpayIntegrationType;
        }
    }
}
