using System;
using System.Security.Cryptography;
using System.Text;
using Transbank.Net;
using Transbank.Exceptions;

namespace Transbank.Utils
{
    public class OnePaySignUtil
    {
        private static volatile OnePaySignUtil instance;
        private static readonly object padlock = new object();

        public SendTransactionRequest Sign(SendTransactionRequest request, string secret)
        {
            if (request == null)
                throw new SignatureException("Request can't be null");
            if (secret == null)
                throw new SignatureException("Secret can't be null");
            
            string extrenalUniqueNumber = request.ExternalUniqueNumber.ToString();
            string total = request.Total.ToString();
            string itemsQuantity = request.ItemsQuantity.ToString();
            string issuedAt = request.IssuedAt.ToString();

            string data = extrenalUniqueNumber.Length + extrenalUniqueNumber;
            data += total.Length + total;
            data += itemsQuantity.Length + itemsQuantity;
            data += issuedAt.Length + issuedAt;
            data += OnePay.FAKE_CALLBACK_URL.Length + OnePay.FAKE_CALLBACK_URL;

            byte[] crypted = Crypt(data, secret);
            request.Signature = Convert.ToBase64String(crypted);
            return request;
        }

        public GetTransactionNumberRequest Sign(GetTransactionNumberRequest request, string secret)
        {
            if (request == null)
                throw new SignatureException("Request can't be null");
            if (secret == null)
                throw new SignatureException("Secret can't be null");
            string occ = request.Occ;
            string externalUniqueNumber = request.ExternalUniqueNumber;
            string issuedAt = request.IssuedAt.ToString();

            string data = occ.Length + occ;
            data += externalUniqueNumber.Length + externalUniqueNumber;
            data += issuedAt.Length + issuedAt;

            byte[] crypted = Crypt(data, secret);
            request.Signature = Convert.ToBase64String(crypted);
            return request;
        }

        public NullifyTransactionRequest Sign(NullifyTransactionRequest request, string secret)
        {
            if (request == null)
                throw new SignatureException("Request can't be null");
            if (secret == null)
                throw new SignatureException("Secret can't be null");
            string occ = request.Occ;
            string externalUniqueNumber = request.ExternalUniqueNumber;
            string authorizationCode = request.AuthorizationCode;
            string issueadAt = request.IssuedAt.ToString();
            string nullifyAmount = request.NullifyAmount.ToString();

            string data = occ.Length + occ;
            data += externalUniqueNumber.Length + externalUniqueNumber;
            data += authorizationCode.Length + authorizationCode;
            data += issueadAt.Length + issueadAt;
            data += nullifyAmount.Length + nullifyAmount;

            byte[] crypted = Crypt(data, secret);
            request.Signature = Convert.ToBase64String(crypted);
            return request;
        }

        public byte[] Crypt(string data, string secret)
        {
            Encoding ascii = Encoding.ASCII;
            HMACSHA256 hmac = new HMACSHA256(ascii.GetBytes(secret));
            return hmac.ComputeHash(ascii.GetBytes(data));
        }

        public static OnePaySignUtil GetInstance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new OnePaySignUtil();
            return instance;
        }
    }
}
