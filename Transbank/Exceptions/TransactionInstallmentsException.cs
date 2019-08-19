using System;

namespace Transbank.Exceptions
{
    public class TransactionInstallmentsException : TransbankException
    {
        public TransactionInstallmentsException(string message) : base(-1, message) { }

        public TransactionInstallmentsException(int code, string message) : base(code, message) { }

        public TransactionInstallmentsException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
        
    }
}
