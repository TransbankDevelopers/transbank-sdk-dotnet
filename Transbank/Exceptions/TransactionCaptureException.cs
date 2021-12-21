using System;
using Transbank.Exceptions;

namespace Transbank.Exceptions
{
    public class TransactionCaptureException : TransbankException
    {
        public TransactionCaptureException(string message) : base(-1, message) { }

        public TransactionCaptureException(int code, string message) : base(code, message) { }

        public TransactionCaptureException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
