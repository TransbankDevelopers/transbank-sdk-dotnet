using System;
using Newtonsoft.Json;
using System.Net.Http;
using Transbank.OnePay.Net;
using Transbank.OnePay.Utils;
using Transbank.OnePay.Exceptions;

namespace Transbank.OnePay.Model
{
    public class Refund : Channel
    {
        private static readonly string ServiceUri =
           $"{OnePay.IntegrationType.Value}/ewallet-plugin-api-services/services/transactionservice";
        private static readonly string CreateRefund = "nullifytransaction";

        public static RefundCreateResponse Create(long amount, string occ, 
            string externalUniqueNumber, string authorizationCode)
        {
            return Create(amount, occ, externalUniqueNumber, authorizationCode, null);
        }

        public static RefundCreateResponse Create(long amount, string occ,
            string externalUniqueNumber, string authorizationCode, Options options)
        {
            options = Options.Build(options);
            NullifyTransactionRequest request =
                OnePayRequestBuilder.Instance.BuildNullifyTransactionRequest(amount, occ,
                externalUniqueNumber, authorizationCode, options);
            string output = JsonConvert.SerializeObject(request);
            string input = RequestAsync($"{ServiceUri}/{CreateRefund}",
                HttpMethod.Post, output).Result;
            NullifyTransactionResponse response =
                JsonConvert.DeserializeObject<NullifyTransactionResponse>(input);

            if (response == null || response.ResponseCode == null)
            {
                throw new RefundCreateException("Could not obtain the service response");
            }
            else if (!response.ResponseCode.Equals("ok",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new RefundCreateException(
                    $"{response.ResponseCode} : {response.Description}");
            }

            if (!OnePaySignUtil.Instance.Validate(
                response.Result, options.SharedSecret))
                throw new SignatureException("Response signature is not valid");

            return response.Result;
        }
    }
}
