using System;


namespace Transbank.Onepay.Exceptions
{
    public class Sigv4UtilException : TransbankException
    {
        public Sigv4UtilException() : base()
        {
        }

        public Sigv4UtilException(string message) 
            : base(-1, message)
        {
        }

        public Sigv4UtilException(string message, Exception innerException) 
            : base(-1, message, innerException)
        {
        }
    }
}
