using System;

namespace Transbank.Exceptions
{
    public class ReversePreAuthorizedAmountException : TransbankException
    {
        public ReversePreAuthorizedAmountException(string message) : base(-1, message) { }

        public ReversePreAuthorizedAmountException(int code, string message) : base(code, message) { }

        public ReversePreAuthorizedAmountException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
