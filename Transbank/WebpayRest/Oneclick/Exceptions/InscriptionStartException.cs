using System;
using Transbank.Exceptions;

namespace Transbank.Webpay.Oneclick.Exceptions
{
    public class InscriptionStartException : TransbankException
    {
        public InscriptionStartException() : base()
        {
        }

        public InscriptionStartException(string message)
            : base(-1, message)
        {
        }

        public InscriptionStartException(int code, string message)
            : base(code, message)
        {
        }

        public InscriptionStartException(int code, string message,
            Exception innerException) : base(code, message, innerException)
        {
        }
    }
}
