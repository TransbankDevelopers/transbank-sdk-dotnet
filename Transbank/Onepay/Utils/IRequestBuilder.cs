// Class based in https://github.com/aws-samples/aws-iot-core-dotnet-app-mqtt-over-websockets-sigv4
// subsequently modified.

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
            ShoppingCart cart, ChannelType channel, string externalUniqueNumber, Options options);
        GetTransactionNumberRequest BuildGetTransactionNumberRequest(
            String occ, String externalUniqueNumber, Options options);
        NullifyTransactionRequest BuildNullifyTransactionRequest(long amount, 
            String occ, String externalUniqueNumber,String authorizationCode, Options options);
    }
}
