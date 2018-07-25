using System;


namespace Transbank.OnePay.Exceptions
{
    public class TransactionCommitException : TransbankException
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
