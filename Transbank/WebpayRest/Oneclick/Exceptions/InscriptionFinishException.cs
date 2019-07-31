using System;
using Transbank.Exceptions;

namespace Transbank.Webpay.Oneclick.Exceptions
{
    public class InscriptionFinishException : TransbankException
    {
        public InscriptionFinishException() : base()
        {
        }

        public InscriptionFinishException(string message)
            : base(-1, message)
        {
        }

        public InscriptionFinishException(int code, string message)
            : base(code, message)
        {
        }

        public InscriptionFinishException(int code, string message,
            Exception innerException) : base(code, message, innerException)
        {
        }
    }
}
