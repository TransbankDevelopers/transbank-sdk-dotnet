using System;

namespace Transbank.Exceptions
{
    public class IncreaseAmountException : TransbankException
    {
        public IncreaseAmountException(string message) : base(-1, message) { }

        public IncreaseAmountException(int code, string message) : base(code, message) { }

        public IncreaseAmountException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
