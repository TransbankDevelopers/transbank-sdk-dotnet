using System;


namespace Transbank.Onepay.Exceptions
{
    public class TransactionCreateException : Transbank.Exceptions.TransbankException
    {
        public TransactionCreateException() : base()
        {
        }
        
        public TransactionCreateException(string message) 
            : base(-1, message)
        {
        }

        public TransactionCreateException(int code, string message) 
            : base(code, message)
        {
        }

        public TransactionCreateException(int code, string message, 
            Exception innerException) : base(code, message, innerException)
        {
        }
    }
}
