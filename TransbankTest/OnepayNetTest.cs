using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transbank.Onepay.Net;

namespace TransbankTest
{
    [TestClass]
    public class OnepayNetTest
    {
        [TestMethod]
        public void GetTransactioNumberRequestTest()
        {
            var request = new GetTransactionNumberRequest(
                occ: "0011", externalUniqueNumber: "ABC123", issuedAt: 20
                );

            Assert.AreEqual("0011", request.Occ);
            Assert.AreEqual("ABC123", request.ExternalUniqueNumber);
            Assert.AreEqual(20, request.IssuedAt);
        }
    }
}
