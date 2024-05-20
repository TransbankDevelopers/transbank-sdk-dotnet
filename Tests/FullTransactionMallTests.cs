using Xunit;
using Transbank.Common;
using Transbank.Webpay.TransaccionCompleta;
using Transbank.Webpay.TransaccionCompletaMall;

namespace Tests
{
    public class FullTransactionMallTests
    {

        [Fact]
        public void CorrectOptions()
        {
            MallFullTransaction mallFullTransaction = MallFullTransaction.buildForIntegration(IntegrationCommerceCodes.TRANSACCION_COMPLETA_MALL, IntegrationApiKeys.WEBPAY);
            Assert.Equal(IntegrationCommerceCodes.TRANSACCION_COMPLETA_MALL,
                mallFullTransaction.options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY,
                mallFullTransaction.options.ApiKey);
            Assert.Equal("https://webpay3gint.transbank.cl", mallFullTransaction.options.IntegrationType.ApiBase);
        }

    }
}
