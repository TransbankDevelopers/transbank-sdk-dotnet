using System;

namespace Transbank.Exceptions
{
    public class MallTransactionCommitException : TransbankException
    {
        public MallTransactionCommitException(string message) : base(-1, message) { }

        public MallTransactionCommitException(int code, string message) : base(code, message) { }

        public MallTransactionCommitException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
