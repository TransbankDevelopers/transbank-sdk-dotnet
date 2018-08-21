using System;
using System.Collections.Generic;
using System.Text;
using Transbank.Onepay.Enums;
using Transbank.Onepay.Model;
using Transbank.Onepay.Net;

namespace Transbank.Onepay.Utils
{
    interface IRequestBuilder
    {
        SendTransactionRequest BuildSendTransactionRequest(
            ShoppingCart cart, string externalUniqueNumber, ChannelType channel, Options options);
        GetTransactionNumberRequest BuildGetTransactionNumberRequest(
            String occ, String externalUniqueNumber, Options options);
        NullifyTransactionRequest BuildNullifyTransactionRequest(long amount, 
            String occ, String externalUniqueNumber,String authorizationCode, Options options);
    }
}
