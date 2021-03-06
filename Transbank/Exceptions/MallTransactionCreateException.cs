using System;

namespace Transbank.Exceptions
{
    public class MallTransactionCreateException : TransbankException
    {
        public MallTransactionCreateException(string message) : base(-1, message) { }

        public MallTransactionCreateException(int code, string message) : base(code, message) { }

        public MallTransactionCreateException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
