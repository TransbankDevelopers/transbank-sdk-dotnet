using System;
using Transbank.Exceptions;

namespace Transbank.Webpay.WebpayPlus.Exceptions
{
    public class TransactionStatusException : TransbankException
    {
        public TransactionStatusException(string message) : base(-1, message) { }

        public TransactionStatusException(int code, string message) : base(code, message) { }

        public TransactionStatusException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
