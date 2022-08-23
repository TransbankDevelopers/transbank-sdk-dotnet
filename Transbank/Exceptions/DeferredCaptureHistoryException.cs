using System;

namespace Transbank.Exceptions
{
    public class DeferredCaptureHistoryException : TransbankException
    {
        public DeferredCaptureHistoryException(string message) : base(-1, message) { }

        public DeferredCaptureHistoryException(int code, string message) : base(code, message) { }

        public DeferredCaptureHistoryException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
