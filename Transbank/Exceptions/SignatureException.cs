using System;


namespace Transbank.Exceptions
{
    public class SignatureException : TransbankException
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
