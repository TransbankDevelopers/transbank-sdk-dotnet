using System;
using Transbank.Exceptions;

namespace Transbank.Exceptions
{
    public class MallTransactionCaptureException : TransbankException
    {
        public MallTransactionCaptureException(string message) : base(-1, message) { }

        public MallTransactionCaptureException(int code, string message) : base(code, message) { }

        public MallTransactionCaptureException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
