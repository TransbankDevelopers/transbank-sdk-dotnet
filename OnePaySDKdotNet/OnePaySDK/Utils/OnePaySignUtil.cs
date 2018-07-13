using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using Transbank.Net;

namespace Transbank.Utils
{
    public class OnePaySignUtil
    {
        private static volatile OnePaySignUtil instance;
        private static readonly object padlock = new object();

        public SendTransactionRequest sign(SendTransactionRequest request, string secret)
        {
            string extrenalUniqueNumber = request.ExternalUniqueNumber.ToString();
            string total = request.Total.ToString();
            string itemsQuantity = request.ItemsQuantity.ToString();
            string issuedAt = request.IssuedAt.ToString();

            string data = extrenalUniqueNumber.Length + extrenalUniqueNumber;
            data += total.Length + total;
            data += itemsQuantity.Length + itemsQuantity;
            data += issuedAt.Length + issuedAt;
            data += OnePay.CallbackUrl.Length + OnePay.CallbackUrl;

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
