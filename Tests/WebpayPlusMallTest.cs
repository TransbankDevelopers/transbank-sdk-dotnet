using Xunit;
using Transbank.Common;
using Transbank.Webpay.WebpayPlus;
using Transbank.Webpay.Common;
using System.Collections.Generic;

namespace Tests
{
    public class WebpayPlusMallTests
    {
        [Fact]
        public void CorrectOptions()
        {
            MallTransaction mallTransaction = MallTransaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MALL, IntegrationApiKeys.WEBPAY);
            Assert.Equal(IntegrationCommerceCodes.WEBPAY_PLUS_MALL, mallTransaction.options.CommerceCode);
            Assert.Equal(IntegrationApiKeys.WEBPAY, mallTransaction.options.ApiKey);
            Assert.Equal("https://webpay3gint.transbank.cl", mallTransaction.options.IntegrationType.ApiBase);
        }

        [Fact]
        public void CorrectIntegrationUrl()
        {
            MallTransaction mallTransaction = MallTransaction.buildForIntegration(IntegrationCommerceCodes.WEBPAY_PLUS_MALL, IntegrationApiKeys.WEBPAY);
            var transactions = new List<TransactionDetail>();
            transactions.Add(new TransactionDetail(
                9900,
                IntegrationCommerceCodes.WEBPAY_PLUS_MALL_CHILD1,
                "childBuyOrder123"
            ));
            var response = mallTransaction.Create("buy123", "sess123", "https://www.pruebas.cl", transactions);
            Assert.Contains(WebpayIntegrationType.Test.ApiBase, response.Url);
        }
    }
}
