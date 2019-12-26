using System;

namespace Transbank.Exceptions
{
    public class MallTransactionAuthorizeException : TransbankException
    {
        public MallTransactionAuthorizeException(string message) : base(-1, message) { }

        public MallTransactionAuthorizeException(int code, string message) : base(code, message) { }

        public MallTransactionAuthorizeException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
        
    }
}
