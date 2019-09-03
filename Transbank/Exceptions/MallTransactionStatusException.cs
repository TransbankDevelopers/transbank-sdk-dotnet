using System;

namespace Transbank.Exceptions
{
    public class MallTransactionStatusException : TransbankException
    {
        public MallTransactionStatusException(string message) : base(-1, message) { }

        public MallTransactionStatusException(int code, string message) : base(code, message) { }

        public MallTransactionStatusException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
