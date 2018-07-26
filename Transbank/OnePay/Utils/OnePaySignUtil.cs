using System;
using System.Security.Cryptography;
using System.Text;
using Transbank.OnePay.Model;
using Transbank.OnePay.Net;
using Transbank.OnePay.Exceptions;

namespace Transbank.OnePay.Utils
{
    public class OnePaySignUtil : ISignUtil
    {
        private static volatile OnePaySignUtil instance;
        private static readonly object padlock = new object();

        public void Sign(ISignable signable, string secret)
        {
            if (signable == null)
                throw new SignatureException(nameof(signable));
            if (secret == null)
                throw new SignatureException(nameof(secret));
            
            byte[] crypted = Crypt(signable.GetDataToSign(), secret);
            signable.Signature = Convert.ToBase64String(crypted);
        }

        public bool Validate(ISignable signable, string secret)
        {
            if (signable == null)
                throw new SignatureException(nameof(signable));
            if (secret == null)
                throw new SignatureException(nameof(secret));
            byte[] crypted = Crypt(signable.GetDataToSign(), secret);
            var sign = Convert.ToBase64String(crypted);
            return sign.Equals(signable.Signature);

        }

        public byte[] Crypt(string data, string secret)
        {
            Encoding ascii = Encoding.ASCII;
            HMACSHA256 hmac = new HMACSHA256(ascii.GetBytes(secret));
            return hmac.ComputeHash(ascii.GetBytes(data));
        }

        public static OnePaySignUtil Instance
        {
            get 
            {
                if (instance == null)
                    lock (padlock)
                        if (instance == null)
                            instance = new OnePaySignUtil();
                return instance;
            }
        }
    }
}
