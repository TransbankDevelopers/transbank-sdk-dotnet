using System;
using System.Collections.Generic;
using System.Text;
using Transbank.OnePay.Model;
using Transbank.OnePay.Net;

namespace Transbank.OnePay.Utils
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
