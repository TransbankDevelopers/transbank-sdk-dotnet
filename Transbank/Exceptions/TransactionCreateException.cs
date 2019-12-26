using System;

namespace Transbank.Exceptions
{
    public class TransactionCreateException : TransbankException
    {
        public TransactionCreateException(string message) : base(-1, message) { }

        public TransactionCreateException(int code, string message) : base(code, message) { }

        public TransactionCreateException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
