using System;


namespace Transbank.Onepay.Exceptions
{
    public class HttpHelperException : TransbankException
    {
        public HttpHelperException() : base()
        {
        }

        public HttpHelperException(string message) 
            : base(-1, message)
        {
        }

        public HttpHelperException(string message, Exception innerException) 
            : base(-1, message, innerException)
        {
        }
    }
}
