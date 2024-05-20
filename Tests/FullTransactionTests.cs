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
            Assert.Equal(IntegrationCommerceCodes.TRANSACCION_COMPLETA,
                fullTransaction.options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY,
                fullTransaction.options.ApiKey);
            Assert.Equal("https://webpay3gint.transbank.cl", fullTransaction.options.IntegrationType.ApiBase);
        }

    }
}
