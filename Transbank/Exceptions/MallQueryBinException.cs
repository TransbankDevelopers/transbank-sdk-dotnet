using System;

namespace Transbank.Exceptions
{
    public class MallQueryBinException : TransbankException
    {
        public MallQueryBinException(string message) : base(-1, message) { }

        public MallQueryBinException(int code, string message) : base(code, message) { }

        public MallQueryBinException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }

    }
}
