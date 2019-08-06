using System;
using Transbank.Exceptions;

namespace Transbank.Webpay.WebpayPlus.Exceptions
{
    public class MallStatusException : TransbankException
    {

        public MallStatusException(string message) : base(-1, message) { }

        public MallStatusException(int code, string message) : base(code, message) { }

        public MallStatusException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}
