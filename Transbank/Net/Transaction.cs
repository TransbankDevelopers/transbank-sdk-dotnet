using System;
using System.Net.Http;
using Transbank.Model;
using Transbank.Utils;
using Transbank.Enums;
using Transbank.Exceptions;
using Newtonsoft.Json;

namespace Transbank.Net
{
    public class Transaction : Channel
    {
        private static readonly string SERVICE_URI = 
            $"{OnePay.IntegrationType.Value}/ewallet-plugin-api-services/services/transactionservice";
        private static readonly string SEND_TRANSACTION = "sendtransaction";
        private static readonly string COMMIT_TRNSACTION = "gettransactionnumber";
       
        public static TransactionCreateResponse Create(ShoppingCart cart)
        {
            return Create(cart, null);
        }

        public static TransactionCreateResponse Create(ShoppingCart cart,
            Options options)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));
            options = Options.build(options);
            SendTransactionRequest request = 
                OnePayRequestBuilder.GetInstance().Build(cart, options);
            string output = JsonConvert.SerializeObject(request);
            string input = requestAsync($"{SERVICE_URI}/{SEND_TRANSACTION}",
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

            return response.Result; 
        }

        public static TransactionCommitResponse Commit(string occ, string externalUniqueNumber)
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
        
            options = Options.build(options);
            GetTransactionNumberRequest request = OnePayRequestBuilder.GetInstance().Build(occ, externalUniqueNumber, options);
            string output = JsonConvert.SerializeObject(request);
            string input = requestAsync($"{SERVICE_URI}/{COMMIT_TRNSACTION}",
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
            return response.Result;
        }
            
    }
}
