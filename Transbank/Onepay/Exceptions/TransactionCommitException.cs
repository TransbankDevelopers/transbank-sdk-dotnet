using System;


namespace Transbank.Onepay.Exceptions
{
    public class TransactionCommitException : Transbank.Exceptions.TransbankException
    {
        public TransactionCommitException() : base()
        {
        }

        public TransactionCommitException(int code, string message) 
            : base(code, message)
        {
        }

        public TransactionCommitException(int code, string message, 
            Exception innerException) : base(code, message, innerException)
        {
        }
    }
}
