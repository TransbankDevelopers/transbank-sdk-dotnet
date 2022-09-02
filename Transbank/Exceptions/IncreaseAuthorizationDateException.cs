using System;

namespace Transbank.Exceptions
{
    public class IncreaseAuthorizationDateException : TransbankException
    {
        public IncreaseAuthorizationDateException(string message) : base(-1, message) { }

        public IncreaseAuthorizationDateException(int code, string message) : base(code, message) { }

        public IncreaseAuthorizationDateException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
