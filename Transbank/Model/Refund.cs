using System;
using Newtonsoft.Json;
using System.Net.Http;
using Transbank.Net;
using Transbank.Utils;
using Transbank.Exceptions;

namespace Transbank.Model
{
    public class Refund : Channel
    {
        private static readonly string SERVICE_URI =
           $"{OnePay.IntegrationType.Value}/ewallet-plugin-api-services/services/transactionservice";
        private static readonly string CREATE_REFUND = "nullifytransaction";

        public static RefundCreateResponse Create(long amount, string occ, 
            string externalUniqueNumber, string authorizationCode)
        {
            return Create(amount, occ, externalUniqueNumber, authorizationCode, null);
        }

        public static RefundCreateResponse Create(long amount, string occ,
            string externalUniqueNumber, string authorizationCode, Options options)
        {
            options = Options.build(options);
            NullifyTransactionRequest request =
                OnePayRequestBuilder.GetInstance().Build(amount, occ,
                externalUniqueNumber, authorizationCode, options);
            string output = JsonConvert.SerializeObject(request);
            string input = requestAsync($"{SERVICE_URI}/{CREATE_REFUND}",
                HttpMethod.Post, output).Result;
            NullifyTransactionResponse response =
                JsonConvert.DeserializeObject<NullifyTransactionResponse>(input);

            if (response == null)
            {
                throw new RefundCreateException("Could not obtain the service response");
            }
            else if (!response.ResponseCode.Equals("ok",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new RefundCreateException(
                    $"{response.ResponseCode} : {response.Description}");
            }
            return response.Result;
        }
    }
}
