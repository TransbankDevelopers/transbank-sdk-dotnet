using System;


namespace Transbank.Onepay.Exceptions
{
    public class SignatureException : Transbank.Exceptions.TransbankException
    {
        public SignatureException() : base()
        {
        }

        public SignatureException(string message) 
            : base(-1, message)
        {
        }

        public SignatureException(string message, Exception innerException) 
            : base(-1, message, innerException)
        {
        }
    }
}
