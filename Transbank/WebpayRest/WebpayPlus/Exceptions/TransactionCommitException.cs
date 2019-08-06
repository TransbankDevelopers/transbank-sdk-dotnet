using System;
using Transbank.Exceptions;

namespace Transbank.Webpay.WebpayPlus.Exceptions
{
    public class TransactionCommitException : TransbankException
    {
        public TransactionCommitException(string message) : base(-1, message) { }

        public TransactionCommitException(int code, string message) : base(code, message) { }

        public TransactionCommitException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
