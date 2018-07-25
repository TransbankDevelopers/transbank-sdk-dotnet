using System;


namespace Transbank.OnePay.Exceptions
{
    public class RefundCreateException : TransbankException
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
