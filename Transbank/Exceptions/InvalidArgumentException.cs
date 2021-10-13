using System;

namespace Transbank.Exceptions
{
    public class InvalidArgumentException : TransbankException
    {
        public InvalidArgumentException(string message) : base(-1, message) { }

        public InvalidArgumentException(int code, string message) : base(code, message) { }

        public InvalidArgumentException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
