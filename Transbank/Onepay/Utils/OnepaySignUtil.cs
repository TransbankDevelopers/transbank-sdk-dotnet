// Class based in https://github.com/aws-samples/aws-iot-core-dotnet-app-mqtt-over-websockets-sigv4
// subsequently modified.

using System;
using System.Security.Cryptography;
using System.Text;
using Transbank.Onepay.Model;
using Transbank.Onepay.Exceptions;

namespace Transbank.Onepay.Utils
{
    public class OnepaySignUtil : ISignUtil
    {
        private static volatile OnepaySignUtil instance;
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
            var ascii = Encoding.ASCII;
            var hmac = new HMACSHA256(ascii.GetBytes(secret));
            return hmac.ComputeHash(ascii.GetBytes(data));
        }

        public static OnepaySignUtil Instance
        {
            get 
            {
                if (instance == null)
                    lock (padlock)
                        if (instance == null)
                            instance = new OnepaySignUtil();
                return instance;
            }
        }
    }
}
