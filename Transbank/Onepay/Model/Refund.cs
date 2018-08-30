using System;
using Newtonsoft.Json;
using System.Net.Http;
using Transbank.Onepay.Net;
using Transbank.Onepay.Utils;
using Transbank.Onepay.Exceptions;

namespace Transbank.Onepay.Model
{
    public class Refund : Channel
    {
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
            var request =
                OnepayRequestBuilder.Instance.BuildNullifyTransactionRequest(amount, occ,
                externalUniqueNumber, authorizationCode, options);
            string output = JsonConvert.SerializeObject(request);
            string input = Request($"{Onepay.CurrentIntegrationTypeUrl}/{CreateRefund}",
                HttpMethod.Post, output);
            var response =
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

            if (!OnepaySignUtil.Instance.Validate(
                response.Result, options.SharedSecret))
                throw new SignatureException("Response signature is not valid");

            return response.Result;
        }
    }
}
