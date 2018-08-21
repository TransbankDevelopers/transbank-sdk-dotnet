using System;
using System.Net.Http;
using Transbank.Onepay.Utils;
using Transbank.Onepay.Net;
using Transbank.Onepay.Exceptions;
using Newtonsoft.Json;
using Transbank.Onepay.Enums;

namespace Transbank.Onepay.Model
{
    public class Transaction : Channel
    {
        private static readonly string ServiceUri = 
            $"{Onepay.IntegrationType.Value}/ewallet-plugin-api-services/services/transactionservice";

        private const string SendTransaction = "sendtransaction";
        private const string CommitTransaction = "gettransactionnumber";

        [Obsolete ("use Create(ShoppingCart,ChannelType) instead")]
        public static TransactionCreateResponse Create(ShoppingCart cart)
        {

            return Create(cart, options: null);
        }
       
       [Obsolete ("use Create(ShoppingCart,ChannelType,Options) instead")]
        public static TransactionCreateResponse Create(ShoppingCart cart, Options options)
        {
            string externalUniqueNumber = Guid.NewGuid().ToString();
            return Create (cart, externalUniqueNumber, Onepay.DefaultChannel, options);
        }

        public static TransactionCreateResponse Create(ShoppingCart cart, string externalUniqueNumber)
        {
            return Create(cart, externalUniqueNumber, options: null);
        }

        public static TransactionCreateResponse Create(ShoppingCart cart, string externalUniqueNumber, Options options)
        {
            return Create(cart, externalUniqueNumber, Onepay.DefaultChannel);
        }

        public static TransactionCreateResponse Create(ShoppingCart cart, string externalUniqueNumber, ChannelType channel)
        {
            return Create(cart, externalUniqueNumber, channel, options: null);
        }

        public static TransactionCreateResponse Create(ShoppingCart cart, string externalUniqueNumber, ChannelType channel, Options options)
        {
            if (channel == ChannelType.App && string.IsNullOrEmpty(Onepay.AppScheme))
                throw new TransactionCreateException("You need to set an appScheme if you want to use APP channel");
            
            if (channel == ChannelType.Mobile && string.IsNullOrEmpty(Onepay.CallbackUrl))
                throw new TransactionCreateException("You need to set a valid callback is you want to use MOBILE channel");
            
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));
            options = Options.Build(options);

            var request = 
                OnepayRequestBuilder.Instance.BuildSendTransactionRequest(cart, externalUniqueNumber, channel, options);
            var output = JsonConvert.SerializeObject(request);
            var input = Request($"{ServiceUri}/{SendTransaction}",
                HttpMethod.Post, output);
            var response = 
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

            if (!OnepaySignUtil.Instance.Validate(response.Result, options.SharedSecret))
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
            var request = 
                OnepayRequestBuilder.Instance.BuildGetTransactionNumberRequest
                (occ, externalUniqueNumber, options);
            var output = JsonConvert.SerializeObject(request);
            var input = Request($"{ServiceUri}/{CommitTransaction}",
                HttpMethod.Post, output);
            var response = 
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

            if (!OnepaySignUtil.Instance.Validate(response.Result, options.SharedSecret))
                throw new SignatureException("The response signature is not valid");

            return response.Result;
        }
            
    }
}
