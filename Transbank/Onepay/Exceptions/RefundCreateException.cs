using System;


namespace Transbank.Onepay.Exceptions
{
    public class RefundCreateException : Transbank.Exceptions.TransbankException
    {
        public RefundCreateException() : base()
        {
        }

        public RefundCreateException(string message) 
            : base(-1, message)
        {
        }

        public RefundCreateException(string message, Exception innerException) 
            : base(-1, message, innerException)
        {
        }
    }
}
