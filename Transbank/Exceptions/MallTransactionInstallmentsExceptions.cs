using System;

namespace Transbank.Exceptions
{
    public class MallTransactionInstallmentsExceptions : TransbankException
    {
        public MallTransactionInstallmentsExceptions(string message) : base(-1, message) { }

        public MallTransactionInstallmentsExceptions(int code, string message) : base(code, message) { }

        public MallTransactionInstallmentsExceptions(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
