using System;

namespace Transbank.Exceptions
{
    public class TransbankException : Exception
    {
        public int Code { get; set; }

        public TransbankException()
            : base()
        {
        }
        public TransbankException(int code, string message)
            : base(message)
        {
            Code = code;
        }

        public TransbankException(int code, string message, Exception inner)
            : base(message, inner)
        {
            Code = code;
        }
    }
}
