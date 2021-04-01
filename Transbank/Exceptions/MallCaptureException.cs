using System;

namespace Transbank.Exceptions
{
    public class MallCaptureException : TransbankException
    {
        public MallCaptureException(string message) : base(-1, message) { }

        public MallCaptureException(int code, string message) : base(code, message) { }

        public MallCaptureException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
