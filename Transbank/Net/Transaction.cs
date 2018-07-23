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
            if (cart == null)
                throw new ArgumentNullException("ShoppingCart can't be null");
            return Create(cart, null);
        }

        public static TransactionCreateResponse Create(ShoppingCart cart,
            Options options)
        {
            if (cart == null)
                throw new ArgumentNullException("ShoppingCart can't be null");
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
    }
}
