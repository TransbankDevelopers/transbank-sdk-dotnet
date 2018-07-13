using System;


namespace Transbank.Exceptions
{
    public class AmountException : TransbankException
    {
        public AmountException() : base()
        {
        }

        public AmountException(int code, string message) 
            : base(code, message)
        {
        }

        public AmountException(int code, string message, Exception innerException) 
            : base(code, message, innerException)
        {
        }
    }
}