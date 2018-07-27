using System;
using System.Net.Http;
using Transbank.OnePay.Utils;
using Transbank.OnePay.Net;
using Transbank.OnePay.Exceptions;
using Newtonsoft.Json;

namespace Transbank.OnePay.Model
{
    public class Transaction : Channel
    {
        private static readonly string ServiceUri = 
            $"{OnePay.IntegrationType.Value}/ewallet-plugin-api-services/services/transactionservice";
        private static readonly string SendTransaction = "sendtransaction";
        private static readonly string CommitTransaction = "gettransactionnumber";
       
        public static TransactionCreateResponse Create(ShoppingCart cart)
        {
            return Create(cart, null);
        }

        public static TransactionCreateResponse Create(ShoppingCart cart,
            Options options)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));
            options = Options.Build(options);
            SendTransactionRequest request = 
                OnePayRequestBuilder.Instance.BuildSendTransactionRequest(cart, options);
            string output = JsonConvert.SerializeObject(request);
            string input = RequestAsync($"{ServiceUri}/{SendTransaction}",
                HttpMethod.Post, output).Result;
            SendTransactionResponse response = 
                JsonConvert.DeserializeObject<SendTransactionResponse>(input);

            if (response == null)
            {
                throw new TransactionCreateException(-1, 
                    "Could not obtain the service response");
            }
            else if (!response.ResponseCode.Equals("ok",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new TransactionCreateException(-1, 
                    $"{response.ResponseCode} : {response.Description}" );
            }

            if (!OnePaySignUtil.Instance.Validate(response.Result, options.SharedSecret))
                throw new SignatureException("The response signature is not valid");

            return response.Result;
        }

        public static TransactionCommitResponse Commit(string occ,
            string externalUniqueNumber)
        {
            return Commit(occ, externalUniqueNumber, null);
        }

        public static TransactionCommitResponse Commit(string occ, 
            string externalUniqueNumber, Options options)
        {
            if (occ == null)
                throw new ArgumentNullException(nameof(occ));
            if (externalUniqueNumber == null)
                throw new ArgumentNullException(nameof(externalUniqueNumber));
        
            options = Options.Build(options);
            GetTransactionNumberRequest request = 
                OnePayRequestBuilder.Instance.BuildGetTransactionNumberRequest
                (occ, externalUniqueNumber, options);
            string output = JsonConvert.SerializeObject(request);
            string input = RequestAsync($"{ServiceUri}/{CommitTransaction}",
                HttpMethod.Post, output).Result;
            GetTransactionNumberResponse response = 
                JsonConvert.DeserializeObject<GetTransactionNumberResponse>(input);

            if (response == null)
            {
                throw new TransactionCommitException(-1,
                    "Could not obtain the service response");
            }
            else if (!response.ResponseCode.Equals("ok",
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new TransactionCommitException(-1,
                        $"{response.ResponseCode} : {response.Description}");
                }

            if (!OnePaySignUtil.Instance.Validate(response.Result, options.SharedSecret))
                throw new SignatureException("The response signature is not valid");

            return response.Result;
        }
            
    }
}
