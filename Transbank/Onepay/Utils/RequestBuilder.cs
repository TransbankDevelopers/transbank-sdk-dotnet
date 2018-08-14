using System;
using Transbank.Onepay.Model;
using Transbank.Onepay.Net;

namespace Transbank.Onepay.Utils
{
    interface IRequestBuilder
    {
        SendTransactionRequest BuildSendTransactionRequest(
            ShoppingCart cart, Options options);
        GetTransactionNumberRequest BuildGetTransactionNumberRequest(
            String occ, String externalUniqueNumber, Options options);
        NullifyTransactionRequest BuildNullifyTransactionRequest(long amount, 
            String occ, String externalUniqueNumber,String authorizationCode, Options options);
    }
}
