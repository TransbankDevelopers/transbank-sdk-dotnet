using Xunit;
using Transbank.Common;
using Transbank.Webpay.TransaccionCompleta;
using Transbank.Webpay.TransaccionCompletaMall;

namespace Tests
{
    public class FullTransactionTests
    {
        [Fact]
        public void CorrectOptions()
        {
            FullTransaction fullTransaction = FullTransaction.buildForIntegration(IntegrationCommerceCodes.TRANSACCION_COMPLETA, IntegrationApiKeys.WEBPAY);
            MallFullTransaction mallFullTransaction = MallFullTransaction.buildForIntegration(IntegrationCommerceCodes.TRANSACCION_COMPLETA_MALL, IntegrationApiKeys.WEBPAY);
            Assert.Equal(IntegrationCommerceCodes.TRANSACCION_COMPLETA,
                fullTransaction.Options.CommerceCode);
            Assert.Equal(IntegrationCommerceCodes.TRANSACCION_COMPLETA_MALL,
                mallFullTransaction.Options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY,
                fullTransaction.Options.ApiKey);
            Assert.Equal(IntegrationApiKeys.WEBPAY,
                mallFullTransaction.Options.ApiKey);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            FullTransaction transaction = FullTransaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY);
            MallFullTransaction mallTransaction = MallFullTransaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MALL, IntegrationApiKeys.WEBPAY);
            Assert.Equal("https://webpay3gint.transbank.cl", transaction.Options.IntegrationType.ApiBase);
            Assert.Equal("https://webpay3gint.transbank.cl", mallTransaction.Options.IntegrationType.ApiBase);
        }

    }
}
