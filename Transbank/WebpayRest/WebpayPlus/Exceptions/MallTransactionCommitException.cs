using System;
using Transbank.Exceptions;

namespace Transbank.Webpay.WebpayPlus.Exceptions
{
    public class MallTransactionCommitException : TransbankException
    {
        public MallTransactionCommitException(string message) : base(-1, message) { }

        public MallTransactionCommitException(int code, string message) : base(code, message) { }

        public MallTransactionCommitException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
