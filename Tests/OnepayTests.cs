using Transbank.Onepay;
using Transbank.Onepay.Enums;
using Transbank.Onepay.Net;
using Xunit;

namespace Tests
{
    public class OnepayTests
    {   
        [Fact]
        public void TestOnepaySettings()
        {
            Assert.Equal(OnepayIntegrationType.Test, Onepay.IntegrationType);
            Assert.Equal("dKVhq1WGt_XapIYirTXNyUKoWTDFfxaEV63-O5jcsdw", Onepay.ApiKey);
            Assert.Equal("?XW#WOLG##FBAGEAYSNQ5APD#JF@$AYZ", Onepay.SharedSecret);
        }

        [Fact]
        public void OnepayIntegrationTypeTest()
        {
            var type = OnepayIntegrationType.Live;
            Assert.Equal("LIVE", type.Key);
            Assert.Equal("https://www.onepay.cl", type.ApiBase);
            Assert.Equal("81A33064-26DC-4267-8616-C97D252E7378", type.AppKey);

            type = OnepayIntegrationType.Test;
            Assert.Equal("TEST", type.Key);
            Assert.Equal("https://onepay.ionix.cl", type.ApiBase);
            Assert.Equal("297a620c-c776-4dd6-a42c-8669c6a4f2c5", type.AppKey);

            type = OnepayIntegrationType.Mock;
            Assert.Equal("MOCK", type.Key);
            Assert.Equal("https://transbank-onepay-ewallet-mock.herokuapp.com", type.ApiBase);
            Assert.Equal("04533c31-fe7e-43ed-bbc4-1c8ab1538afp", type.AppKey);
        }

        [Fact]
        public void GetTransactioNumberRequestTest()
        {
            var request = new GetTransactionNumberRequest(
                occ: "0011", externalUniqueNumber: "ABC123", issuedAt: 20
                );

            Assert.Equal("0011", request.Occ);
            Assert.Equal("ABC123", request.ExternalUniqueNumber);
            Assert.Equal(20, request.IssuedAt);
        }
    }
}
